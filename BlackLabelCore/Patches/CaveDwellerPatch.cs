using BlackLabelCore;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;

[HarmonyPatch(typeof(CaveDwellerAI))]
internal class CaveDwellerPatch
{
    [HarmonyPatch("HitEnemy")]
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> ManeaterDamagePatch(IEnumerable<CodeInstruction> instructions)
    {
        if(Compatibility.ManeaterDamagePatch)
        {
            Plugin.LogWarning("Maneater Damage Patch detected loading, preventing BLC patch!");
            return instructions;
        }
        CodeMatcher codeMatcher = new CodeMatcher(instructions)
            .MatchForward(false,
                new CodeMatch(OpCodes.Ldc_I4_1)
            )
            .SetInstruction(
                new CodeInstruction(OpCodes.Ldarg_1)
            );

        return codeMatcher.InstructionEnumeration();
    }
}