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
        private readonly Dictionary<string, List<Rectangle>> dirToSourcesMap;
        private readonly Dictionary<string, SpriteEffects> dirToEffectsMap;
        private readonly string type;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames, speed = 3;
        public Vector2 Direction { get; set; } // direction fireball travels
        private bool hit;

        public int Damage { get; }

        public GanonFireball(Texture2D texture, Vector2 location, string type, IEntity shooter)
        {
            Shooter = shooter;
            Damage = 1;
            Texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width*Game1.Scale), (int)(height*Game1.Scale));
            this.type = type;
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 2;
            dirToSourcesMap = new Dictionary<string, List<Rectangle>>
            {
                { "up", GetFrames(276, 157) },
                { "up left", GetFrames(276, 174) },
                { "left", GetFrames(276, 192) },
                { "down left", GetFrames(276, 174) },
                { "down", GetFrames(276, 157) },
                { "down right", GetFrames(276, 174)},
                { "right",  GetFrames(276, 192) },
                { "up right", GetFrames(276, 174) }
            };
            dirToEffectsMap = new Dictionary<string, SpriteEffects>
            {
                { "up", SpriteEffects.None },
                { "up left", SpriteEffects.None },
                { "left", SpriteEffects.None },
                { "down left", SpriteEffects.FlipVertically },
                { "down", SpriteEffects.FlipVertically },
                { "down right", SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally},
                { "right",  SpriteEffects.FlipHorizontally },
                { "up right", SpriteEffects.FlipHorizontally }
            };
            hit = true; // start hidden
            GetDirection();
        }

        public void GetDirection()
        {
            switch (type)
            {
                case "up":
                    Direction = new Vector2(0, -1);
                    break;
                case "up left":
                    Direction = new Vector2(-1, -1);
                    break;
                case "left":
                    Direction = new Vector2(-1, 0);
                    break;
                case "down left":
                    Direction = new Vector2(-1, 1);
                    break;
                case "down":
                    Direction = new Vector2(0, 1);
                    break;
                case "down right":
                    Direction = new Vector2(1, 1);
                    break;
                case "right":
                    Direction = new Vector2(1, 0);
                    break;
                case "up right":
                    Direction = new Vector2(1, -1);
                    break;
                default:
                    // do nothing for none (determined by Link's position)
                    break;
            }
            if (!type.Equals("none"))
                Direction.Normalize();
        }

        //TODO make a utility class so we can reuse this code??? this is in a lot of places rn
        public List<Rectangle> GetFrames(int xOffset, int yOffset)
        {
            List<Rectangle> sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };
            return sources;
        }

        public bool IsAlive() => !hit; // TODO clean up, we only need IsAlive()

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!hit)
                spriteBatch.Draw(Texture, Location, dirToSourcesMap[type][currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), dirToEffectsMap[type], 0);
        }

        public void Update()
        {
            if (!hit)
            {
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                Rectangle loc = Location;
                loc.Offset(speed * Direction);
                Location = loc;
            }
        }

        public void RegisterHit()
        {
            hit = true;
        }
    }
}