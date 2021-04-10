using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class RightWalkingState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public RightWalkingState(IPlayer player)
        {
            this.player = player;
            player.Direction = Direction.East;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkRightWalking, player.Pos);
        }

        public void Stop() => player.State = new RightIdleState(player);
        public void PickUpItem() => player.State = new PickUpItemState(player);

        public void HandleSword(LinkUseItemHelper itemHelper)
        {
            itemHelper.UseSword(player.Health == player.MaxHealth);
            player.State = new RightWoodSwordState(player);
        }

        public void Update()
        {
            player.Move(1, 0);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
        }

        public void UseItem(LinkUseItemHelper itemHelper)
        {
            if (player.CurrentItem != PlayerItems.None && player.CurrentItem != PlayerItems.BlueCandle)
                player.ItemCounts[(int)player.CurrentItem]--;
            itemHelper.UseItem();
            player.State = new RightUseItemState(player);
        }

        public void Draw(SpriteBatch spritebatch) => sprite.Draw(spritebatch);
    }
}