using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class GanonFireball : IProjectile
    {
        public IEntity Shooter { get; }
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int width = 8, height = 10;
        private readonly Dictionary<Direction, List<Rectangle>> dirToSourcesMap;
        private readonly Dictionary<Direction, SpriteEffects> dirToEffectsMap;
        private int currFrame;
        private readonly Direction dir;
        private readonly int totalFrames, repeatedFrames, speed = 3;
        private bool hit;

        public int Damage { get => 4; }

        public GanonFireball(Texture2D texture, Vector2 location, Direction dir, IEntity shooter)
        {
            Shooter = shooter;
            Texture = texture;
            this.dir = dir;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 2;
            dirToSourcesMap = new Dictionary<Direction, List<Rectangle>>
            {
                { Direction.North, SpritesheetHelper.GetFramesH(276, 157, width, height, totalFrames) },
                { Direction.NorthWest, SpritesheetHelper.GetFramesH(276, 174, width, height, totalFrames) },
                { Direction.West, SpritesheetHelper.GetFramesH(276, 192, width, height, totalFrames) },
                { Direction.SouthWest, SpritesheetHelper.GetFramesH(276, 174, width, height, totalFrames) },
                { Direction.South, SpritesheetHelper.GetFramesH(276, 157, width, height, totalFrames) },
                { Direction.SouthEast, SpritesheetHelper.GetFramesH(276, 174, width, height, totalFrames)},
                { Direction.East,  SpritesheetHelper.GetFramesH(276, 192, width, height, totalFrames) },
                { Direction.NorthEast, SpritesheetHelper.GetFramesH(276, 174, width, height, totalFrames) }
            };
            dirToEffectsMap = new Dictionary<Direction, SpriteEffects>
            {
                { Direction.North, SpriteEffects.None },
                { Direction.NorthWest, SpriteEffects.None },
                { Direction.West, SpriteEffects.None },
                { Direction.SouthWest, SpriteEffects.FlipVertically },
                { Direction.South, SpriteEffects.FlipVertically },
                { Direction.SouthEast, SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally },
                { Direction.East,  SpriteEffects.FlipHorizontally },
                { Direction.NorthEast, SpriteEffects.FlipHorizontally }
            };
            hit = false;
        }

        public bool IsAlive() => !hit;

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive())
                spriteBatch.Draw(Texture, Location, dirToSourcesMap[dir][currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), dirToEffectsMap[dir], 0);
        }

        public void Update()
        {
            if (IsAlive())
            {
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                Rectangle loc = Location;
                loc.Offset(speed * dir.ToVector2());
                Location = loc;
            }
        }

        public void RegisterHit() => hit = true;
    }
}