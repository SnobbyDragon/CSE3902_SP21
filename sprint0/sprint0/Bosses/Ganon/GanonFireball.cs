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
                { Direction.n, SpritesheetHelper.GetFramesH(276, 157, width, height, totalFrames) },
                { Direction.nw, SpritesheetHelper.GetFramesH(276, 174, width, height, totalFrames) },
                { Direction.w, SpritesheetHelper.GetFramesH(276, 192, width, height, totalFrames) },
                { Direction.sw, SpritesheetHelper.GetFramesH(276, 174, width, height, totalFrames) },
                { Direction.s, SpritesheetHelper.GetFramesH(276, 157, width, height, totalFrames) },
                { Direction.se, SpritesheetHelper.GetFramesH(276, 174, width, height, totalFrames)},
                { Direction.e,  SpritesheetHelper.GetFramesH(276, 192, width, height, totalFrames) },
                { Direction.ne, SpritesheetHelper.GetFramesH(276, 174, width, height, totalFrames) }
            };
            dirToEffectsMap = new Dictionary<Direction, SpriteEffects>
            {
                { Direction.n, SpriteEffects.None },
                { Direction.nw, SpriteEffects.None },
                { Direction.w, SpriteEffects.None },
                { Direction.sw, SpriteEffects.FlipVertically },
                { Direction.s, SpriteEffects.FlipVertically },
                { Direction.se, SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally },
                { Direction.e,  SpriteEffects.FlipHorizontally },
                { Direction.ne, SpriteEffects.FlipHorizontally }
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

        public void RegisterHit()
        {
            hit = true;
        }
    }
}