using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Fairy:ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private List<Rectangle> sources;
        private int totalFrames;
        private int currentFrame;
        private int repeatedFrames = 10;
        private Game1 game;
        private int upOrSide;

        //high coupling because has game object-wish there was better way
        public Fairy(Texture2D texture, Vector2 location, Game1 game1)
        {
            game = game1;
            Location = location;
            Texture = texture;
            totalFrames = 2;
            currentFrame = 0;
            sources = new List<Rectangle>();
            int xPos = 40, yPos = 0, width = 7, height =16;
            sources.Add(new Rectangle(xPos, yPos, width, height));
            sources.Add(new Rectangle(xPos+width+1, yPos, width, height));
            upOrSide=0;

        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, sources[currentFrame/repeatedFrames], Color.White);
        }

        public void Update()
        {
            upOrSide++;
            currentFrame = (currentFrame + 1) % (totalFrames * repeatedFrames);
            if ((upOrSide / 70) % 2 == 0)
            {
                Location = game.Player.Pos + new Vector2(20, -10);
            }
            else {
                Location = game.Player.Pos + new Vector2(12, -20);
            }
        }
    }
}
