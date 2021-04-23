using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    public class SwordBeam : IProjectile
    {
        public IEntity Shooter { get; }
        public Rectangle Location { get; set; }

        public int Damage { get; }

        private readonly Texture2D texture;
        private readonly List<Rectangle> sources;
        private readonly Direction dir;
        private Vector2 adjust;
        private int width, height;
        private int currFrame = 0;
        private readonly int repeatedFrames = 8, totalFrames = 2;
        private bool hit = false;
        private Room room;
        private readonly List<SpriteEffects> spriteEffects;
        public SwordBeam(Texture2D texture, Vector2 location, Direction dir, IEntity source, Room room)
        {
            if (source is IPlayer link) Damage = link.WeaponDamage;
            else Damage = 2;
            Shooter = source;
            this.room = room;
            this.dir = dir;
            this.texture = texture;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            adjust = 4 * DirectionExtension.ToVector2(dir);
            if (dir == Direction.North || dir == Direction.South)
            {
                width = 7;
                height = 16;
                sources = new List<Rectangle>
                {
                    new Rectangle(1, 154, width, height),
                    new Rectangle(36, 154, width, height),
                    new Rectangle(71, 154, width, height),
                    new Rectangle(106, 154, width, height)
                };
            }
            else
            {
                width = 16;
                height = 7;
                sources = new List<Rectangle>
                {
                    new Rectangle(10, 159, width, height),
                    new Rectangle(45, 159, width, height),
                    new Rectangle(80, 159, width, height),
                    new Rectangle(115, 159, width, height)
                };
            }
            spriteEffects = new List<SpriteEffects>() { 0, SpriteEffects.FlipVertically, 0, SpriteEffects.FlipHorizontally };
        }

        public bool IsAlive() => !hit;

        private void Move()
        {
            if (IsAlive())
            {
                Rectangle tempLoc = Location;
                tempLoc.Offset(adjust.X, adjust.Y);
                Location = tempLoc;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive())
            {
                Rectangle destination = new Rectangle(Location.X, Location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
                spriteBatch.Draw(texture, destination, sources[currFrame / repeatedFrames], Color.White, 0, new Vector2(0, 0), spriteEffects[(int)dir], 0);
            }
        }

        public void Update()
        {
            if (IsAlive())
            {
                Move();
                currFrame = (currFrame + 1) % (totalFrames * repeatedFrames);
            }
        }
        public void RegisterHit()
        {
            hit = true;
            room.LoadLevel.RoomEffect.AddEffect(new Vector2(Location.X, Location.Y), EffectEnum.SwordBeamExplode);
        }
    }
}