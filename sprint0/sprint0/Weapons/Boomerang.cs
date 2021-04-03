using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    /*
     * Last updated: 3/28/21 by he.1528
     */
    public class Boomerang : IProjectile
    {
        public IEntity Shooter { get; }
        public Rectangle Location { get; set; }
        public int Damage { get => 1; }
        public bool CanBeCaught { get => age > maxDistance || hit; }
        public Texture2D Texture { get; set; }
        private readonly int xOffset = 290, yOffset = 11, width = 8, height = 16;
        private readonly List<Rectangle> sources;
        private int currFrame = 0;
        private readonly int totalFrames = 8, repeatedFrames = 4;
        private readonly int speed = 6, maxDistance = 25;
        private int age = 0;
        private readonly List<SpriteEffects> spriteEffects;
        private Vector2 moveVector;
        private bool alive;
        private bool hit = false;
        private readonly Room room;

        public Boomerang(Texture2D texture, Vector2 location, Direction dir, IEntity shooter, Room room)
        {
            this.room = room;
            Shooter = shooter;
            alive = true;
            moveVector = speed * dir.ToVector2();
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            sources = SpritesheetHelper.GetFramesH(xOffset, yOffset, width, height, 3);
            sources.Add(sources[1]);
            spriteEffects = new List<SpriteEffects>
            {
                SpriteEffects.None,
                SpriteEffects.None,
                SpriteEffects.None,
                SpriteEffects.FlipHorizontally,
                SpriteEffects.FlipHorizontally,
                SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically,
                SpriteEffects.FlipVertically,
                SpriteEffects.FlipVertically
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (alive)
                spriteBatch.Draw(
                    Texture, Location,
                    sources[currFrame / repeatedFrames % sources.Count],
                    Color.White, 0, new Vector2(0, 0),
                    spriteEffects[currFrame / repeatedFrames], 0);
        }

        public bool IsAlive() => alive;
        public void Perish() => alive = false;
        public void Move()
        {
            Rectangle loc = Location;
            loc.Offset(moveVector);
            Location = loc;
        }

        public void Update()
        {
            if (alive)
            {
                if (CanBeCaught)
                {
                    if (Shooter is IPlayer)
                        moveVector = Link.position - Location.Location.ToVector2();
                    else if (Shooter is Goriya goriya)
                        moveVector = goriya.Location.Center.ToVector2() - Location.Center.ToVector2();
                    moveVector.Normalize();
                    moveVector = speed * moveVector;
                }
                Move();
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
                age++;
            }
            if (Shooter is Goriya goriya1)
                alive = goriya1.health > 0;


        }

        public void RegisterHit()
        {
            hit = true;
            room.LoadLevel.RoomMisc.AddEffect(new Vector2(Location.X, Location.Y), "hit sprite");
        }
    }
}