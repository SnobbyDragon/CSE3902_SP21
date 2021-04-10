using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class UpWalkingState : IPlayerState
    {
        private readonly IPlayer player;
        private readonly ISprite sprite;

        public UpWalkingState(IPlayer player)
        {
            this.player = player;
            player.Direction = Direction.North;
            sprite = Room.PlayerFactory.MakeSprite(LinkEnum.LinkUpWalking, player.Pos);
        }

        public void Stop() => player.State = new UpIdleState(player);
        public void PickUpItem() => player.State = new PickUpItemState(player);

        public void HandleSword(LinkUseItemHelper itemHelper)
        {
            itemHelper.UseSword(player.Health == player.MaxHealth);
            player.State = new UpWoodSwordState(player);
        }

        public void Update()
        {
            player.Move(0, -1);
            sprite.Location = new Rectangle((int)player.Pos.X, (int)player.Pos.Y, sprite.Location.Width, sprite.Location.Height);
            sprite.Update();
        }

        public void Draw(SpriteBatch spritebatch) => sprite.Draw(spritebatch);

        public void UseItem(LinkUseItemHelper itemHelper)
        {
            if (player.CurrentItem != PlayerItems.None && player.CurrentItem != PlayerItems.BlueCandle)
                player.ItemCounts[(int)player.CurrentItem]--;
            itemHelper.UseItem();
            player.State = new UpUseItemState(player);
        }
    }
}
