using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Authors: Jesse He and Jacob Urick
//Updated: 04/03/21 by shah.1440
namespace sprint0
{
    class Link : IPlayer
    {
        private readonly Game1 game;
        private IPlayerState state;
        public static Vector2 position;
        private int health = 28, maxHealth = 28;
        private readonly int speed = 2;
        private bool isAlive;
        private Direction direction = Direction.n;
        private readonly LinkUseItemHelper itemHelper;
        private readonly HUDManager HUD;
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
            itemHelper = new LinkUseItemHelper(game, this);
            CurrentItem = PlayerItems.None;
            speed = 2;
            HUD = this.game.hudManager;
        }

        public void Move(int x, int y) => position += new Vector2(speed * x, speed * y);

        public void TakeDamage(Direction direction, int damage)
        {
            if (isAlive)
            {
                game.Room.Player = new DamagedLink(this, game, direction);
                HUD.TakeDamage(damage);
                health = HUD.Health;
                game.Room.RoomSound.AddSoundEffect(SoundEnum.LinkDamaged);
                if (health <= 0) Die();
            }
        }

        public void PickUpItem() => State.PickUpItem();

        public void IncrementItem(PlayerItems inventoryItem)
        {
            if (inventoryItem == PlayerItems.BlueRupee)
                HUD.ChangeNum(PlayerItems.Rupee, BlueRupee.Value);
            else if (inventoryItem == PlayerItems.HeartContainer)
            {
                HUD.Increment(PlayerItems.Heart);
                maxHealth += 2;
            }

            else HUD.Increment(inventoryItem);
        }

        private void Die()
        {
            isAlive = false;
            game.Room.RoomSound.AddSoundEffect(SoundEnum.LinkDeath);
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
                    HUD.Decrement(CurrentItem);
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
            health = HUD.Health;
        }

        public void ReceiveItem(int n, PlayerItems item)
        {
            ItemCounts[(int)item] += n;
            HUD.ChangeNum(item, n);
        }

        public void SetHUDItem(PlayerItems source, PlayerItems newItem) => HUD.SetItem(source, newItem);
        public bool HasItem(PlayerItems item) => HUD.HasItem(item);
        public bool HasKey() {
            if (game.stateMachine.GetState().Equals(GameStateMachine.State.test)) {
                return true;
            }else
                return   HUD.HasKeys();
        
        }
        public void DecrementKey() => HUD.DecrementKey();
        public void AddToInventory(PlayerItems newItem) => HUD.AddBItem(newItem);
    }
}
