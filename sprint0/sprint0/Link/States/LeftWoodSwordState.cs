using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class LeftWoodSwordState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;
        private int count = 0;
        public LeftWoodSwordState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link left sword", player.Pos);
        }

        public void HandleSword()
        {
            player.State = new LeftWoodSwordState(player);
        }

        public void Update()
        {
            if (count > 24)
            {
                player.State = new LeftIdleState(player);
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