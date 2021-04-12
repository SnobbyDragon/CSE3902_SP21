using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace sprint0
{
    class MouseController : IController
    {
        private readonly Game1 game;
        private ButtonState lButtonState;
        private ButtonState rButtonState;
        private readonly List<ButtonState> previousStates;
        private readonly NextRoomCommand next;
        private readonly PreviousRoomCommand previous;

        public MouseController(Game1 game)
        {
            this.game = game;
            next = new NextRoomCommand(this.game);
            previous = new PreviousRoomCommand(this.game);

            lButtonState = Mouse.GetState().LeftButton;
            rButtonState = Mouse.GetState().RightButton;
            previousStates = new List<ButtonState>
            {
                lButtonState,
                rButtonState
            };
        }
        public void Update()
        {
            lButtonState = Mouse.GetState().LeftButton;
            rButtonState = Mouse.GetState().RightButton;
            if (rButtonState == ButtonState.Pressed && previousStates[1] != ButtonState.Pressed)
                next.Execute();
            else if (lButtonState == ButtonState.Pressed && previousStates[0] != ButtonState.Pressed)
                previous.Execute();
            previousStates[0] = Mouse.GetState().LeftButton;
            previousStates[1] = Mouse.GetState().RightButton;
        }
        public void Initialize() { }
    }
}
