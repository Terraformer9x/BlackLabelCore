using HarmonyLib;
using Unity.Netcode;

namespace BlackLabelCore.Patches;

[HarmonyPatch(typeof(GameNetworkManager))]
internal class GameNetworkManagerPatch
{
    static private bool executed = false;

    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    private static void GameNetworkManagerPostfix(ref GameNetworkManager __instance)
    {
        if (executed) return;
        foreach (Item item in Assets.blackLabelItems)
        {
            __instance.GetComponent<NetworkManager>().AddNetworkPrefab(item.spawnPrefab);
        }
        executed = true;
    }
}