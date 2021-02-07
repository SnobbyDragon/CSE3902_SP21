using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace sprint0
{
    public interface IPlayer
    {
        IPlayerState State { get; set; }
        Vector2 Position { get; set; }
    }
}
