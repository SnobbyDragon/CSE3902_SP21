using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class DeathCloud : IEffect
    {
        protected readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture;
        private readonly int xOffset = 138, yOffset = 185, size = 16, totalFrames = 3, repeatedFrames = 9;
        private readonly List<Rectangle> sources;
        private int frame;
        protected int damage = 0;
        public int Damage { get => damage; }

        public DeathCloud(Texture2D texture, Vector2 location, Game1 Game)
        {
            game = Game;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, size, size, totalFrames);
            frame = 0;
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (frame< totalFrames * repeatedFrames)
            {
                spriteBatch.Draw(Texture, Location, sources[(frame/repeatedFrames)], Color.White);
            }
        }

        public void Update()
        {
            if (frame < totalFrames * repeatedFrames)
            {
                frame++;
            }
            else
            {
                Perish();
            }
        }


            private void Perish()
            {
                game.Room.LoadLevel.RoomMisc.RemoveProjectile(this);
            }

            public bool IsAlive()
            {
                return true;
            }
        }
    }