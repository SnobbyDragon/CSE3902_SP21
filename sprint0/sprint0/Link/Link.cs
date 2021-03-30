using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Authors: Jesse He and Jacob Urick
//Updated: 03/27/21 by shah.1440
namespace sprint0
{
    class Link : IPlayer
    {
        private readonly Game1 game;
        private IPlayerState state;
        public static Vector2 position;
        private int health = 32;
        private readonly int maxHealth = 32;
        private readonly int speed = 2;
        private bool isAlive;
        private Direction direction = Direction.n;
        private readonly LinkUseItemHelper itemHelper;
        private readonly PopulateHUDInventory linkInventory;
        private readonly MainHUD mainHUD;
        private readonly HUDInventory hudInventory;
        public List<int> ItemCounts { get; }
        public Vector2 Pos { get => position; set => position = value; }
        public IPlayerState State { get => state; set => state = value; }
        public Direction Direction { get => direction; set => direction = value; }
        public PlayerItems CurrentItem { get; set; }
        public int WeaponDamage { get; set; }

        public Link(Game1 game, Vector2 pos)
        {
            WeaponDamage = 2;
            isAlive = true;
            this.game = game;
            position = pos;
            State = new UpIdleState(this);
            ItemCounts = new List<int> { -1, -1, 1 };
            itemHelper = new LinkUseItemHelper(game.Room, this);
            CurrentItem = PlayerItems.None;
            speed = 2;
            linkInventory = this.game.hudManager.PopulateHUDInventory;
            mainHUD = this.game.hudManager.MainHUD;
            hudInventory = this.game.universalScreenManager.pauseScreenManager.HUDInventory;
        }

        public void Move(int x, int y) => position += new Vector2(speed * x, speed * y);

        public void TakeDamage(Direction direction, int damage)
        {

            if (isAlive)
            {
                game.Room.Player = new DamagedLink(this, game, direction);
                linkInventory.ChangeNum(PlayerItems.Heart, damage);
                health = linkInventory.GetNum(PlayerItems.Heart);
                game.Room.RoomSound.AddSoundEffect("link damaged");
                if (health <= 0) Die();
            }
        }

        public void PickUpItem() => State.PickUpItem();

        public void IncrementItem(PlayerItems inventoryItem)
        {
            if (inventoryItem == PlayerItems.BlueRupee)
                linkInventory.ChangeNum(PlayerItems.Rupee, BlueRupee.Value);
            else if (inventoryItem == PlayerItems.HeartContainer)
                linkInventory.IncrementItem(PlayerItems.Heart);
            else linkInventory.IncrementItem(inventoryItem);
        }

        private void Die()
        {
            isAlive = false;
            game.Room.RoomSound.AddSoundEffect("link death");
            game.stateMachine.HandleDeath();
        }

        public void Stop() => State.Stop();

        public void HandleUp() => State.HandleUp();

        public void HandleDown() => State.HandleDown();

        public void HandleLeft() => State.HandleLeft();

        public void HandleRight() => State.HandleRight();

        public void HandleSword()
        {
            if (isAlive)
                itemHelper.UseSword(health == maxHealth);
        }


        public void HandleItem()
        {
            if (isAlive)
            {
                if (CurrentItem != PlayerItems.None && CurrentItem != PlayerItems.BlueCandle)
                {
                    ItemCounts[(int)CurrentItem]--;
                    linkInventory.DecrementItem(CurrentItem);
                }
                itemHelper.UseItem();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
                State.Draw(spriteBatch);
        }

        public void Update()
        {
            if (isAlive)
                State.Update();
            game.universalScreenManager.pauseScreenManager.HUDInventory = hudInventory;
        }

        public void ReceiveItem(int n, PlayerItems item)
        {
            ItemCounts[(int)item] += n;
            linkInventory.ChangeNum(item, n);
        }

        public void SetHUDItem(PlayerItems source, PlayerItems newItem)
        {
            mainHUD.SetItem(source, newItem);
            hudInventory.SetItem(GetItem(PlayerItems.BItem));
            hudInventory.AddAItem(GetItem(PlayerItems.AItem));
        }

        public void AddToInventory(PlayerItems newItem)
            => hudInventory.AddItem(newItem);

        public PlayerItems GetItem(PlayerItems source)
        {
            return mainHUD.GetItem(source);
        }
    }
}
