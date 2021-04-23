using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint0
{
    class DownIdleState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public DownIdleState(IPlayer player)
        {
            this.player = player;
            player.Direction = Direction.South;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkDownIdle, player.Pos);
        }

        public void HandleUp() => player.State = new UpWalkingState(player);
        public void HandleDown() => player.State = new DownWalkingState(player);
        public void HandleLeft() => player.State = new LeftWalkingState(player);
        public void HandleRight() => player.State = new RightWalkingState(player);
        public void HandleJump() => player.State = new DownJumpingState(player);
        public void HandleSword(LinkUseItemHelper itemHelper)
        {
            itemHelper.UseSword(player.Health == player.MaxHealth);
            player.State = new DownWoodSwordState(player);
        }
        public void HandleRod(LinkUseItemHelper itemHelper)
        {
            itemHelper.UseSword(true);
            player.State = new DownWoodSwordState(player);
        }
        public void UseItem(LinkUseItemHelper itemHelper)
        {
            if (player.CurrentItem != PlayerItems.None && player.CurrentItem != PlayerItems.BlueCandle)
                player.ItemCounts[(int)player.CurrentItem]--;
            itemHelper.UseItem();
            player.State = new DownUseItemState(player);
        }

        public void PickUpItem() => player.State = new PickUpItemState(player);

        public void Update()
        {
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch) => sprite.Draw(spritebatch);
    }
}
