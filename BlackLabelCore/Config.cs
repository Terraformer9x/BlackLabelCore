using BepInEx.Configuration;

namespace BlackLabelCore;

internal class BlackLabelCoreConfig
{
    internal static ConfigEntry<bool> changeMenu;

    public static void Bind(ConfigFile config)
    {
        changeMenu = config.Bind(
            "Black Label",
            "Title Change",
            true,
            "Toggles the Black Label menu pic.\n\n" +
            "Will change upon the main menu being reloaded."
        );
    }
}
