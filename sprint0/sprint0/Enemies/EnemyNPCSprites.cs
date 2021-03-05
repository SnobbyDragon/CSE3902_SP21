using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;


//Author: Stuti Shah
namespace sprint0
{
    public class EnemyNPCSprites
    {
        Game1 game;
        public EnemyNPCSprites(Game1 game)
        {
            this.game = game;
        }
        public List<ISprite> LoadEnemyNPCSprites() //loads all sprites
        {
            List<ISprite> enemyNPCSprites = LoadEnemySprites();
            enemyNPCSprites.AddRange(LoadNPCSprites());
            enemyNPCSprites.AddRange(LoadBossSprites());

            return enemyNPCSprites;
        }

        private List<ISprite> LoadEnemySprites() //loads enemy sprites
        {
            EnemiesSpriteFactory enemyFactory = new EnemiesSpriteFactory(game);
            List<ISprite> enemySprites = new List<ISprite>
            {
                enemyFactory.MakeSprite("wallmaster", new Vector2(20,300)),
                enemyFactory.MakeSprite("teal gel", new Vector2(40,300)),
                enemyFactory.MakeSprite("blue gel", new Vector2(60,300)),
                enemyFactory.MakeSprite("green gel", new Vector2(80,300)),
                enemyFactory.MakeSprite("blkgold gel", new Vector2(100,300)),
                enemyFactory.MakeSprite("lime gel", new Vector2(120,300)),
                enemyFactory.MakeSprite("brown gel", new Vector2(140,300)),
                enemyFactory.MakeSprite("grey gel", new Vector2(20,350)),
                enemyFactory.MakeSprite("blkwhite gel", new Vector2(40,350)),
                enemyFactory.MakeSprite("green zol", new Vector2(60,350)),
                enemyFactory.MakeSprite("blkgold zol", new Vector2(80,350)),
                enemyFactory.MakeSprite("lime zol", new Vector2(100,350)),
                enemyFactory.MakeSprite("brown zol", new Vector2(120,350)),
                enemyFactory.MakeSprite("grey zol", new Vector2(140,350)),
                enemyFactory.MakeSprite("blkwhite zol", new Vector2(160,350)),
                enemyFactory.MakeSprite("snake", new Vector2(180,350)),
                enemyFactory.MakeSprite("red goriya", new Vector2(200,350)),
                enemyFactory.MakeSprite("blue goriya", new Vector2(220,350)),
                enemyFactory.MakeSprite("red keese", new Vector2(240,350)),
                enemyFactory.MakeSprite("blue keese", new Vector2(260,350)),
                enemyFactory.MakeSprite("stalfos", new Vector2(280,400)),
                enemyFactory.MakeSprite("trap", new Vector2(300,350)),
                enemyFactory.MakeSprite("goriya boomerang horizontal", new Vector2(320,350)),
                enemyFactory.MakeSprite("goriya boomerang vertical", new Vector2(320,350)),
                enemyFactory.MakeSprite("goriya boomerang diagonal", new Vector2(320,350))
            };
            return enemySprites;
        }

        private List<ISprite> LoadNPCSprites() //loads npc sprites
        {
            NpcsSpriteFactory npcFactory = new NpcsSpriteFactory(game);
            List<ISprite> npcSprites = new List<ISprite>
            {
                npcFactory.MakeSprite("flame", new Vector2(320,350)),
                npcFactory.MakeSprite("green merchant", new Vector2(340,350)),
                npcFactory.MakeSprite("white merchant", new Vector2(360,350)),
                npcFactory.MakeSprite("red merchant", new Vector2(380,350)),
                npcFactory.MakeSprite("old man 1", new Vector2(400,350)),
                npcFactory.MakeSprite("old man 2", new Vector2(420,350)),
                npcFactory.MakeSprite("old woman", new Vector2(440,350)),
            };
            return npcSprites;
        }

        private List<ISprite> LoadBossSprites() //loads boss sprites
        {
            BossesSpriteFactory bossSpriteFactory = new BossesSpriteFactory(game);
            List<ISprite> bossSprites = new List<ISprite>
            {
                bossSpriteFactory.MakeSprite("orange gohma", new Vector2(300, 300)),
                bossSpriteFactory.MakeSprite("blue gohma", new Vector2(300, 300)),
                bossSpriteFactory.MakeSprite("patra", new Vector2(300, 300)),
                bossSpriteFactory.MakeSprite("manhandla", new Vector2(100,300)),
                bossSpriteFactory.MakeSprite("dodongo", new Vector2(250,300)),
                bossSpriteFactory.MakeSprite("gleeok", new Vector2(290,300)),
                bossSpriteFactory.MakeSprite("ganon", new Vector2(100,300)),
                bossSpriteFactory.MakeSprite("aquamentus", new Vector2(340,300)),
                bossSpriteFactory.MakeSprite("digdogger", new Vector2(340,300))
            };
            return bossSprites;
        }
    }
}
