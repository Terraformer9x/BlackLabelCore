using System.Collections.Generic;

namespace BlackLabelCore.Levels;

public class AdamanceBlackLabelLevel() : BlackLabelLevel("AdamanceLevel")
{
    public override void SetupLevel()
    {
        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Hairdryer"], rarity = 10 },
            new() { spawnableItem = GlobalInfo.items["ComedyMask"], rarity = 6 },
            new() { spawnableItem = GlobalInfo.items["TragedyMask"], rarity = 5 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 27 },
            new() { spawnableItem = GlobalInfo.items["Fan"], rarity = 22 },
            new() { spawnableItem = GlobalInfo.items["Spatula"], rarity = 40 },
            new() { spawnableItem = GlobalInfo.items["Toaster"], rarity = 30 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);
    }
}