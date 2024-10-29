using System.Collections.Generic;

namespace BlackLabelCore.Levels;

public class MarchBlackLabelLevel() : BlackLabelLevel("MarchLevel")
{
    public override void SetupLevel()
    {
        level.minScrap = 14;
        level.maxScrap = 17;

        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Bell"], rarity = 31 },
            new() { spawnableItem = GlobalInfo.items["Phone"], rarity = 6 },
            new() { spawnableItem = GlobalInfo.items["Brush"], rarity = 35 },
            new() { spawnableItem = GlobalInfo.items["DiyFlashbang"], rarity = 12 },
            new() { spawnableItem = GlobalInfo.items["RubberDuck"], rarity = 24 },
            new() { spawnableItem = GlobalInfo.items["ChemicalJug"], rarity = 37 },
            new() { spawnableItem = GlobalInfo.items["EggBeater"], rarity = 49 },
            new() { spawnableItem = GlobalInfo.items["PickleJar"], rarity = 22 },
            new() { spawnableItem = GlobalInfo.items["Toaster"], rarity = 37 },
            new() { spawnableItem = GlobalInfo.items["Fan"], rarity = 19 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 48 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);

        level.dungeonFlowTypes = new List<IntWithRarity>()
        {
            new() { id = GlobalInfo.dungeonIDs["Level1Flow3Exits"], rarity = 300 },
            new() { id = GlobalInfo.dungeonIDs["Level2Flow"], rarity = 4 },
            new() { id = GlobalInfo.dungeonIDs["Level3Flow"], rarity = 15, overrideLevelAmbience = GlobalInfo.ambienceLibraries["Level1TypeAmbienceMineshaft"] }
        }.ToArray();
    }
}