using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class MouseController : IController
    {
        Game1 game;
        ICommand quit;
        ICommand nonMovingNonAnimated;
        ICommand nonMovingAnimated;
        ICommand movingNonAnimated;
        ICommand movingAnimated;

        public MouseController(Game1 game) {
            this.game = game;
            quit = new QuitCommand(game);
            nonMovingNonAnimated = new NonMovingNonAnimatedCommand(game);
            nonMovingAnimated = new NonMovingAnimatedCommand(game);
            movingNonAnimated = new MovingNonAnimatedCommand(game);
            movingAnimated = new MovingAnimatedCommand(game);
        }

        public void Update()
        {
            MouseState State = Mouse.GetState();
            if (State.RightButton == ButtonState.Pressed)
            {
                quit.Execute();
            }
            else if (State.LeftButton == ButtonState.Pressed)
            {
                if (State.Y < game.Window.ClientBounds.Height / 2)
                {
                    if (State.X < game.Window.ClientBounds.Width / 2)
                        nonMovingNonAnimated.Execute();
                    else
                        nonMovingAnimated.Execute();
                }
                else
                {
                    if (State.X < game.Window.ClientBounds.Width / 2)
                        movingNonAnimated.Execute();
                    else
                        movingAnimated.Execute();
                }
            }
        }
    }
}
