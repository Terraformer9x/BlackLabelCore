using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace BlackLabelCore.Patches;

[HarmonyPatch(typeof(StormyWeather))]
internal class StormyPatch
{
    [HarmonyPatch("Update")]
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> UpdatePatch(IEnumerable<CodeInstruction> instructions)
    {
        List<CodeInstruction> list = instructions.ToList();
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i].opcode == OpCodes.Ldc_R4 && (float)list[i].operand == 1f && list[i + 1].opcode == OpCodes.Ldc_R4 && (float)list[i + 1].operand == 28f)
            {
                list[i + 1] = new CodeInstruction(OpCodes.Ldc_R4, 35f);
                list[i + 4] = new CodeInstruction(OpCodes.Ldc_R4, 25f);
            }
            if (list[i].opcode == OpCodes.Ldc_R4 && (float)list[i].operand == 4f && list[i + 1].opcode == OpCodes.Ldc_R4 && (float)list[i + 1].operand == 20f)
            {
                list[i] = new CodeInstruction(OpCodes.Ldc_R4, 8f);
                list[i + 1] = new CodeInstruction(OpCodes.Ldc_R4, 25f);
                break;
            }
        }
        return list;
    }
}