using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Goriya : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private int currentFrame;
        private string color;
        private int totalFrames, repeatedFrames;
        private Dictionary<string, List<Rectangle>> colorMap;
        SpriteEffects s = SpriteEffects.FlipHorizontally;
        enum Direction { left, right, up, down }
        Direction direction;

        public Goriya(Texture2D texture, Vector2 location, String goriyaColor)
        {
            Location = location;
            Texture = texture;
            color = goriyaColor;
            currentFrame = 0;
            totalFrames = 4;
            repeatedFrames = 20;
            direction = Direction.up;

            colorMap = new Dictionary<string, List<Rectangle>>
            {
                { "red", GetFrames(222, 11, 4)},
                { "blue", GetFrames(222, 28, 4)}
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
            if (direction == Direction.left)
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][(currentFrame / repeatedFrames) % 2 + 2], Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), s, 0);
                //TODO GoriyaBoomerang boomboom = new GoriyaBoomerang(Texture, new Vector2(0, 231));
            }
            else if (direction == Direction.right)
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][(currentFrame / repeatedFrames) % 2 + 2], Color.White);
            }
            else if (direction == Direction.down)
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][0], Color.White);
            }
            else
            {
                spriteBatch.Draw(Texture, Location, colorMap[color][1], Color.White);
            }

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