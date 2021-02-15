using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    internal class UpWoodSwordState : IPlayerState
    {
        private ISprite sprite;
        private IPlayer player;
        private int count = 0;
        public UpWoodSwordState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link up sword", player.Position);
        }


        public void Update()
        {
            if (count > 24) {
                player.State = new UpIdleState(player);
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