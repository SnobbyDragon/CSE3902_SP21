using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class EnemyNPCSprites
    {
        Game1 game;
        public EnemyNPCSprites(Game1 game)
        {
            this.game = game;
        }
        public List<ISprite> LoadEnemyNPCSprites()
        {
            List<ISprite> enemyNPCSprites = LoadEnemySprites();
            enemyNPCSprites.AddRange(LoadNPCSprites());
            enemyNPCSprites.AddRange(LoadBossSprites());

            return enemyNPCSprites;
        }

        private List<ISprite> LoadEnemySprites()
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
                enemyFactory.MakeSprite("stalfos", new Vector2(280,350)),
                enemyFactory.MakeSprite("trap", new Vector2(300,350)),
            };
            return enemySprites;
        }

        private List<ISprite> LoadNPCSprites()
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

        private List<ISprite> LoadBossSprites()
        {
            BossesSpriteFactory bossSpriteFactory = new BossesSpriteFactory(game);
            List<ISprite> bossSprites = new List<ISprite>
            {
                bossSpriteFactory.MakeSprite("ganon fireball center", new Vector2(400, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball up", new Vector2(415, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball up left", new Vector2(430, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball left", new Vector2(445, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball down left", new Vector2(460, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball down", new Vector2(475, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball down right", new Vector2(490, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball right", new Vector2(505, 200)),
                bossSpriteFactory.MakeSprite("ganon fireball up right", new Vector2(520, 200)),
                bossSpriteFactory.MakeSprite("orange gohma", new Vector2(420, 420)),
                bossSpriteFactory.MakeSprite("blue gohma", new Vector2(450, 450)),
                bossSpriteFactory.MakeSprite("patra", new Vector2(300, 200)),
                bossSpriteFactory.MakeSprite("manhandla", new Vector2(100,100)),
                bossSpriteFactory.MakeSprite("dodongo", new Vector2(250,100)),
                bossSpriteFactory.MakeSprite("gleeok", new Vector2(290,100)),
                bossSpriteFactory.MakeSprite("ganon", new Vector2(100,150)),
                bossSpriteFactory.MakeSprite("aquamentus", new Vector2(340,100)),
            };
            return bossSprites;
        }
    }
}
