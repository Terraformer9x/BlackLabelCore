using BepInEx.Logging;
using BlackLabelCore;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

namespace BlackLabelCore.Patches;

[HarmonyPatch(typeof(MenuManager))]
internal class MenuManagerPatch
{
    [HarmonyPatch("Awake")]
    [HarmonyPriority(500)]
    [HarmonyPostfix]
    private static void ChangeLogo(MenuManager __instance)
    {
        if (BlackLabelCoreConfig.changeMenu.Value)
        {
            Image mainHeader = GameObject.Find("MenuContainer/MainButtons/HeaderImage")?.GetComponent<Image>();
            if (mainHeader != null)
            {
                mainHeader.sprite = Assets.blackLabelLogo;
            }

            Image loadingScreen = GameObject.Find("MenuContainer")?.transform.Find("LoadingScreen/Image")?.GetComponent<Image>();
            if (loadingScreen != null)
            {
                loadingScreen.sprite = Assets.blackLabelLogo;
            }
        }

        if (__instance.launchedInLanModeText != null)
        {
            __instance.launchedInLanModeText.rectTransform.anchoredPosition3D = new Vector3(96f, __instance.launchedInLanModeText.rectTransform.anchoredPosition3D.y, __instance.launchedInLanModeText.rectTransform.anchoredPosition3D.z);
        }

        if (__instance.versionNumberText != null)
        {
            __instance.versionNumberText.text = __instance.versionNumberText.text + "-BL" + Plugin.pluginVersionNum;
            __instance.versionNumberText.margin = new Vector4(0, 0, -300, 0);
        }
    }
}