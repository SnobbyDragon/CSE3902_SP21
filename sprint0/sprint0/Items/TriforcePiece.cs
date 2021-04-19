using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class TriforcePiece : IItem
    {
        public int PickedUpDuration { get; set; }
        private readonly int maxPickedUpDuration = 40;
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly List<Rectangle> sources;
        private readonly int width, height;
        private int currFrame;
        private readonly int totalFrames = 2, repeatedFrames = 8;

        private readonly Game1 game;
        public PlayerItems PlayerItems { get => PlayerItems.Triforce; }
        public PlayerItems SecondaryType { get => PlayerItems.None; }
        public TriforcePiece(Texture2D texture, Vector2 location, Game1 gm)
        {
            this.game = gm;
            width = height = 10;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            PickedUpDuration = -1;
            sources = new List<Rectangle>
            {
                new Rectangle(275, 3, width, height),
                new Rectangle(275, 19, width, height)
            };
            currFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PickedUpDuration < maxPickedUpDuration)
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);
            else
                game.stateMachine.HandleVictory();
        }

        public void Update()
        {
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            if (PickedUpDuration >= 0) PickedUpDuration++;
        }
    }
}