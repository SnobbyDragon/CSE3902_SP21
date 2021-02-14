using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class LeftWalkingState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;
        public LeftWalkingState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link left walking", player.Position);
        }

        public void Stop()
        {
            player.State = new LeftIdleState(player);
        }

        public void HandleLeft()
        {
            player.Move(-1, 0);
        }

        public void Update()
        {
            sprite.Location = player.Position;
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}