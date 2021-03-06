using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public class DungeonFactory
    {
        private Game1 game;
        private Texture2D texture;

        public DungeonFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/DungeonTileset");

        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {

            switch (spriteType)
            {

                case "room floor plain":
                    return new RoomFloor(texture, location);
                case "room border":
                    return new RoomBorder(texture, location);
                case "block":
                    return new Block(texture, location);
                case "tile":
                    return new Tile(texture, location);
                case "gap":
                    return new Gap(texture, location);
                case "water":
                    return new Water(texture, location);
                case "floor":
                    return new Floor(texture, location);
                case "stairs":
                    return new Stairs(texture, location);
                case "ladder":
                    return new Ladder(texture, location);
                case "brick":
                    return new Brick(texture, location);
                case "left statue":
                    return new Statue(texture, location, "left");
                case "right statue":
                    return new Statue(texture, location, "right");
                case "down wall":
                    return new Wall(texture, location, "down");
                case "right wall":
                    return new Wall(texture, location, "right");
                case "left wall":
                    return new Wall(texture, location, "left");
                case "up wall":
                    return new Wall(texture, location, "up");
                case "down open door":
                    return new OpenDoor(texture, location, "down");
                case "right open door":
                    return new OpenDoor(texture, location, "right");
                case "left open door":
                    return new OpenDoor(texture, location, "left");
                case "up open door":
                    return new OpenDoor(texture, location, "up");
                case "down locked door":
                    return new LockedDoor(texture, location, "down");
                case "right locked door":
                    return new LockedDoor(texture, location, "right");
                case "left locked door":
                    return new LockedDoor(texture, location, "left");
                case "up locked door":
                    return new LockedDoor(texture, location, "up");
                case "down shut door":
                    return new ShutDoor(texture, location, "down");
                case "right shut door":
                    return new ShutDoor(texture, location, "right");
                case "left shut door":
                    return new ShutDoor(texture, location, "left");
                case "up shut door":
                    return new ShutDoor(texture, location, "up");
                case "down bombed opening":
                    return new BombedOpening(texture, location, "down");
                case "right bombed opening":
                    return new BombedOpening(texture, location, "right");
                case "left bombed opening":
                    return new BombedOpening(texture, location, "left");
                case "up bombed opening":
                    return new BombedOpening(texture, location, "up");
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
