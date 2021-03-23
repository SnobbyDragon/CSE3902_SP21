using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Authors: Jesse He and Jacob Urick

namespace sprint0
{
    class Link : IPlayer
    {
        private readonly Room room;
        private IPlayerState state;
        public static Vector2 position;
        private int health = 32;
        private readonly int maxHealth = 32;
        private readonly int speed = 2;
        private bool isAlive;
        private Direction direction = Direction.n;
        private readonly LinkUseItemHelper itemHelper;
        private readonly LinkDamageControl damageControl;
        public List<int> ItemCounts { get; }
        public Vector2 Pos { get => position; set => position = value; }
        public IPlayerState State { get => state; set => state = value; }
        public Direction Direction { get => direction; set => direction = value; }
        public PlayerItems CurrentItem { get; set; }
        public int WeaponDamage { get; set; }

        public Link(Room room, Vector2 pos)
        {
            WeaponDamage = 2;
            isAlive = true;
            this.room = room;
            position = pos;
            State = new UpIdleState(this);
            ItemCounts = new List<int> { -1, -1, 1 };
            itemHelper = new LinkUseItemHelper(room, this);
            CurrentItem = PlayerItems.None;
            speed = 2;
            damageControl = new LinkDamageControl(room.GetManager());
        }

        public void Move(int x, int y)
        {
            position += new Vector2(speed * x, speed * y);
        }

        public void TakeDamage(Direction direction, int damage)
        {
            if (isAlive)
            {
                room.Player = new DamagedLink(this, room, direction);
                health -= damage;
                damageControl.TakeDamage(damage);
                room.AddSoundEffect("link damaged");
                if (health < 0) Die();
            }
        }

        public void PickUpItem()
        {
            State.PickUpItem();
        }

        private void Die()
        {
            isAlive = false;
            room.AddSoundEffect("link death");
        }

        public void Stop()
        {
            State.Stop();
        }

        public void HandleUp()
        {
            State.HandleUp();
        }

        public void HandleDown()
        {
            State.HandleDown();
        }

        public void HandleLeft()
        {
            State.HandleLeft();
        }

        public void HandleRight()
        {
            State.HandleRight();
        }

        public void HandleSword()
        {
            if (isAlive)
            {
                itemHelper.UseSword(health == maxHealth);
            }
        }

        public void HandleItem()
        {
            if (isAlive)
            {
                if (CurrentItem != PlayerItems.None && CurrentItem != PlayerItems.Candle)
                    ItemCounts[(int)CurrentItem]--;
                itemHelper.UseItem();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                State.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            if (isAlive)
            {
                State.Update();
            }
        }

        public void ReceiveItem(int n, PlayerItems item)
        {
            ItemCounts[(int)item] += n;
        }
    }
}
