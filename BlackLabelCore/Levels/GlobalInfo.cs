using DunGen.Graph;
using System.Collections.Generic;
using UnityEngine;

namespace BlackLabelCore.Levels;

internal class GlobalInfo
{
    internal static Dictionary<string, SelectableLevel> levels = [];
    internal static Dictionary<string, Item> items = [];
    internal static Dictionary<string, ItemGroup> itemGroups = [];
    internal static Dictionary<string, EnemyType> enemies = [];
    internal static Dictionary<string, GameObject> traps = [];
    internal static Dictionary<string, DungeonFlow> dungeonFlows = [];
    internal static Dictionary<string, int> dungeonIDs = [];
    internal static Dictionary<string, LevelAmbienceLibrary> ambienceLibraries = [];
    internal static List<BlackLabelLevel> blackLabelLevels = [];
}

public class BlackLabelLevel
{
    public static SelectableLevel level;

    public BlackLabelLevel(string levelName)
    {
        level = GlobalInfo.levels[levelName];
        SetupLevel();
    }

    public virtual void SetupLevel() { }
}