using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class ManhandlaLimb : ISprite
    {
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int size = 16;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private Dictionary<String, Vector2> dirToLocationMap;
        private Dictionary<String, List<Rectangle>> dirToSourcesMap;
        private string dir;
        private ISprite center; // center of manhandla

        public ManhandlaLimb(Texture2D texture, ISprite center, String dir)
        {
            Texture = texture;
            this.center = center;
            this.dir = dir;
            currFrame = 0;
            totalFrames = 2;
            repeatedFrames = 4;
            dirToLocationMap = new Dictionary<string, Vector2>
            {
                { "up", new Vector2(0, -size) },
                { "down", new Vector2(0, size) },
                { "right", new Vector2(size, 0) },
                { "left", new Vector2(-size, 0) }
            };
            dirToSourcesMap = new Dictionary<string, List<Rectangle>>
            {
                { "up", new List<Rectangle>
                    {
                        new Rectangle(105, 89, size, size),
                        new Rectangle(158, 89, size, size)
                    }
                },
                { "down", new List<Rectangle>
                    {
                        new Rectangle(105, 123, size, size),
                        new Rectangle(158, 123, size, size)
                    }
                },
                { "left", new List<Rectangle>
                    {
                        new Rectangle(88, 106, size, size),
                        new Rectangle(141, 106, size, size)
                    }
                },
                { "right", new List<Rectangle>
                    {
                        new Rectangle(122, 106, size, size),
                        new Rectangle(175, 106, size, size)
                    }
                }
            };
            Location = center.Location + dirToLocationMap[dir];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, dirToSourcesMap[dir][currFrame / repeatedFrames], Color.White);
        }

        public void Update()
        {
            // animates all the time for now
            currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            Location = center.Location + dirToLocationMap[dir];
        }
    }
}
