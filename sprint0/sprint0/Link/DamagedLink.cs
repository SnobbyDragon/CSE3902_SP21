using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
//Updated: 03/28/21 by he.1528
namespace sprint0
{
    class DamagedLink : IPlayer
    {
        private readonly Game1 game;
        private readonly IPlayer decoratedLink;
        private readonly Direction direction;
        private int timer = 80;
        private readonly PopulateHUDInventory linkInventory;
        private readonly MainHUD mainHUD;
        private readonly HUDInventory hudInventory;
        private readonly int speed = 6;
        public Vector2 Pos { get => decoratedLink.Pos; set => decoratedLink.Pos = value; }
        public IPlayerState State { get => decoratedLink.State; set => decoratedLink.State = value; }
        Direction IPlayer.Direction { get => decoratedLink.Direction; set => decoratedLink.Direction = value; }
        public int WeaponDamage { get => decoratedLink.WeaponDamage; set => decoratedLink.WeaponDamage = value; }
        public PlayerItems CurrentItem { get => decoratedLink.CurrentItem; set => decoratedLink.CurrentItem = value; }
        public List<int> ItemCounts => decoratedLink.ItemCounts;

        public DamagedLink(IPlayer decoratedLink, Game1 game, Direction direction)
        {
            this.game = game;
            this.decoratedLink = decoratedLink;
            this.direction = direction;
            linkInventory = this.game.hudManager.PopulateHUDInventory;
            mainHUD = this.game.hudManager.MainHUD;
            hudInventory = this.game.universalScreenManager.pauseScreenManager.HUDInventory;
        }

        public void Move(int x, int y) => decoratedLink.Move(x, y);

        public void TakeDamage(Direction direction, int damage) { }

        public void PickUpItem() { }

        public void IncrementItem(PlayerItems inventoryItem)
        {
            if (inventoryItem == PlayerItems.BlueRupee)
                linkInventory.ChangeNum(PlayerItems.Rupee, BlueRupee.Value);
            else if (inventoryItem == PlayerItems.HeartContainer)
                linkInventory.IncrementItem(PlayerItems.Heart);
            else linkInventory.IncrementItem(inventoryItem);
        }

        public void SetHUDItem(PlayerItems source, PlayerItems newItem)
        {
            mainHUD.SetItem(source, newItem);
            hudInventory.SetItem(GetItem(PlayerItems.BItem));
            hudInventory.AddAItem(GetItem(PlayerItems.AItem));
        }

        public PlayerItems GetItem(PlayerItems source)
        {
            return mainHUD.GetItem(source);
        }

        public void AddToInventory(PlayerItems newItem) => hudInventory.AddItem(newItem);
        public void RemoveDecorator() => game.Room.Player = decoratedLink;
        public void Stop() => decoratedLink.Stop();
        public void HandleUp() => decoratedLink.HandleUp();
        public void HandleDown() => decoratedLink.HandleDown();
        public void HandleLeft() => decoratedLink.HandleLeft();
        public void HandleRight() => decoratedLink.HandleRight();
        public void HandleSword() => decoratedLink.HandleSword();
        public void Draw(SpriteBatch spriteBatch)
        {
            if (timer % 2 == 0)
                decoratedLink.Draw(spriteBatch);
        }

        public void Update()
        {
            timer--;
            if (timer > 75)
            {
                Vector2 move = speed * direction.OppositeDirection().ToVector2();
                decoratedLink.Move((int)move.X, (int)move.Y);
            }
            else if (timer == 0)
                RemoveDecorator();
            decoratedLink.Update();
        }

        public void HandleItem() => decoratedLink.HandleItem();

        public void ReceiveItem(int n, PlayerItems item)
        {
            decoratedLink.ReceiveItem(n, item);
            linkInventory.ChangeNum(item, n);
        }
    }
}
