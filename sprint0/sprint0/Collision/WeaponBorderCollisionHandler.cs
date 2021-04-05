using System;
namespace sprint0
{
    public class WeaponBorderCollisionHandler
    {
        public WeaponBorderCollisionHandler()
        {
        }

        public void HandleCollision(IWeapon weapon, ISprite border, Direction side, Game1 game)
        {
            if (weapon is Bomb bomb && border is Wall wall && bomb.Exploding)
            {
                wall.BombWall();
                foreach (ISprite sprite in game.Rooms[AdjacentRooms.GetAdjacentRoom(game.RoomIndex, side)].LoadLevel.RoomSprite.RoomSprites)
                    if (sprite is Wall adjWall && adjWall.Side == DirectionMethods.OppositeDirection(side))
                        adjWall.BombWall();
            }
        }
    }
}
