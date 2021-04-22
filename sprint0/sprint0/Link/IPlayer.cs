using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

// Authors: Jesse He and Jacob Urick
//Updated: 03/24/21 by shah.1440
namespace sprint0
{
    public enum PlayerItems
    {
        None = -2, Arrow = 0, Bomb = 1, Boomerang = 2, BlueCandle = -1, Key = 3, Rupee = 4, Heart = 5, BlueRupee = 6,
        Sword = 7, WhiteSword = 8, MagicalSword = 9, SilverArrow = 10, Bow = 11, RedCandle = 12, Flute = 13, Food = 14,
        Letter = 15, BluePotion = 16, RedPotion = 17, MagicalRod = 18, BookOfMagic = 19, RedRing = 20, MagicalKey = 21,
        PowerBracelet = 22, MagicalBoomerang = 23, Map = 24, Compass = 25, Clock = 26, Fairy = 27, HeartContainer = 28,
        BlueRing = 29, Triforce = 30, Raft = 31, StepLadder = 32,
        AItem, BItem, HUD, ItemSelectorRed, ItemSelectorBlue, BoomerangType, PotionType, RingType, ArrowType, CandleType
    }

    public interface IPlayer : IEntity
    {
        public Direction Direction { get; set; }
        public Vector2 Pos { get; set; }
        public IPlayerState State { get; set; }
        public int WeaponDamage { get; }
        public PlayerItems CurrentItem { get; set; }
        public PlayerItems CurrentSword { get; }
        public List<int> ItemCounts { get; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public bool CanPlaceLadder { get; set; }
        public void Move(int x, int y);
        public void Stop();
        public void TakeDamage(Direction direction, int damage);
        public void PickUpItem();
        public void HandleUp();
        public void HandleDown();
        public void HandleLeft();
        public void HandleRight();
        public void HandleJump();
        public void HandleSword();
        public void HandleRod();
        public void HandleItem();
        public void IncrementItem(PlayerItems inventoryItem);
        public void SetHUDItem(PlayerItems source, PlayerItems newItem);
        public void AddToInventory(PlayerItems newItem);
        public void ReceiveItem(int n, PlayerItems item);
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
        public bool HasItem(PlayerItems item);
        public bool HasKey();
        public void DecrementKey();
    }
}
