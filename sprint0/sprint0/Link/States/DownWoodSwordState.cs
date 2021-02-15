using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class DownWoodSwordState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;
        private int count = 0;
        public DownWoodSwordState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link down sword", player.Position);
        }

       

        public void Update()
        {
            if (count > 24)
            {
                player.State = new DownIdleState(player);
            }
            sprite.Location = player.Position;
            sprite.Update();
            count++;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}