using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Angela Li
namespace sprint0
{
    public class Aquamentus : ISprite
    {
        private Game1 game; //TODO maybe have player bc static so we don't need this
        public Vector2 Location { get; set; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 1, yOffset = 11, width = 24, height = 32;
        private List<Rectangle> sources;
        private int currFrame;
        private readonly int totalFrames, repeatedFrames;
        private int currDest;
        private readonly int moveDelay; // delay to make slower bc floats mess up drawings; must be < totalFrames*repeatedFrames
        private List<Vector2> destinations; // aquamentus moves to predetermined destinations TODO depends on link actually
        private List<AquamentusFireball> fireballs;
        private bool isDead; //TODO maybe should be in a more general class since a lot of sprites can die
        private Vector2 headOffset; // offsets from top left to center of aquamentus' head (where fireballs come from)

        public Aquamentus(Texture2D texture, Vector2 location, Game1 game)
        {
            this.game = game;
            Location = location;
            Texture = texture;
            currFrame = 0;
            totalFrames = 4;
            repeatedFrames = 14;
            headOffset = new Vector2(4, 4); //TODO must be scaled later when sprite is scaled
            sources = new List<Rectangle>();
            for (int frame = 0; frame < totalFrames; frame++)
            {
                sources.Add(new Rectangle(xOffset + frame * (width + 1), yOffset, width, height));
            };

            currDest = 0;
            moveDelay = 5; //slow dragoon
            destinations = new List<Vector2>
            {
                location,
                location + new Vector2(30,0)
            };

            // aquamentus shoots 3 fireballs left (up, middle, down); only 3 is on the map at a time
            fireballs = new List<AquamentusFireball>();
            for (int i = 0; i < 3; i++)
            {
                fireballs.Add(new AquamentusFireball(texture));
            };

            isDead = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isDead) // only draws if alive
                spriteBatch.Draw(Texture, Location, sources[currFrame / repeatedFrames], Color.White);

            //fireballs draw regardless
            foreach (AquamentusFireball fireball in fireballs)
            {
                fireball.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            if (!isDead)
            { // only moves and animates if alive
                Vector2 dist = destinations[currDest] - Location;
                if (dist.Length() == 0)
                {
                    // reached destination, so pick a new destination
                    currDest = (currDest + 1) % destinations.Count;
                }
                else if (currFrame % moveDelay == 0)
                {
                    // has not reached destination, move towards it
                    dist.Normalize();
                    Location += dist;
                }
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            }
            // fireballs move and animate regardless
            if (CanShoot())
            {
                ShootFireballs();
            }
            else
            {
                //fireballs update
                foreach (AquamentusFireball fireball in fireballs)
                {
                    fireball.Update();
                }
            }
        }

        private bool CanShoot() // shoot fireballs if all fireballs dead
        {
            foreach (AquamentusFireball fireball in fireballs)
            {
                if (!fireball.IsDead)
                    return false;
            }
            return true;
        }

        private void ShootFireballs()
        {
            Vector2 dir = game.Player.Position - (Location + headOffset); // TODO offset to center of link
            dir.Normalize();
            foreach (AquamentusFireball fireball in fireballs)
            {
                fireball.Location = Location + headOffset;
                fireball.IsDead = false;
            }
            fireballs[0].Direction = dir;
            fireballs[1].Direction = Vector2.Transform(dir, Matrix.CreateRotationZ((float)(Math.PI / 6))); // 30 degrees up
            fireballs[2].Direction = Vector2.Transform(dir, Matrix.CreateRotationZ((float)(-Math.PI / 6))); // 30 degrees down
        }
    }
}
