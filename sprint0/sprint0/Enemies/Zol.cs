using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Zol : AbstractEnemy
    {
        private int delay;
        private int delayCounter;
        private int spawnCounter;
        private readonly int spawnRate = 1500;
        private readonly int speed = 3;
        private readonly Dictionary<Color, List<Rectangle>> colorMap;
        private readonly Color color;
        private int pauseCount = 0;
        public new EnemyType Type { get => EnemyType.Gel; }

        public Zol(Texture2D texture, Vector2 location, Color gelColor, Game1 game) : base(texture, location, game)
        {
            width = 16;
            height = 16;
            repeatedFrames = 10;
            health = 4;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            color = gelColor;
            delay = 5;
            delayCounter = 0;
            damage = 2;
            colorMap = new Dictionary<Color, List<Rectangle>>
            {
                { Color.Green, SpritesheetHelper.GetFramesH(77, 11, width, height, totalFrames) },
                { Color.Gold, SpritesheetHelper.GetFramesH(111, 11, width, height, totalFrames) },
                { Color.Lime, SpritesheetHelper.GetFramesH(145, 11, width, height, totalFrames) },
                { Color.Brown, SpritesheetHelper.GetFramesH(77, 28, width, height, totalFrames) },
                { Color.Gray, SpritesheetHelper.GetFramesH(111, 28, width, height, totalFrames) },
                { Color.White, SpritesheetHelper.GetFramesH(145, 28, width, height, totalFrames) },
            };
            spawnCounter = spawnRate / 4;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            if (damageTimer % 2 == 0)
                spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames], Color.White);
        }

        public override void Update()
        {

            if (damageTimer > 0) damageTimer--;
            CheckHealth();
            moveCounter++;
            SpawnGel();

            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);

            if (pauseCount == 0)
            {
                if (moveCounter == dirChangeDelay)
                {
                    ArbitraryDirection(20, 80);
                    pauseCount = 3 * totalFrames * repeatedFrames;
                }
                if (delayCounter == delay)
                {
                    Rectangle loc = Location;
                    loc.Offset(speed * direction.ToVector2());
                    Location = loc;
                    delayCounter = 0;
                }
                delayCounter++;
            }
            else
                pauseCount--;
        }

        private void SpawnGel()
        {
            if (spawnCounter == spawnRate)
            {
                Vector2 spawnLoc = Location.Location.ToVector2() + new Vector2(-1, 0);
                game.Room.LoadLevel.RoomEnemies.AddEnemy(spawnLoc, ParseEnemy(color.GetName() + "gel"));
                spawnCounter = 0;
            }
            else
                spawnCounter++;
        }
        public new EnemyEnum ParseEnemy(string enemy)
            => (EnemyEnum)Enum.Parse(typeof(EnemyEnum), enemy, true);
    }
}
