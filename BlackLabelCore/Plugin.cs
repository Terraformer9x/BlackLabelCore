using BepInEx;
using HarmonyLib;
using UnityEngine;
using System;
using System.IO;
using System.Reflection;
using BepInEx.Bootstrap;

namespace BlackLabelCore;

[BepInPlugin(Plugin.pluginGUID, Plugin.pluginName, Plugin.pluginVersion)]
public class Plugin : BaseUnityPlugin
{
    private const string pluginGUID = "terraformer9x.BlackLabelCore";
    private const string pluginName = "Black Label Core";
    private const string pluginVersion = "1.0.0";
    public const int pluginVersionNum = 1;

    private readonly Harmony harmony = new(pluginGUID);
    public static Plugin Instance;
    
    private void Awake()
    {
        Instance ??= this;

        Logger.LogInfo($"Plugin {pluginName} {pluginVersion}  is loaded!");

        Logger.LogInfo("Loading Black Label Assets");
        try
        {
            Assets.LoadAssets();
        }
        catch (Exception e)
        {
            Logger.LogError(e.Message + " - Failed to load Black Label assets!");
        }

        BlackLabelCoreConfig.Bind(base.Config);
        Logger.LogInfo("Applying Black Label Patches");
        harmony.PatchAll();
        Logger.LogInfo("Black Label Patches Applied");
    }

    public static void Log(string msg) => Instance.Logger.LogInfo(msg);
    public static void LogError(string msg) => Instance.Logger.LogError(msg);
    public static void LogWarning(string msg) => Instance.Logger.LogWarning(msg);
    public static void LogDebug(string msg) => Instance.Logger.LogDebug(msg);
}

internal static class Assets
{
    internal static AssetBundle assetBundle;
    internal static Sprite blackLabelLogo;
    internal static Item[] blackLabelItems;
    internal static Mesh waterTileCollision, dineNewSurfaceMesh, dineMetalWallMesh;
    internal static GameObject dineTreeNearFire, dineLeavesNearFire;

    internal static void LoadAssets()
    {
        try
        {
            assetBundle = AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "blacklabelassets"));
            blackLabelLogo = assetBundle.LoadAsset<Sprite>("LogoTextBL");
            blackLabelItems = assetBundle.LoadAllAssets<Item>();
            waterTileCollision = assetBundle.LoadAsset<Mesh>("WaterTileCollision");
            dineNewSurfaceMesh = assetBundle.LoadAsset<Mesh>("DineHybridTerrain");
            dineMetalWallMesh = assetBundle.LoadAsset<Mesh>("DineMetalWall");
            dineTreeNearFire = assetBundle.LoadAsset<GameObject>("DineNearFireTree");
            dineLeavesNearFire = assetBundle.LoadAsset<GameObject>("DineNearFireLeaves");
            assetBundle.Unload(false);
        }
        catch (Exception e)
        {
            Plugin.LogError(e.Message + " - Failed to load mod assets!");
            return;
        }
    }
}

internal static class Compatibility
{
    internal static bool LethalLevelLoader = Chainloader.PluginInfos.ContainsKey("imabatby.lethallevelloader");
    internal static bool Chameleon = Chainloader.PluginInfos.ContainsKey("butterystancakes.lethalcompany.chameleon");
    internal static bool TonightWeDine = Chainloader.PluginInfos.ContainsKey("TonightWeDine");
}