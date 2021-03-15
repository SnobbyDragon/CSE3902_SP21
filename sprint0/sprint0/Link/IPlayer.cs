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
        Direction Direction { get; set; }

        //Pos is deprecated
        Vector2 Pos { get; set; }
        IPlayerState State { get; set; }

        int WeaponDamage { get; set; }
        PlayerItems CurrentItem { get; set; }
        public List<int> ItemCounts { get; }

        //Use position, not Pos
        static Vector2 Position;
        void Move(int x, int y);
        void Stop();
        void TakeDamage(Direction direction, int damage);
        void PickUpItem();
        void HandleUp();
        void HandleDown();
        void HandleLeft();
        void HandleRight();
        void HandleSword();
        void HandleItem();

        void ReceiveItem(int n, PlayerItems item);
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
