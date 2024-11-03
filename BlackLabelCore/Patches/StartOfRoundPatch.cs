using BlackLabelCore.Levels;
using DunGen.Graph;
using HarmonyLib;
using UnityEngine;

namespace BlackLabelCore.Patches;

[HarmonyPatch(typeof(StartOfRound))]
internal class StartOfRoundPatch
{
    private static bool executed = false;
    public static RoundManager RoundManager { get; internal set; }
    public static StartOfRound StartOfRound { get; internal set; }
    public static SoundManager SoundManager { get; internal set; }

    [HarmonyPatch("Awake")]
    [HarmonyPrefix]
    private static void Execute()
    {
        if (executed) return;

        RoundManager = GameObject.FindFirstObjectByType<RoundManager>();
        StartOfRound = GameObject.FindFirstObjectByType<StartOfRound>();
        SoundManager = GameObject.FindFirstObjectByType<SoundManager>();

        SetupGlobalInfo();
        SetupItems();
        SetupDungeonFlows();
        SetupLevels();

        executed = true;
    }

    private static void SetupGlobalInfo()
    {
        foreach (SelectableLevel level in Resources.FindObjectsOfTypeAll<SelectableLevel>())
        {
            if (level != null && !GlobalInfo.levels.ContainsKey(level.name) && !GlobalInfo.levels.ContainsValue(level))
            {
                GlobalInfo.levels.Add(level.name, level);
            }
        }
        foreach (Item item in Resources.FindObjectsOfTypeAll<Item>())
        {
            if (item.spawnPrefab != null && !GlobalInfo.items.ContainsKey(item.name) && !GlobalInfo.items.ContainsValue(item))
            {
                GlobalInfo.items.Add(item.name, item);
            }
        }
        foreach (ItemGroup itemGroup in Resources.FindObjectsOfTypeAll<ItemGroup>())
        {
            if(itemGroup != null && !GlobalInfo.itemGroups.ContainsKey(itemGroup.name) && !GlobalInfo.itemGroups.ContainsValue(itemGroup))
            {
                GlobalInfo.itemGroups.Add(itemGroup.name, itemGroup);
            }
        }
        foreach (EnemyType enemy in Resources.FindObjectsOfTypeAll<EnemyType>())
        {
            if (enemy.enemyPrefab != null && !GlobalInfo.enemies.ContainsKey(enemy.name) && !GlobalInfo.enemies.ContainsValue(enemy))
            {
                GlobalInfo.enemies.Add(enemy.name, enemy);
            }
        }
        foreach (SelectableLevel level in Resources.FindObjectsOfTypeAll<SelectableLevel>())
        {
            foreach (SpawnableMapObject trap in level.spawnableMapObjects)
            {
                if (trap.prefabToSpawn != null && !GlobalInfo.traps.ContainsKey(trap.prefabToSpawn.name) && !GlobalInfo.traps.ContainsValue(trap.prefabToSpawn))
                {
                    GlobalInfo.traps.Add(trap.prefabToSpawn.name, trap.prefabToSpawn);
                }
            }
        }
        foreach (DungeonFlow dungeonFlow in Resources.FindObjectsOfTypeAll<DungeonFlow>())
        {
            if (dungeonFlow != null && !GlobalInfo.dungeonFlows.ContainsKey(dungeonFlow.name) && !GlobalInfo.dungeonFlows.ContainsValue(dungeonFlow))
            {
                GlobalInfo.dungeonFlows.Add(dungeonFlow.name, dungeonFlow);
            }
        }
        IndoorMapType[] indoorMapTypes = StartOfRoundPatch.RoundManager.dungeonFlowTypes;
        for (int i = 0; i < indoorMapTypes.Length; i++)
        {
            if (indoorMapTypes[i] != null)
            {
                GlobalInfo.dungeonIDs.Add(indoorMapTypes[i].dungeonFlow.name, i);
                Plugin.LogDebug(indoorMapTypes[i].dungeonFlow.name + " = " + i);
            }
        }
        foreach (LevelAmbienceLibrary ambienceLibrary in Resources.FindObjectsOfTypeAll<LevelAmbienceLibrary>())
        {
            if (ambienceLibrary != null && !GlobalInfo.ambienceLibraries.ContainsKey(ambienceLibrary.name) && !GlobalInfo.ambienceLibraries.ContainsValue(ambienceLibrary))
            {
                GlobalInfo.ambienceLibraries.Add(ambienceLibrary.name, ambienceLibrary);
            }
        }
    }

    private static void SetupItems()
    {
        foreach (Item item in Assets.blackLabelItems)
        {
            if (item != null && !StartOfRoundPatch.StartOfRound.allItemsList.itemsList.Contains(item))
            {
                StartOfRoundPatch.StartOfRound.allItemsList.itemsList.Add(item);
            }
        }

        GlobalInfo.items["TrafficCone"].spawnPositionTypes.Add(GlobalInfo.itemGroups["GeneralItemClass"]);
        GlobalInfo.items["Tuba"].spawnPositionTypes.Add(GlobalInfo.itemGroups["GeneralItemClass"]);
        GlobalInfo.items["WineBottle"].spawnPositionTypes.Add(GlobalInfo.itemGroups["TabletopItems"]);
        GlobalInfo.items["Fan"].spawnPositionTypes.Add(GlobalInfo.itemGroups["GeneralItemClass"]);
        GlobalInfo.items["Fan"].spawnPositionTypes.Add(GlobalInfo.itemGroups["TabletopItems"]);
        GlobalInfo.items["Shovel"].weight = 1.08f;
        GlobalInfo.items["StopSign"].weight = 1.2f;
        GlobalInfo.items["Jetpack"].creditsWorth = 700;
    }

    private static void SetupDungeonFlows()
    {
        DungeonFlow level3Flow = GlobalInfo.dungeonFlows["Level3Flow"];
        level3Flow.Length.Min = 10;
        level3Flow.Length.Max = 12;
        level3Flow.Lines[0].Length = 0.35f;
        level3Flow.Lines[1].Position = 0.35f;
        level3Flow.Lines[1].Length = 0.3f;
        level3Flow.Lines[2].Position = 0.65f;
        level3Flow.Lines[2].Length = 0.35f;
    }

    private static void SetupLevels()
    {
        GlobalInfo.blackLabelLevels.AddRange(
        [
            new ExperimentationBlackLabelLevel(),
            new AssuranceBlackLabelLevel(),
            new VowBlackLabelLevel(),
            new MarchBlackLabelLevel(),
            new OffenseBlackLabelLevel(),
            new AdamanceBlackLabelLevel(),
            new RendBlackLabelLevel(),
            new DineBlackLabelLevel(),
            new TitanBlackLabelLevel(),
            new ArtificeBlackLabelLevel(),
            new EmbrionBlackLabelLevel()
        ]);
    }
}