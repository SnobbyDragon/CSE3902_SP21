using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Authors: Jesse He and Jacob Urick

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

        /*
         * Note! A count of any number less than 0 is infinite.
         */
        private int arrowCount = -1;
        private int bombCount = -1;
        private int boomerangCount = 1;
        public Vector2 Pos { get => position; set => position = value; }
        public IPlayerState State { get => state; set => state = value; }
        Direction IPlayer.Direction { get => direction; set => direction = value; }

        // TODO Make this change with different color of sword
        public int WeaponDamage { get; set; }

        public Link(Game1 game, Vector2 pos)
        {
            WeaponDamage = 2;
            isAlive = true;
            this.game = game;
            position = pos;
            State = new UpIdleState(this);
            speed = 2;
        }

        public void Move(int x, int y)
        {
            position += new Vector2(speed*x, speed*y);
        }

        public void TakeDamage(Direction direction, int damage)
        {
            game.Player = new DamagedLink(this, game, direction);
            health -= damage;
            if (health < 0) Die();
        }

        public void PickUpItem()
        {
            State.PickUpItem();
        }

        public void Shoot() {
            Vector2 offsetPos = position;
            switch (direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(position.X + 6, position.Y - 11);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(position.X + 6, position.Y + 16);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(position.X + 16, position.Y);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(position.X, position.Y);
                    break;
            }
            game.AddProjectile(offsetPos, direction, "arrow", this);
        }

        private void Die() {
            isAlive = false;
        }

        public void ThrowBomb()
        {
            Vector2 offsetPos = position;
            switch (direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(position.X + 3, position.Y - 16);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(position.X + 5, position.Y + 16);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(position.X + 16, position.Y);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(position.X - 10, position.Y);
                    break;
            }
            game.AddWeapon(offsetPos, direction, "bomb", this);
        }

        public void ThrowBoomerang()
        {
            Vector2 offsetPos = position;
            switch (direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(position.X + 3, position.Y);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(position.X + 5, position.Y + 16);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(position.X + 16, position.Y + 6);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(position.X, position.Y + 6);
                    break;
            }
            game.AddProjectile(offsetPos, direction, "boomerang", this);
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
            State.HandleSword();
            Vector2 offsetPos = position;
            switch (direction)
            {
                case Direction.n:
                    offsetPos = new Vector2(position.X + 8, position.Y);
                    break;
                case Direction.s:
                    offsetPos = new Vector2(position.X + 12, position.Y + 16);
                    break;
                case Direction.e:
                    offsetPos = new Vector2(position.X + 32, position.Y + 15);
                    break;
                case Direction.w:
                    offsetPos = new Vector2(position.X, position.Y + 15);
                    break;
            }
            game.AddWeapon(offsetPos, direction, "sword", this);
            if (health == maxHealth)
            {
                game.AddProjectile(offsetPos, direction, "sword beam", this);
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

        public void HandleShoot()
        {
            if (isAlive)
            {
                if (arrowCount != 0)
                {
                    arrowCount--;
                    Shoot();
                    State.UseItem();
                }
            }
        }

        public void HandleBomb()
        {
            if (isAlive)
            {
                if (bombCount != 0)
                {
                    bombCount--;
                    ThrowBomb();
                    State.UseItem();
                }
            }
        }

        public void HandleBoomerang()
        {
            if (isAlive)
            {
                if (boomerangCount != 0)
                {
                    boomerangCount--;
                    ThrowBoomerang();
                    State.UseItem();
                }
            }
        }

        public void HandleCandle()
        {
            if (isAlive)
            {
                Vector2 offsetPos = position;
                switch (direction)
                {
                    case Direction.n:
                        offsetPos = new Vector2(position.X, position.Y - 16);
                        break;
                    case Direction.s:
                        offsetPos = new Vector2(position.X, position.Y + 16);
                        break;
                    case Direction.e:
                        offsetPos = new Vector2(position.X + 16, position.Y);
                        break;
                    case Direction.w:
                        offsetPos = new Vector2(position.X - 16, position.Y);
                        break;
                }
                game.AddProjectile(offsetPos, direction, "flame", this);
                State.UseItem();
            }
        }

        public void ReceiveBomb(int n)
        {
            bombCount += n;
        }

        public void ReceiveArrow(int n)
        {
            arrowCount += n;
        }

        public void ReceiveBoomerang(int n)
        {
            boomerangCount += n;
        }
    }
}
