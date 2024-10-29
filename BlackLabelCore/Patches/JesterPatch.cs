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
}