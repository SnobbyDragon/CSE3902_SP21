using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class RightWalkingState : IPlayerState
    {
        private IPlayer player;
        private ISprite sprite;
        public RightWalkingState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link right walking", player.Position);
        }

        public void Stop()
        {
            player.State = new RightIdleState(player);
        }

        public void HandleRight()
        {
            player.Move(1, 0);
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