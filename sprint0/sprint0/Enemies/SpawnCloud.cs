using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class SpawnCloud : IEffect
    {
        protected readonly Game1 game;
        public Rectangle Location { get; set; }
        public Texture2D Texture; 
        private readonly int xOffset = 138, yOffset = 185, size = 16, totalFrames = 3, repeatedFrames = 6;
        private readonly List<Rectangle> sources;
        private int frame;
        public String enemyAfter;
        protected int damage=0;
        public int Damage { get => damage; }

        public SpawnCloud(Texture2D texture, Vector2 location, Game1 Game, String enemy)
        {
            game = Game;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(size * Game1.Scale), (int)(size * Game1.Scale));
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, size, size, totalFrames);
            frame = 0;
            Texture = texture;
            enemyAfter = enemy;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (frame < totalFrames * repeatedFrames) {
                if (enemyAfter.Equals("trapparatus"))
                {
                    DrawTraps(spriteBatch);
                }
                else
                {
                    spriteBatch.Draw(Texture, Location, sources[frame / repeatedFrames], Color.White);
                }
            }
        }

        public void DrawTraps(SpriteBatch spriteBatch)
        {
                spriteBatch.Draw(Texture, new Rectangle((int)Location.X +219, (int)Location.Y+120, (int)(size * Game1.Scale), (int)(size * Game1.Scale)), sources[frame / repeatedFrames], Color.White);
                spriteBatch.Draw(Texture, new Rectangle((int)Location.X - 219, (int)Location.Y+120, (int)(size * Game1.Scale), (int)(size * Game1.Scale)), sources[frame / repeatedFrames], Color.White);
                spriteBatch.Draw(Texture, new Rectangle((int)Location.X - 219, (int)Location.Y-120, (int)(size * Game1.Scale), (int)(size * Game1.Scale)), sources[frame / repeatedFrames], Color.White);
                spriteBatch.Draw(Texture, new Rectangle((int)Location.X+219, (int)Location.Y-120, (int)(size * Game1.Scale), (int)(size * Game1.Scale)), sources[frame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            if (frame < totalFrames * repeatedFrames)
            {
                frame++;
            }
            else if (frame == totalFrames * repeatedFrames)
            {
                frame++;
                Perish();
           }
        }


        public void Perish()
        {
            game.Room.LoadLevel.RoomMisc.RemoveProjectile(this);
            game.Room.LoadLevel.RoomEnemies.AddEnemy(Location.Location.ToVector2(), enemyAfter);
        }

        public bool IsAlive()
        {
            return true;
        }
    }
}