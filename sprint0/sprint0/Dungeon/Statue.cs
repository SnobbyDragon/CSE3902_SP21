using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Statue : IBlock
    {
        private readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int xOffset = 1018, yOffset = 11, width = 16, height = 16;
        private readonly int fireballRate = 100; //TODO currently arbitrary
        private int fireballCounter = 0;
        private string dir;

        public Statue(Texture2D texture, Vector2 location, string direction, Game1 game)
        {
            this.game = game;
            dir = direction;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            if (dir.Equals("right"))
            { // creates a right facing statue
                source = new Rectangle(xOffset, yOffset, width, height);
            }
            else if (dir.Equals("left"))
            { // creates a left facing statue
                source = new Rectangle(xOffset + width + 1, yOffset, width, height);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {
            if (CanShoot())
            {
                ShootFireball();
            }
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireball()
        {
            Vector2 direction = Location.Center.ToVector2();
            if (dir.Equals("left"))
            {
                direction = new Vector2(-1, 0);
            }
            else if (dir.Equals("right"))
            {
                direction = new Vector2(1, 0);
            }
            direction.Normalize();
            game.AddFireball(Location.Center.ToVector2(), direction, this);
        }

        public bool IsWalkable()
        {
            return false;
        }

        public bool IsMovable()
        {
            return false;
        }
    }
}
