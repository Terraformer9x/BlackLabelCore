using System.Linq;

namespace BlackLabelCore.Levels;

public class RendBlackLabelLevel() : BlackLabelLevel("RendLevel")
{
    public override void SetupLevel()
    {
        level.factorySizeMultiplier = 1.65f;
        
        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Fan"], rarity = 4 },
            new() { spawnableItem = GlobalInfo.items["Toaster"], rarity = 39 },
            new() { spawnableItem = GlobalInfo.items["Briefcase"], rarity = 25 },
            new() { spawnableItem = GlobalInfo.items["WineBottle"], rarity = 45 },
            new() { spawnableItem = GlobalInfo.items["Tophat"], rarity = 21 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 4 },
            new() { spawnableItem = GlobalInfo.items["Tuba"], rarity = 9 },
            new() { spawnableItem = GlobalInfo.items["Wallet"], rarity = 27 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);

        level.dungeonFlowTypes.First(x => x.id == GlobalInfo.dungeonIDs["Level3Flow"]).rarity = 3;
    }
}