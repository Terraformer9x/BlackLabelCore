﻿using BlackLabelCore.Levels;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine.Rendering.VirtualTexturing;

namespace BlackLabelCore.Patches;

[HarmonyPatch(typeof(RoundManager))]
internal class RoundManagerPatch
{
    [HarmonyPatch("SpawnScrapInLevel")]
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> ChangeMineshaftAmount(IEnumerable<CodeInstruction> instructions)
    {
        CodeMatcher codeMatcher = new CodeMatcher(instructions)
            .MatchForward(true,
                new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(RoundManager), "currentDungeonType"))
            )
            .MatchForward(false,
                new CodeMatch(OpCodes.Ldc_I4_6)
            )
            .SetInstruction(
                new CodeInstruction(OpCodes.Ldc_I4_0)
            );

        return codeMatcher.InstructionEnumeration();
    }


    [HarmonyPatch("RefreshEnemiesList")]
    [HarmonyPostfix]
    private static void PreventEnemyRushPatch(RoundManager __instance)
    {
        if((int)typeof(RoundManager).GetField("enemyRushIndex", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(__instance) >= 0 && !StartOfRound.Instance.isChallengeFile)
        {
            typeof(RoundManager).GetField("enemyRushIndex", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(__instance, -1);
            __instance.currentMaxInsidePower = (float)__instance.currentLevel.maxEnemyPowerCount;
            Plugin.LogDebug("Prevented an enemy rush, enemy power is reset back to " + __instance.currentMaxInsidePower);
        }
    }
}