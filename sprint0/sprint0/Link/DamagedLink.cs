using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// Author: Jesse He
namespace sprint0
{
    class DamagedLink : IPlayer
    {
        Game1 game;
        IPlayer decoratedLink;
        Direction direction;
        int timer = 80;

        public Vector2 Position { get => decoratedLink.Position; set => decoratedLink.Position = value; }
        public IPlayerState State { get => decoratedLink.State; set => decoratedLink.State = value; }

        public DamagedLink(IPlayer decoratedLink, Game1 game, Direction direction)
        {
            this.game = game;
            this.decoratedLink = decoratedLink;
            this.direction = direction;
        }

        public void Move(int x, int y)
        {
            decoratedLink.Move(x, y);
        }

        public void TakeDamage(Direction direction)
        {
            // no-op: does not take damage
        }

        public void RemoveDecorator()
        {
            game.Player = decoratedLink;
        }

        public void Stop()
        {
            decoratedLink.Stop();
        }

        public void HandleUp()
        {
            decoratedLink.HandleUp();
        }

        public void HandleDown()
        {
            decoratedLink.HandleDown();
        }

        public void HandleLeft()
        {
            decoratedLink.HandleLeft();
        }

        public void HandleRight()
        {
            decoratedLink.HandleRight();
        }

        public void HandleSword()
        {
            decoratedLink.HandleSword();
        }

        public void HandleZ()
        {
            decoratedLink.HandleZ();
        }

        public void HandleN()
        {
            decoratedLink.HandleN();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Change sprites to hurt pallates?--for now Link flashes on every frame
            if (timer % 2 == 0)
                decoratedLink.Draw(spriteBatch);
        }

        public void Update()
        {
            timer--;
            if (timer > 75)
            {
                switch (direction) {
                    case Direction.n:
                        decoratedLink.Move(0, 6);
                        break;
                    case Direction.s:
                        decoratedLink.Move(0, -6);
                        break;
                    case Direction.e:
                        decoratedLink.Move(-6, 0);
                        break;
                    case Direction.w:
                        decoratedLink.Move(6, 0);
                        break;
                }
            }
            else if (timer == 0)
            {
                RemoveDecorator();
            }

            decoratedLink.Update();
        }
    }
}
