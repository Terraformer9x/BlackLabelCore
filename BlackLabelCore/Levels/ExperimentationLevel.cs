using MonoMod.Utils;
using System.Collections.Generic;

namespace BlackLabelCore.Levels;

public class ExperimentationBlackLabelLevel() : BlackLabelLevel("ExperimentationLevel")
{
    public override void SetupLevel()
    {
        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["TrafficCone"], rarity = 8 },
            new() { spawnableItem = GlobalInfo.items["Stapler"], rarity = 39 },
            new() { spawnableItem = GlobalInfo.items["Wallet"], rarity = 4 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 19 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);
    }
}