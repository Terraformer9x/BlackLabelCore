using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlackLabelCore.Levels;

public class ArtificeBlackLabelLevel() : BlackLabelLevel("ArtificeLevel")
{
    public override void SetupLevel()
    {
        level.minScrap = 31;
        level.maxScrap = 37;
        level.factorySizeMultiplier = 2.0f;

        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Wallet"], rarity = 25 },
            new() { spawnableItem = GlobalInfo.items["Briefcase"], rarity = 17 },
            new() { spawnableItem = GlobalInfo.items["Fan"], rarity = 13 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 35 },
            new() { spawnableItem = GlobalInfo.items["WineBottle"], rarity = 40 },
            new() { spawnableItem = GlobalInfo.items["Toaster"], rarity = 27 },
            new() { spawnableItem = GlobalInfo.items["Tophat"], rarity = 22 },
            new() { spawnableItem = GlobalInfo.items["Tuba"], rarity = 19 },
            new() { spawnableItem = GlobalInfo.items["TrafficCone"], rarity = 9 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);


        level.enemySpawnChanceThroughoutDay = new AnimationCurve
        (
            new()
            {
                time = 0f,
                value = -3f,
                inTangent = 59.199333f,
                outTangent = 59.199333f,
                weightedMode = WeightedMode.Both,
                inWeight = 0f,
                outWeight = 0.18829483f
            },
            new()
            {
                time = 0.16255526f,
                value = 1.1420287f,
                inTangent = 9.178675f,
                outTangent = 9.178675f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.65918964f,
                outWeight = 0.43745992f
            },
            new()
            {
                time = 0.7631003f,
                value = 11.275558f,
                inTangent = 25.289257f,
                outTangent = 25.289257f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.41667995f,
                outWeight = 0.5360636f
            },
            new()
            {
                time = 1f,
                value = 15f,
                inTangent = 35.604027f,
                outTangent = 35.604027f,
                weightedMode = WeightedMode.In,
                inWeight = 0.04912584f,
                outWeight = 0f
            }
        )
        {
            preWrapMode = WrapMode.Loop,
            postWrapMode = WrapMode.Loop
        };

        level.dungeonFlowTypes.First(x => x.id == GlobalInfo.dungeonIDs["Level2Flow"]).rarity = 300;
        level.dungeonFlowTypes.First(x => x.id == GlobalInfo.dungeonIDs["Level1Flow"]).rarity = 50;
        level.dungeonFlowTypes.First(x => x.id == GlobalInfo.dungeonIDs["Level3Flow"]).rarity = 50;
    }
}