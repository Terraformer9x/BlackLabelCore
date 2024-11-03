namespace BlackLabelCore.Levels;

public class EmbrionBlackLabelLevel() : BlackLabelLevel("EmbrionLevel")
{
    public override void SetupLevel()
    {
        level.maxScrap = 24;

        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Bell"], rarity = 21 },
            new() { spawnableItem = GlobalInfo.items["Clock"], rarity = 12 },
            new() { spawnableItem = GlobalInfo.items["Flask"], rarity = 7 },
            new() { spawnableItem = GlobalInfo.items["DustPan"], rarity = 12 },
            new() { spawnableItem = GlobalInfo.items["SodaCanRed"], rarity = 5 },
            new() { spawnableItem = GlobalInfo.items["Mug"], rarity = 35 },
            new() { spawnableItem = GlobalInfo.items["ToyTrain"], rarity = 2 },
            new() { spawnableItem = GlobalInfo.items["SteeringWheel"], rarity = 38 },
            new() { spawnableItem = GlobalInfo.items["GarbageLid"], rarity = 29 },
            new() { spawnableItem = GlobalInfo.items["Hairdryer"], rarity = 11 },
            new() { spawnableItem = GlobalInfo.items["EggBeater"], rarity = 23 },
            new() { spawnableItem = GlobalInfo.items["PlasticCup"], rarity = 42 },
            new() { spawnableItem = GlobalInfo.items["Fan"], rarity = 39 },
            new() { spawnableItem = GlobalInfo.items["Wallet"], rarity = 40 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 54 },
            new() { spawnableItem = GlobalInfo.items["Spatula"], rarity = 35 },
            new() { spawnableItem = GlobalInfo.items["TrafficCone"], rarity = 51 },
            new() { spawnableItem = GlobalInfo.items["GoldenBolt"], rarity = 5 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 2 }
        ]);
    }
}