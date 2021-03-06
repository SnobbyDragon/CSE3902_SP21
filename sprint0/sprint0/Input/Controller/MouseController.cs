using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace sprint0
{
    class MouseController : IController
    {
        Game1 game;
        ButtonState lButtonState;
        ButtonState rButtonState;
        List<ButtonState> previousStates;
        NextRoomCommand next;
        PreviousRoomCommand previous;
        public MouseController(Game1 game)
        {
            this.game = game;
            lButtonState = Mouse.GetState().LeftButton;
            rButtonState = Mouse.GetState().RightButton;
            next = new NextRoomCommand(this.game);
            previous = new PreviousRoomCommand(this.game);
            previousStates = new List<ButtonState>
            {
                Mouse.GetState().LeftButton,
                Mouse.GetState().RightButton,
            };
        }
        public void Update()
        {
            lButtonState = Mouse.GetState().LeftButton;
            rButtonState = Mouse.GetState().RightButton;
            //If right click exit the game
            if (rButtonState == ButtonState.Pressed && previousStates[1] != ButtonState.Pressed)
            {
                next.Execute();
            }
            else if (lButtonState == ButtonState.Pressed && previousStates[0] != ButtonState.Pressed)
            {
                previous.Execute();
            }
            previousStates[0] = Mouse.GetState().LeftButton;
            previousStates[1] = Mouse.GetState().RightButton;

        }

        public void Initialize()
        {
            // no-op for now
        }
    }
}
