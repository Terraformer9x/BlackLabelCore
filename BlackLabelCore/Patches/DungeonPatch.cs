using BlackLabelCore.Levels;
using DunGen;
using HarmonyLib;
using System.Linq;
using UnityEngine;

namespace BlackLabelCore.Patches;

[HarmonyPatch]
internal class DungeonPatch
{
    [HarmonyPatch(typeof(Dungeon), "PreGenerateDungeon")]
    [HarmonyPostfix]
    private static void PreGenerateDungeonPostfix(Dungeon __instance)
    {
        if (Compatibility.LethalLevelLoader) return;

        int fireExits = 1;
        if (RoundManager.Instance.currentLevel.name == "MarchLevel") fireExits = 3;
        __instance.DungeonFlow.GlobalProps.Find(x => x.ID == 1231).Count = new IntRange(fireExits, fireExits);

        //Alternative code similar to LLL's method, I opted for the more simpler approach to save on potential loadtime.
        /*List<EntranceTeleport> entranceTeleports = [];
        Scene currentScene = SceneManager.GetSceneByName(RoundManager.Instance.currentLevel.sceneName);
        foreach(GameObject gameObject in currentScene.GetRootGameObjects())
        {
            foreach(EntranceTeleport teleport in gameObject.GetComponentsInChildren<EntranceTeleport>())
            {
                entranceTeleports.Add(teleport);
            }
        }
        entranceTeleports.OrderBy(x => x.entranceId).ToList();
        __instance.DungeonFlow.GlobalProps.Find(x => x.ID == 1231).Count = new IntRange(entranceTeleports.Count - 1, entranceTeleports.Count - 1);*/
    }


    [HarmonyPatch(typeof(Dungeon), "PostGenerateDungeon")]
    [HarmonyPostfix]
    private static void PostGenerateDungeonPostfix(Dungeon __instance)
    {
        switch(__instance.DungeonFlow.name)
        {
            case "Level2Flow": Level2Patch(); break;
            case "Level3Flow": Level3Patch(); break;
        }

        void Level2Patch() {
            Plugin.LogDebug(__instance.DungeonFlow.name + " detected, forcing ground level entrance.");
            Tile manorStartRoom = __instance.AllTiles?.First<Tile>(x => x.name == "ManorStartRoom(Clone)");
            if (manorStartRoom != null)
            {
                LocalPropSet localPropSet = manorStartRoom.transform.Find("MainEntrancePropSet")?.GetComponent<LocalPropSet>();
                if (localPropSet != null)
                {
                    localPropSet.Props.Weights.ForEach(x => { if (x.Value.name != "MainEntranceSpawnPositionA") x.MainPathWeight = 0f; x.BranchPathWeight = 0f; });
                }
            }
        }

        void Level3Patch()
        {
            foreach (Tile tile in __instance.AllTiles.Where(x => x.name == "CaveSmallIntersectTile(Clone)" || x.name == "CaveCrampedIntersectTile(Clone)"))
            {
                Transform tempTransform = tile.transform.Find("GeneralScrapSpawn")?.transform;
                if (tempTransform != null)
                {
                    Plugin.LogDebug($"Converting to random spawn at " + tempTransform.position.x + ", " + tempTransform.position.y + ", " + tempTransform.position.z);
                    Functions.ConvertToRandomSpawn(tempTransform, 0.3f, 0.5f);
                }
            }
        }
    }

