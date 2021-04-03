using System;
namespace sprint0
{
    public class WeaponBorderCollisionHandler
    {
        public WeaponBorderCollisionHandler()
        {
        }

        public void HandleCollision(IWeapon weapon, ISprite border, Direction side)
        {
            if (weapon is Bomb bomb && border is Wall wall && bomb.Exploding)
            {
                wall.BombWall();
            }
        }
    }
}
