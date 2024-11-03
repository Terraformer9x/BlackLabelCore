namespace BlackLabelCore.Levels;

public class VowBlackLabelLevel() : BlackLabelLevel("VowLevel")
{
    public override void SetupLevel()
    {
        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Spatula"], rarity = 22 },
            new() { spawnableItem = GlobalInfo.items["Toaster"], rarity = 27 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 40 },
            new() { spawnableItem = GlobalInfo.items["Fan"], rarity = 15 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);

        level.Enemies.Find(x => x.enemyType.name == "ClaySurgeon").rarity = 3;
        level.Enemies.Add(new () { enemyType = GlobalInfo.enemies["Butler"], rarity = 1 });
    }
}