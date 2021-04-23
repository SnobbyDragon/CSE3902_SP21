using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Statue : AbstractBlock, IBlock
    {
        private readonly Game1 game;
        private readonly int xOffset = 1018, yOffset = 11, fireballRate = 100;
        private int fireballCounter = 0;
        public Direction Dir { get; }

        public Statue(Texture2D texture, Vector2 location, Direction direction, Game1 game)
        {
            this.game = game;
            Dir = direction;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            if (Dir == Direction.East) source = new Rectangle(xOffset, yOffset, width, height);
            else if (Dir == Direction.West) source = new Rectangle(xOffset + width + 1, yOffset, width, height);
        }
        public override void Update()
        {
            if (CanShoot()) ShootFireball();
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireball()
            => game.Room.LoadLevel.RoomProjectile.AddFireball(Location.Center.ToVector2(), Dir.ToVector2(), this);

    }
}
