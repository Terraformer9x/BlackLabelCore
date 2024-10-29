using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace BlackLabelCore.Patches;

[HarmonyPatch(typeof(NutcrackerEnemyAI))]
internal class NutcrackerPatch
{
    [HarmonyPatch("AimGun", MethodType.Enumerator)]
    [HarmonyTranspiler]
    private static IEnumerable<CodeInstruction> AimGunPatch(IEnumerable<CodeInstruction> instructions)
    {
        bool PatchedFirstVolley = false;

        List<CodeInstruction> list = instructions.ToList();
        for(int i = 0; i < list.Count - 1; i++)
        {
            if (list[i + 1].opcode == OpCodes.Ldc_R4 && (float)list[i + 1].operand == 1.3f && !PatchedFirstVolley)
            {
                list.Insert(i + 1, new CodeInstruction(OpCodes.Ldloc_1));
                list.Insert(i + 2, new CodeInstruction(OpCodes.Ldloc_1));
                list.Insert(i + 4, new CodeInstruction(OpCodes.Ldc_R4, 1f));
                list.Insert(i + 5, new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(NutcrackerPatch), "ChangeAimTime")));
                PatchedFirstVolley = true;
            }
            if (list[i + 1].opcode == OpCodes.Ldc_R4 && (float)list[i + 1].operand == 1.75f)
            {
                list.Insert(i + 1, new CodeInstruction(OpCodes.Ldloc_1));
                list.Insert(i + 2, new CodeInstruction(OpCodes.Ldloc_1));
                list.Insert(i + 4, new CodeInstruction(OpCodes.Ldc_R4, 1.3f));
                list.Insert(i + 5, new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(NutcrackerPatch), "ChangeAimTime")));
                break;
            }
        }

        return list;
    }

    public float ChangeAimTime(NutcrackerEnemyAI ai, float aimTime, float changeTime)
    {
        return ai.enemyHP <= 3 ? changeTime : aimTime;
    }
}