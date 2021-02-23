using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class DownWoodSwordState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;
        private int count = 0;
        public DownWoodSwordState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link down sword", player.Pos);
        }

        public void Update()
        {
            if (count > 24)
            {
                player.State = new DownIdleState(player);
            }
            sprite.Location = player.Pos;
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}