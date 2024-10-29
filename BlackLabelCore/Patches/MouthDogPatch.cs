using HarmonyLib;

namespace BlackLabelCore.Patches;

[HarmonyPatch(typeof(MouthDogAI))]
internal class MouthDogPatch
{
    [HarmonyPatch("Start")]
    [HarmonyPostfix]
    private static void ChangeDogHealth(MouthDogAI __instance)
    {
        __instance.enemyHP = 10;
    }
}