using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class UpWoodSwordState : IPlayerState
    {
        private readonly ISprite sprite;
        private readonly IPlayer player;
        private int count = 0;
        public UpWoodSwordState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link up sword", player.Pos);
        }


        public void Update()
        {
            if (count > 24) {
                player.State = new UpIdleState(player);
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