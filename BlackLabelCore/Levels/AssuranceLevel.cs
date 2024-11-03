namespace BlackLabelCore.Levels;

public class AssuranceBlackLabelLevel() : BlackLabelLevel("AssuranceLevel")
{
    public override void SetupLevel()
    {
        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.Find(x => x.spawnableItem.name == "EggBeater").rarity = 23;
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Spatula"], rarity = 21 },
            new() { spawnableItem = GlobalInfo.items["Fan"], rarity = 18 },
            new() { spawnableItem = GlobalInfo.items["Stapler"], rarity = 15 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 42 },
            new() { spawnableItem = GlobalInfo.items["Toaster"], rarity = 21 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);

        level.Enemies.Remove(level.Enemies.Find(x => x.enemyType.name == "CaveDweller"));
    }
}