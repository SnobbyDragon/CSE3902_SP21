using System;
using System.Collections.Generic;
using System.Text;

namespace sprint0
{
    class UpIdleState : IPlayerState
    {
        private ISprite sprite;
        public ISprite Sprite { get => sprite; set => sprite = value; }

        public UpIdleState(ISprite sprite)
        {
            this.sprite = sprite;
        }
    }
}
