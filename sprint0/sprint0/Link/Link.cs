using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class Link : IPlayer
    {
        private readonly Game1 game;
        public static Vector2 position;
        private readonly int speed = 2;
        private readonly LinkUseItemHelper itemHelper;
        private readonly HUDManager HUD;
        private Dictionary<PlayerItems, int> weaponDamages = new Dictionary<PlayerItems, int> {
            { PlayerItems.None, 2 }, { PlayerItems.Sword, 2 }, { PlayerItems.WhiteSword, 4 }, { PlayerItems.MagicalSword, 8 }
        };
        public List<int> ItemCounts { get; } = new List<int> { -1, -1, 1 };
        public Vector2 Pos { get => position; set => position = value; }
        public IPlayerState State { get; set; }
        public Direction Direction { get; set; } = Direction.North;
        public PlayerItems CurrentItem { get; set; }
        public PlayerItems CurrentSword { get => HUD.CurrentAItem;}
        public int WeaponDamage { get => weaponDamages[CurrentSword]; }
        public int Health { get; set; } = 28;
        public int MaxHealth { get; set; } = 28;
        private int numTimesProtected;
        public Link(Game1 game, Vector2 pos)
        {
            this.game = game;
            position = pos;
            State = new UpIdleState(this);
            HUD = this.game.hudManager;
            itemHelper = new LinkUseItemHelper(game, this, HUD);
            CurrentItem = PlayerItems.None;
            numTimesProtected = 0;
        }
        public void Move(int x, int y) => position += new Vector2(speed * x, speed * y);
        public void TakeDamage(Direction direction, int damage)
        {
            if (!game.Room.FreezeEnemies)
            {
                game.Room.Player = new DamagedLink(this, game, direction);
                HUD.TakeDamage(CalculateDamage(damage));
                Health = HUD.Health;
                game.Room.RoomSound.AddSoundEffect(SoundEnum.LinkDamaged);
                if (Health <= 0) Die();
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
                MaxHealth += 2;
            }
            else HUD.Increment(inventoryItem);
        }
        private void Die()
        {
            game.Room.RoomSound.AddSoundEffect(SoundEnum.LinkDeath);
            game.stateMachine.HandleDeath();
        }
        public void Stop() => State.Stop();
        public void HandleUp() => State.HandleUp();
        public void HandleDown() => State.HandleDown();
        public void HandleLeft() => State.HandleLeft();
        public void HandleRight() => State.HandleRight();
        public void HandleJump() => State.HandleJump();
        public void HandleSword() => State.HandleSword(itemHelper);
        public void HandleRod() => State.HandleRod(itemHelper);
        public void HandleItem() => State.UseItem(itemHelper);
        public void Draw(SpriteBatch spriteBatch) => State.Draw(spriteBatch);
        public void Update()
        {
            State.Update();
            Health = HUD.Health;
        }
        private int CalculateDamage(int damage)
        {
            int maxNumTimesProtected = 3;
            if (HasItem(PlayerItems.BlueRing) && damage >= 2) return damage / 2;
            else if (HasItem(PlayerItems.RedRing) && damage >= 2) return damage * 3 / 4;
            else if (HasItem(PlayerItems.Fairy)) {
                if (numTimesProtected > maxNumTimesProtected) {
                    game.Room.LoadLevel.RoomItems.RemoveFairy();
                    HUD.RemoveItem(PlayerItems.Fairy);
                    numTimesProtected = 0;
                }
                numTimesProtected++;
                return 0;
            }
            else return damage;
        }
        public void ReceiveItem(int n, PlayerItems item)
        {
            ItemCounts[(int)item] += n;
            HUD.ChangeNum(item, n);
        }
        public void SetHUDItem(PlayerItems source, PlayerItems newItem) => HUD.SetItem(source, newItem);
        public bool HasItem(PlayerItems item) => HUD.HasItem(item);
        public bool HasKey() => game.stateMachine.GetState().Equals(GameStateMachine.State.test) || HUD.HasKeys();
        public void DecrementKey() => HUD.DecrementKey();
        public void AddToInventory(PlayerItems newItem) => HUD.AddBItem(newItem);
    }
}
