using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

// Authors: Jesse He and Jacob Urick
namespace sprint0
{
    public enum PlayerItems
    {
        None = -2, Arrow = 0, Bomb = 1, Boomerang = 2, Candle = -1
    }

    public interface IPlayer : IEntity
    {
        public Direction Direction { get; set; }

        public Vector2 Pos { get; set; }
        public IPlayerState State { get; set; }

        public int WeaponDamage { get; set; }
        public PlayerItems CurrentItem { get; set; }
        public List<int> ItemCounts { get; }

        public static Vector2 Position;
        public void Move(int x, int y);
        public void Stop();
        public void TakeDamage(Direction direction, int damage);
        public void PickUpItem();
        public void HandleUp();
        public void HandleDown();
        public void HandleLeft();
        public void HandleRight();
        public void HandleSword();
        public void HandleItem();

        public void ReceiveItem(int n, PlayerItems item);
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}
