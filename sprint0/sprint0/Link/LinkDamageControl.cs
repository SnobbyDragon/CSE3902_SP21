using System;
//Author: Stuti Shah
//Updated: 03/15/21 by shah.1440
namespace sprint0
{
    public class LinkDamageControl
    {
        private readonly PopulateHUDInventory manager;

        public LinkDamageControl(PopulateHUDInventory manage)
        {
            manager = manage;
        }

        public void TakeDamage(int damage)
        {
            manager.ChangeNum(PlayerItems.Heart, damage);
        }
    }
}
