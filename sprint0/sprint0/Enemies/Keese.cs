using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Keese : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private int currentFrame;
        private string color;
        private readonly int totalFrames, repeatedFrames;
        private Dictionary<string, List<Rectangle>> colorMap;
        enum Direction { left, right, up, down }
        Direction direction;
        public Keese(Texture2D texture, Vector2 location, String keeseColor)
        {
            Location = location;
            Texture = texture;
            color = keeseColor;
            currentFrame = 0;
            totalFrames = 2;
            repeatedFrames = 8;
            direction = Direction.up;


            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "blue", GetFrames(183, 11, 2)},
                { "red", GetFrames(183, 28, 2)}
            };
        }

        private List<Rectangle> GetFrames(int xPos, int yPos, int numFrames)
        {
            List<Rectangle> sources = new List<Rectangle>();
            int size = 16;
            for (int i = 0; i < numFrames; i++)
            {
                sources.Add(new Rectangle(xPos, yPos, size, size));
                xPos += size + 1;
            }
            return sources;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, colorMap[color][currentFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {

            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if (direction == Direction.left)
            {
                //moves sprite left
                Location += new Vector2(-1, 0);

                if (Location.X <= 100)
                {
                    direction = Direction.down;

                }
            }
            else if (direction == Direction.right)
            {

                //moves sprite right
                Location += new Vector2(1, 0);

                if (Location.X >= 690)
                {
                    direction = Direction.up;
                }
            }
            else if (direction == Direction.down)
            {
                //moves sprite down
                Location += new Vector2(0, 1);

                if (Location.Y >= 396)
                {
                    direction = Direction.right;
                }
            }
            else
            { //direction==Direction.up
                //moves sprite up
                Location += new Vector2(0, -1);

                if (Location.Y <= 136)
                {
                    direction = Direction.left;
                }
            }
        }
    }
}