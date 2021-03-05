using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class RightIdleState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public RightIdleState(IPlayer player)
        {
            this.player = player;
            sprite = Game1.PlayerFactory.MakeSprite("link right idle", player.Pos);
        }

        public void HandleUp()
        {
            player.Direction = Direction.n;
            player.State = new UpWalkingState(player);
        }

        public void HandleDown()
        {
            player.Direction = Direction.s;
            player.State = new DownWalkingState(player);
        }

        public void HandleLeft()
        {
            player.Direction = Direction.w;
            player.State = new LeftWalkingState(player);
        }

        public void HandleRight()
        {
            player.Direction = Direction.e;
            player.State = new RightWalkingState(player);
        }

        public void UseItem()
        {
            player.State = new RightUseItemState(player);
        }

        public void HandleSword()
        {
            player.State = new RightWoodSwordState(player);
        }

        public void Update()
        {
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            sprite.Draw(spritebatch);
        }
    }
}
