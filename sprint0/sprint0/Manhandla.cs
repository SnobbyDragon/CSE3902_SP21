using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Manhandla : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private Rectangle source;
        private List<ManhandlaLimb> limbs;

        public Manhandla(Texture2D texture, Vector2 location)
        {
            Location = location;
            Texture = texture;
            source = new Rectangle(69, 89, size, size); //center
            limbs = new List<ManhandlaLimb>
            {
                new ManhandlaLimb(Texture, this, "up"),
                new ManhandlaLimb(Texture, this, "down"),
                new ManhandlaLimb(Texture, this, "left"),
                new ManhandlaLimb(Texture, this, "right")
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
            foreach (ManhandlaLimb limb in limbs)
                limb.Draw(spriteBatch);
        }

        public void Update()
        {
            //does nothing for now TODO movement
            foreach (ManhandlaLimb limb in limbs)
                limb.Update();
        }
    }
}