    [HarmonyPatch(typeof(DungeonGenerator), "ProcessGlobalProps")]
    [HarmonyPostfix]
    private static void ProcessGlobalPropsPostfix(DungeonGenerator __instance)
    {
        switch (__instance.DungeonFlow.name)
        {
            case "Level3Flow": Level3Patch(); break; 
        }

        void Level3Patch() {
            foreach (Tile tile in __instance.CurrentDungeon.AllTiles.Where(x => x.name == "TunnelSplit(Clone)" || x.name == "TunnelSplitEndTile(Clone)"))
            {
                Transform shelf = tile.transform.Find("SouthWallProps/Shelf1 (14)")?.transform;
                if (shelf != null)
                {
                    Plugin.LogDebug($"Found a shelf at " + shelf.position.x + ", " + shelf.position.y + ", " + shelf.position.z);
                    Functions.CreateItemSpawn(shelf, new Vector3(-7.67999983f, -6.5999999f, 1.78999996f), "SmallItems", 15, true);
                }

                Transform woodPallet = tile.transform.Find("Props/PropSet2/WoodPalletPile2x")?.transform;
                if (woodPallet != null)
                {
                    Plugin.LogDebug($"Found a pallet at " + woodPallet.position.x + ", " + woodPallet.position.y + ", " + woodPallet.position.z);
                    Functions.CreateItemSpawn(woodPallet, new Vector3(0.300000012f, 0.0399999991f, 2.53999996f), "TabletopItems", 3, false);
                }

                Transform minecart = tile.transform.Find("Props/PropSet2/Minecart (1)")?.transform;
                if (minecart != null)
                {
                    Plugin.LogDebug($"Found a minecart at " + minecart.position.x + ", " + minecart.position.y + ", " + minecart.position.z);
                    Transform itemSpawn = Functions.CreateItemSpawn(minecart, new Vector3(-0.74000001f, 1.22000003f, 4.11000013f), "SmallItems", 1, false)?.transform;
                    if (itemSpawn != null) Functions.ConvertToRandomSpawn(itemSpawn, 0.25f, 0.8f);
                }
            }
            foreach (Tile tile in __instance.CurrentDungeon.AllTiles.Where(x => x.name == "CaveCrampedIntersectTile(Clone)"))
            {
                GameObject tablePropSpawn = tile.transform.Find("TablePropSpawn")?.gameObject;
                if (tablePropSpawn != null)
                {
                    Plugin.LogDebug($"Destroying table prop spawn at " + tablePropSpawn.transform.position.x + ", " + tablePropSpawn.transform.position.y + ", " + tablePropSpawn.transform.position.z);
                    GameObject.Destroy(tablePropSpawn);
                }
            }
            foreach (Tile tile in __instance.CurrentDungeon.AllTiles.Where(x => x.name == "CaveWaterTile(Clone)"))
            {
                GameObject mapHazard = tile.transform.Find("MapHazardSpawnType1")?.gameObject;
                if (mapHazard != null)
                {
                    Plugin.LogDebug($"Destroying hazard spawn at " + mapHazard.transform.position.x + ", " + mapHazard.transform.position.y + ", " + mapHazard.transform.position.z);
                    GameObject.Destroy(mapHazard);
                }
                Mesh sharedMesh = tile.transform.Find("WaterTileMesh")?.gameObject.GetComponent<MeshCollider>()?.sharedMesh;
                if (sharedMesh != null)
                {
                    Plugin.LogDebug($"Changing collision on water tile at " + tile.transform.position.x + ", " + tile.transform.position.y + ", " + tile.transform.position.z);
                    sharedMesh = Assets.waterTileCollision;
                }
            }
        }
    }

    private class Functions
    {
        internal static GameObject CreateItemSpawn(Transform transform, Vector3 localPosition, string spawn, int range, bool copy)
        {
            GameObject obj = new GameObject();
            obj.name = "AddedItemSpawn_" + spawn;
            obj.transform.SetParent(transform);
            obj.transform.localPosition = localPosition;
            RandomScrapSpawn randomScrapSpawn = obj.AddComponent<RandomScrapSpawn>();
            randomScrapSpawn.spawnableItems = GlobalInfo.itemGroups[spawn];
            randomScrapSpawn.itemSpawnRange = range;
            randomScrapSpawn.spawnedItemsCopyPosition = copy;

            return obj;
        }

        internal static GameObject ConvertToRandomSpawn(Transform transform, float mainWeight, float branchWeight)
        {
            GameObject obj = new GameObject();
            obj.name = "AddedRandomSpawn_" + transform.name;
            obj.transform.SetParent(transform.parent);
            transform.SetParent(obj.transform);
            LocalPropSet localPropSet = obj.AddComponent<LocalPropSet>();

            GameObjectChance objSpawnChance = new GameObjectChance();
            objSpawnChance.Value = transform.gameObject;
            objSpawnChance.MainPathWeight = mainWeight;
            objSpawnChance.BranchPathWeight = branchWeight;

            localPropSet.Props.Weights.Add(objSpawnChance);
            localPropSet.PropCount.Min = 0;
            localPropSet.PropCount.Max = 1;

            return obj;
        }
    }
}