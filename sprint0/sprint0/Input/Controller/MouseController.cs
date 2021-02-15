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

        public MouseController(Game1 game) {
            this.game = game;
            quit = new QuitCommand(game);
     
        }

        public void Update()
        {
            //no-op for now
        }

        public void Initialize()
        {
            // no-op for now
        }
    }
}
