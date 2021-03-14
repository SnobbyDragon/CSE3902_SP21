using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Authors: Stuti Shah, Hannah Johnson, Angela Li
namespace sprint0
{
    public class Trap : Enemy, IEnemy
    {

        private Rectangle source;
        private Rectangle HomeLocation;
        public bool IsMoving { get; set; }
  
        public Trap(Texture2D texture, Vector2 location, Game1 game): base(texture, location, game)
        {
            width = 16;
            height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            HomeLocation = Location;
            Texture = texture;

            source = new Rectangle(164, 59, width, height);
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public new void Update()
        {
            if (IsMoving)
            {
                Rectangle loc = Location;
                loc.Offset(direction.ToVector2());
                Location = loc;
            }

            if (Location == HomeLocation) { IsMoving = false; }
        }

        public void SetDirection(Direction direction)
        {
            this.direction = direction;
        }

        public new void ChangeDirection()
        {
            direction = direction.OppositeDirection();
        }
    }
}
