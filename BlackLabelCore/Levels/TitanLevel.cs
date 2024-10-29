using System.Collections.Generic;
using System.Linq;

namespace BlackLabelCore.Levels;

public class TitanBlackLabelLevel() : BlackLabelLevel("TitanLevel")
{
    public override void SetupLevel()
    {
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Toaster"], rarity = 8 },
            new() { spawnableItem = GlobalInfo.items["WineBottle"], rarity = 33 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 18 },
            new() { spawnableItem = GlobalInfo.items["Wallet"], rarity = 15 },
            new() { spawnableItem = GlobalInfo.items["GoldenBolt"], rarity = 10 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);

        level.dungeonFlowTypes.First(x => x.id == GlobalInfo.dungeonIDs["Level2Flow"]).rarity = 60;
        level.dungeonFlowTypes.First(x => x.id == GlobalInfo.dungeonIDs["Level3Flow"]).rarity = 20;
    }
}