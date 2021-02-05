using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class GleeokHead : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle defaultSource;
        private bool isAngry; // if head is severed / angry, has different frames; TODO maybe change to state pattern later?
        private List<Rectangle> angrySources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;

        public GleeokHead(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 4;
            defaultSource = new Rectangle(280, 11, 8, 16);
            isAngry = true;
            angrySources = new List<Rectangle>
            {
                new Rectangle(289, 11, 16, 16),
                new Rectangle(306, 11, 16, 16)
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAngry)
                spriteBatch.Draw(Texture, Location, angrySources[currFrame / repeatedFrames], Color.White);
            else 
                spriteBatch.Draw(Texture, Location, defaultSource, Color.White);
        }

        public void Update()
        {
            // animates all the time for now TODO movement and angry state change
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
        }
    }
}
