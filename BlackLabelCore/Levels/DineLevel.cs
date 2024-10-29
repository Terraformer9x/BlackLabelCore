using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BlackLabelCore.Levels;

public class DineBlackLabelLevel() : BlackLabelLevel("DineLevel")
{
    public override void SetupLevel()
    {
        level.maxScrap = 27;

        level.spawnableScrap.Remove(level.spawnableScrap.Find(x => x.spawnableItem.name == "EasterEgg"));
        level.spawnableScrap.ForEach
        (
            x =>
            {
                switch(x.spawnableItem.name)
                {
                    //case "7Ball": x.rarity = 24; break;
                    //case "Airhorn": x.rarity = 15; break;
                    case "Bell": x.rarity = 48; break;
                    //case "BigBolt": x.rarity = 4; break;
                    //case "BottleBin": x.rarity = 45; break;
                    case "Brush": x.rarity = 20; break;
                    case "Candy": x.rarity = 16; break;
                    case "CashRegister": x.rarity = 13; break;
                    //case "ClownHorn": x.rarity = 12; break;
                    case "Cog1": x.rarity = 6; break;
                    case "ComedyMask": x.rarity = 29; break;
                    case "Dentures": x.rarity = 31; break;
                    case "DiyFlashbang": x.rarity = 10; break;
                    case "EnginePart1": x.rarity = 3; break;
                    //case "FancyCup": x.rarity = 36; break;
                    case "FancyLamp": x.rarity = 49; break;
                    case "FancyPainting": x.rarity = 50; break;
                    case "FishTestProp": x.rarity = 16; break;
                    //case "FlashLaserPointer": x.rarity = 5; break;
                    case "GarbageLid": x.rarity = 9; break;
                    case "GiftBox": x.rarity = 21; break;
                    case "Hairdryer": x.rarity = 43; break;
                    case "MagnifyingGlass": x.rarity = 35; break;
                    //case "Mug": x.rarity = 48; break;
                    case "PerfumeBottle": x.rarity = 28; break;
                    case "Phone": x.rarity = 17; break;
                    case "PickleJar": x.rarity = 9; break;
                    case "PillBottle": x.rarity = 4; break;
                    case "Ring": x.rarity = 19; break;
                    case "RobotToy": x.rarity = 46; break;
                    case "RubberDuck": x.rarity = 16; break;
                    case "SodaCanRed": x.rarity = 26; break;
                    case "TeaKettle": x.rarity = 25; break;
                    case "ToiletPaperRolls": x.rarity = 8; break;
                    case "Toothpaste": x.rarity = 24; break;
                    //case "ToyCube": x.rarity = 33; break;
                    case "TragedyMask": x.rarity = 37; break;
                    case "WhoopieCushion": x.rarity = 18; break;
                    //case "Zeddog": x.rarity = 1; break;
                }
            }
        );
        level.spawnableScrap.AddRange(
        [
            new() { spawnableItem = GlobalInfo.items["Fan"], rarity = 13 },
            new() { spawnableItem = GlobalInfo.items["Toaster"], rarity = 16 },
            new() { spawnableItem = GlobalInfo.items["Briefcase"], rarity = 30 },
            new() { spawnableItem = GlobalInfo.items["WineBottle"], rarity = 34 },
            new() { spawnableItem = GlobalInfo.items["Tophat"], rarity = 7 },
            new() { spawnableItem = GlobalInfo.items["Bucket"], rarity = 3 },
            new() { spawnableItem = GlobalInfo.items["Tuba"], rarity = 12 },
            new() { spawnableItem = GlobalInfo.items["Wallet"], rarity = 13 },
            new() { spawnableItem = GlobalInfo.items["Boot"], rarity = 1 }
        ]);

        level.maxEnemyPowerCount = 15;
        level.maxOutsideEnemyPowerCount = 8;
        level.Enemies.ForEach
        (
            x =>
            {
                switch (x.enemyType.name)
                {
                    case "Blob": x.rarity = 39; break;
                    case "Centipede": x.rarity = 52; break;
                    case "Crawler": x.rarity = 48; break;
                    case "DressGirl": x.rarity = 18; break;
                    case "Flowerman": x.rarity = 25; break;
                    case "HoarderBug": x.rarity = 48; break;
                    case "Jester": x.rarity = 66; break;
                    case "Nutcracker": x.rarity = 60; break;
                    case "Puffer": x.rarity = 16; break;
                    case "SandSpider": x.rarity = 64; break;
                    case "SpringMan": x.rarity = 53; break;
                    case "Butler": x.rarity = 100; break;
                    case "ClaySurgeon": x.rarity = 34; break;
                    case "CaveDweller": x.rarity = 6; break;
                }
            }
        );
        level.OutsideEnemies.ForEach
        (
            x =>
            {
                switch (x.enemyType.name)
                {
                    case "ForestGiant": x.rarity = 31; break;
                    case "MouthDog": x.rarity = 68; break;
                    case "RadMech": x.rarity = 11; break;
                    case "SandWorm": x.rarity = 50; break;
                }
            }
        );
        level.outsideEnemySpawnChanceThroughDay = new AnimationCurve
        (
            new()
            {
                time = -7.7369623E-07f,
                value = -2.8875f,
                inTangent = Mathf.Infinity,
                outTangent = -1.0600616f,
                weightedMode = WeightedMode.Both,
                inWeight = 0f,
                outWeight = 0.14093608f
            },
            new()
            {
                time = 0.5432813f,
                value = 0.055187404f,
                inTangent = 9.172262f,
                outTangent = 9.172262f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.33333334f,
                outWeight = 0.71965504f
            },
            new()
            {
                time = 1f,
                value = 0.055187404f,
                inTangent = 5.3594007f,
                outTangent = 16.256857f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.25347674f,
                outWeight = 0.48315445f
            }
        )
        {
            preWrapMode = WrapMode.Loop,
            postWrapMode = WrapMode.Loop
        };
        
        level.spawnableMapObjects.First(x => x.prefabToSpawn.name == "Landmine").numberToSpawn = new AnimationCurve
        (
            new()
            {
                time = 0f,
                value = 0f,
                inTangent = 0.35461718f,
                outTangent = 0.35461718f,
                weightedMode = WeightedMode.Out,
                inWeight = 0f,
                outWeight = 0.31411442f
            },
            new()
            {
                time = 0.33f,
                value = 1.6f,
                inTangent = 9.622354f,
                outTangent = 9.622354f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.3329991f,
                outWeight = 0.37682974f
            },
            new()
            {
                time = 0.75f,
                value = 15.25f,
                inTangent = 17.336048f,
                outTangent = 17.336048f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.3517064f,
                outWeight = 0.70731705f
            },
            new()
            {
                time = 1f,
                value = 35f,
                inTangent = 2.1870255f,
                outTangent = 2.1870255f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.47984266f,
                outWeight = 0f
            }
        )
        {
            preWrapMode = WrapMode.Loop,
            postWrapMode = WrapMode.Loop
        };

        level.spawnableMapObjects.First(x => x.prefabToSpawn.name == "TurretContainer").numberToSpawn = new AnimationCurve
        (
            new()
            {
                time = 0f,
                value = 0.25f,
                inTangent = -0.082629666f,
                outTangent = -0.082629666f,
                weightedMode = WeightedMode.Both,
                inWeight = 0f,
                outWeight = 0.08271725f
            },
            new()
            {
                time = 0.35f,
                value = 1.65f,
                inTangent = 0.84200466f,
                outTangent = 0.84200466f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.1623793f,
                outWeight = 0.11892447f
            },
            new()
            {
                time = 0.8f,
                value = 11.25f,
                inTangent = 5.785181f,
                outTangent = 5.785181f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.10231435f,
                outWeight = 0.33333334f
            },
            new()
            {
                time = 1f,
                value = 18f,
                inTangent = 4.8281865f,
                outTangent = 4.8281865f,
                weightedMode = WeightedMode.Both,
                inWeight = 0.42531443f,
                outWeight = 0f
            }
        )
        {
            preWrapMode = WrapMode.Loop,
            postWrapMode = WrapMode.Loop
        };

        level.dungeonFlowTypes.First(x => x.id == GlobalInfo.dungeonIDs["Level3Flow"]).rarity = 27;
    }
}