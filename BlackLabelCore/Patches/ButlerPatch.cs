using HarmonyLib;

namespace BlackLabelCore.Patches;

[HarmonyPatch(typeof(ButlerEnemyAI))]
internal class ButlerPatch
{
    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    private static void ChangeButlerHealth(ButlerEnemyAI __instance)
    {
        if (StartOfRound.Instance.connectedPlayersAmount > 0)
        {
            __instance.enemyHP = 4;
        }
    }
}