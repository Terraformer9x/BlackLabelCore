using HarmonyLib;
using UnityEngine;

namespace BlackLabelCore.Patches;

[HarmonyPatch(typeof(JesterAI))]
internal class JesterPatch
{
    [HarmonyPatch("SetJesterInitialValues")]
    [HarmonyPostfix]
    private static void ChangeJesterTimer(ref JesterAI __instance)
    {
        __instance.beginCrankingTimer = Random.Range(25f, 42f);
    }

    [HarmonyPatch("Update")]
    [HarmonyPostfix]
    private static void SlamOpenDoors(ref JesterAI __instance)
    {
        if (Compatibility.JesterDoorSlam)
        {
            Plugin.LogWarning("JesterDoorSlam detected! Preventing BLC postfix...");
            return;
        }
        if (__instance.currentBehaviourStateIndex == 2 && __instance.agent.speed >= 10f)
        {
            __instance.useSecondaryAudiosOnAnimatedObjects = true;
        }
        else
        {
            __instance.useSecondaryAudiosOnAnimatedObjects = false;
        }
    }
}