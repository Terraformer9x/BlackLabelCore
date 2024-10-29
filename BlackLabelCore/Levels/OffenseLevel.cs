using System.Collections.Generic;

namespace BlackLabelCore.Levels;

public class OffenseBlackLabelLevel() : BlackLabelLevel("OffenseLevel")
{
    public override void SetupLevel()
    {
        level.minScrap = 15;
        level.maxScrap = 18;

        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.ForEach
        (
            x =>
            {
                switch (x.spawnableItem.name)
                {
                    case "BigBolt": x.rarity = 49; break;
                    case "BottleBin": x.rarity = 43; break;
                    case "Cog1": x.rarity = 67; break;
                    case "MetalSheet": x.rarity = 52; break;
                }
            }
        );
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Bell"], rarity = 20 },
            new() { spawnableItem = GlobalInfo.items["PickleJar"], rarity = 11 },
            new() { spawnableItem = GlobalInfo.items["SteeringWheel"], rarity = 14 },
            new() { spawnableItem = GlobalInfo.items["Hairdryer"], rarity = 8 },
            new() { spawnableItem = GlobalInfo.items["SodaCanRed"], rarity = 3 },
            new() { spawnableItem = GlobalInfo.items["Mug"], rarity = 6 },
            new() { spawnableItem = GlobalInfo.items["EggBeater"], rarity = 15 },
            new() { spawnableItem = GlobalInfo.items["Spatula"], rarity = 17 },
            new() { spawnableItem = GlobalInfo.items["TrafficCone"], rarity = 29 },
            new() { spawnableItem = GlobalInfo.items["Fan"], rarity = 16 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 29 },
            new() { spawnableItem = GlobalInfo.items["Stapler"], rarity = 13 },
            new() { spawnableItem = GlobalInfo.items["Toaster"], rarity = 8 },
            new() { spawnableItem = GlobalInfo.items["Wallet"], rarity = 3 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);
    }
}