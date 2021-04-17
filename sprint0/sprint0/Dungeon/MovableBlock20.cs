using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class MovableBlock20 : IBlock
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int width, height;
        private Vector2 homeLocation; //TODO
        private bool isMovable;
        public Direction Direction { get; set; }

        public MovableBlock20(Texture2D texture, Vector2 location, Direction direction)
        {
            width = height = 16;
            isMovable = true;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            homeLocation = Location.Location.ToVector2(); //TODO
            Texture = texture;
            source = new Rectangle(1001, 11, width, height);
            Direction = direction;
        }

        public void Draw(SpriteBatch spriteBatch)
            => spriteBatch.Draw(Texture, Location, source, Color.White);
        public void Update() { }
        public bool IsWalkable() => false;
        public bool IsMovable(Direction dir) {
            return dir == Direction && isMovable;
            
        }
        public void SetIsMovable()
        {
            //TODO:fix
            //Vector2 changeLoc = Location.Location.ToVector2() - homeLocation;
            //if (changeLoc.Length() >= Game1.Scale * width) isMovable = false;
        }
        
    }
}
