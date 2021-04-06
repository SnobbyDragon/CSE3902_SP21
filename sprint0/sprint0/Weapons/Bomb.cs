using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson
/*
 * Last updated: 3/13/21 by urick.9
 */
namespace sprint0
{
    public class Bomb : IWeapon
    {
        public Rectangle Location { get; set; }
        public int Damage { get => 20; }
        public Texture2D Texture { get; set; }
        public bool Exploding { get => exploding; }
        public bool Eaten { get; set; }

        private Rectangle source;
        private readonly List<Rectangle> explosionSources;
        private Rectangle currentSource;
        private readonly int xPos = 138, yPos = 184, width = 17, height = 18;
        private bool exploding = false;

        private readonly Room room;
        private int age;
        private readonly int lifespan;

        private readonly int repeatedFrames;
        private readonly int totalFrames;
        private int currentFrame;

        public Bomb(Texture2D texture, Vector2 location, Direction dir, Room room)
        {
            this.room = room;
            int sourceAdjustX = 0;
            int sourceAdjustY = 0;

            switch (dir)
            {
                case Direction.North:
                    sourceAdjustX = -4;
                    sourceAdjustY = -4;
                    break;
                case Direction.South:
                    sourceAdjustX = 4;
                    sourceAdjustY = 4;
                    break;
                case Direction.East:
                    sourceAdjustX = 4;
                    break;
                case Direction.West:
                    sourceAdjustX = -4;
                    break;
            }
            Texture = texture;
            repeatedFrames = 5;
            lifespan = 120;
            source = new Rectangle(127, 184, 10, 17);

            totalFrames = 3; currentFrame = 0;
            explosionSources = SpritesheetHelper.GetFramesH(xPos, yPos, width, height, totalFrames);
            Vector2 loc = location + new Vector2(sourceAdjustX, sourceAdjustY);
            Location = new Rectangle((int)loc.X, (int)loc.Y, (int)(10 * Game1.Scale), (int)(height * Game1.Scale));
        }

        public bool IsAlive()
        {
            age++;
            return age < lifespan + 3 * repeatedFrames && !Eaten;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive())
            {
                spriteBatch.Draw(Texture, Location, currentSource, Color.White);
            }
        }

        public void Update()
        {
            currentSource = source;
            if (age < lifespan + 3 * repeatedFrames && age >= lifespan && lifespan > 0)
            {
                if (age == lifespan)
                {
                    room.RoomSound.AddSoundEffect(SoundEnum.BombExplode);
                    exploding = true;
                }
                Location = new Rectangle(Location.X, Location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
                currentSource = explosionSources[currentFrame / repeatedFrames];
                currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            }
        }
    }
}

