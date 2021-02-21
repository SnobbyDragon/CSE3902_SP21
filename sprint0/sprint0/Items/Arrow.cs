using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime;
namespace sprint0
{
    public class Arrow : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private readonly int xOffset = 154, yOffset = 0, sizex = 5, sizey = 16;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private Direction dir;
        //xa is x adjust, ya is y adjust
        private float xa, ya;
        //Lifespan is the number of updates before it dies. 
        //For now, it just stops rendering
        private int lifespan;
        //Age is the current number of updates
        private int age;
        public Arrow(Texture2D texture, Vector2 location, Direction dir, int lifespan)
        {
            Location = location;
            Texture = texture;
            this.dir = dir;
            this.lifespan = lifespan;
            sources = new List<Rectangle>
            {
                new Rectangle(xOffset, yOffset, sizex, sizey),
                new Rectangle(xOffset, yOffset+sizey+1, sizex, sizey)
            };
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;

        }

        private Boolean alive() {
            if (age < lifespan || lifespan < 0) {
                age++;
                return true;
            }
            return false;
        }

        private void Move() {
            Location = new Vector2(Location.X+xa, Location.Y + ya);
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            if (alive())
            {
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
            }
        }

        public void Update()
        {
            if (alive())
            {

                switch (dir)
                {
                    case Direction.n:
                        ya = -5;
                        break;
                    case Direction.s:
                        ya = 5;
                        break;
                    case Direction.e:
                        xa = 5;
                        break;
                    case Direction.w:
                        xa = -5;
                        break;
                }
                Move();

                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            }
        }
    }
}
