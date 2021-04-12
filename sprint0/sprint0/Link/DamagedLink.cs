using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace sprint0
{
    class DamagedLink : IPlayer
    {
        private readonly Game1 game;
        private readonly IPlayer decoratedLink;
        private readonly Direction direction;
        private int timer = 80;
        private readonly int endPushback = 75;
        readonly HUDManager HUD;
        private readonly int speed = 6;
        public Vector2 Pos { get => decoratedLink.Pos; set => decoratedLink.Pos = value; }
        public IPlayerState State { get => decoratedLink.State; set => decoratedLink.State = value; }
        Direction IPlayer.Direction { get => decoratedLink.Direction; set => decoratedLink.Direction = value; }
        public int WeaponDamage { get => decoratedLink.WeaponDamage; set => decoratedLink.WeaponDamage = value; }
        public PlayerItems CurrentItem { get => decoratedLink.CurrentItem; set => decoratedLink.CurrentItem = value; }
        public List<int> ItemCounts => decoratedLink.ItemCounts;
        public int Health { get => decoratedLink.Health; set => decoratedLink.Health = value; }
        public int MaxHealth { get => decoratedLink.MaxHealth; set => decoratedLink.MaxHealth = value; }

        public DamagedLink(IPlayer decoratedLink, Game1 game, Direction direction)
        {
            this.game = game;
            this.decoratedLink = decoratedLink;
            this.direction = direction;
            HUD = this.game.hudManager;
        }

        public void Move(int x, int y) => decoratedLink.Move(x, y);

        public void TakeDamage(Direction direction, int damage) { }
        public void PickUpItem() { }

        public void IncrementItem(PlayerItems inventoryItem)
        {
            if (inventoryItem == PlayerItems.BlueRupee)
                HUD.ChangeNum(PlayerItems.Rupee, BlueRupee.Value);
            else if (inventoryItem == PlayerItems.HeartContainer)
                HUD.Increment(PlayerItems.Heart);
            else HUD.Increment(inventoryItem);
        }

        public void SetHUDItem(PlayerItems source, PlayerItems newItem)
            => HUD.SetItem(source, newItem);

        public void AddToInventory(PlayerItems newItem) => HUD.AddBItem(newItem);
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
            if (timer > endPushback)
            {
                Vector2 move = speed * direction.OppositeDirection().ToVector2();
                decoratedLink.Move((int)move.X, (int)move.Y);
            }
            else if (timer == 0)
                RemoveDecorator();
            decoratedLink.Update();
        }

        public void HandleItem() => decoratedLink.HandleItem();
        public bool HasItem(PlayerItems item) => HUD.HasItem(item);
        public bool HasKey() => HUD.HasKeys();
        public void DecrementKey() => HUD.DecrementKey();
        public void ReceiveItem(int n, PlayerItems item)
        {
            decoratedLink.ReceiveItem(n, item);
            HUD.ChangeNum(item, n);
        }
    }
}
