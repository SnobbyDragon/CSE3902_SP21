using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    internal class DownWoodSwordState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        private int count = 0;
        private readonly int maxCount = 24;

        public DownWoodSwordState(IPlayer player)
        {
            this.player = player;
            sprite = Room.PlayerFactory.MakeSprite("link down sword", player.Pos);
        }

        public void Update()
        {
            if (count > maxCount)
            {
                player.State = new DownIdleState(player);
            }
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}