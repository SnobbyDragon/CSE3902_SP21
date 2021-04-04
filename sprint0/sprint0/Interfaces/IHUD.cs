using System;
using System.Collections.Generic;
using System.Text;

//Author: Stuti Shah
//Updated: 03/24/21 by shah.1440
namespace sprint0
{
    public interface IHUD : ISprite
    {
        public PlayerItems Item { get; set; }
        void SetItem(PlayerItems item);
        void SetAItem(PlayerItems item);
    }
}
