using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public class DungeonFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;
        private readonly int roomIndex;

        public DungeonFactory(Game1 game, int roomIndex)
        {
            this.game = game;
            this.roomIndex = roomIndex;
            texture = game.Content.Load<Texture2D>("Images/DungeonTileset");
        }

        public ISprite MakeSprite(string spriteType, Vector2 location, bool canBeBombed = false)
        {
            return spriteType switch
            {
                "room floor plain" => new RoomFloor(texture, location),
                "room border" => new RoomBorder(texture, location),
                "darkness" => new Darkness(texture, location),
                "down wall" => new Wall(texture, location, Direction.n, game.Rooms[roomIndex], canBeBombed),
                "right wall" => new Wall(texture, location, Direction.w, game.Rooms[roomIndex], canBeBombed),
                "left wall" => new Wall(texture, location, Direction.e, game.Rooms[roomIndex], canBeBombed),
                "up wall" => new Wall(texture, location, Direction.s, game.Rooms[roomIndex], canBeBombed),
                "down open door" => new OpenDoor(texture, location, Direction.n, game.Rooms[roomIndex]),
                "right open door" => new OpenDoor(texture, location, Direction.w, game.Rooms[roomIndex]),
                "left open door" => new OpenDoor(texture, location, Direction.e, game.Rooms[roomIndex]),
                "up open door" => new OpenDoor(texture, location, Direction.s, game.Rooms[roomIndex]),
                "down locked door" => new LockedDoor(texture, location, Direction.n, game.Rooms[roomIndex]),
                "right locked door" => new LockedDoor(texture, location, Direction.w, game.Rooms[roomIndex]),
                "left locked door" => new LockedDoor(texture, location, Direction.e, game.Rooms[roomIndex]),
                "up locked door" => new LockedDoor(texture, location, Direction.s, game.Rooms[roomIndex]),
                "down shut door" => new ShutDoor(texture, location, Direction.n, game.Rooms[roomIndex]),
                "right shut door" => new ShutDoor(texture, location, Direction.w, game.Rooms[roomIndex]),
                "left shut door" => new ShutDoor(texture, location, Direction.e, game.Rooms[roomIndex]),
                "up shut door" => new ShutDoor(texture, location, Direction.s, game.Rooms[roomIndex]),
                "down bombed opening" => new BombedOpening(texture, location, Direction.n, game.Rooms[roomIndex]),
                "right bombed opening" => new BombedOpening(texture, location, Direction.w, game.Rooms[roomIndex]),
                "left bombed opening" => new BombedOpening(texture, location, Direction.e, game.Rooms[roomIndex]),
                "up bombed opening" => new BombedOpening(texture, location, Direction.s, game.Rooms[roomIndex]),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }

        public IBlock MakeBlock(string spriteType, Vector2 location, int width = InvisibleBlock.DefaultSize, int height = InvisibleBlock.DefaultSize)
        {
            return spriteType switch
            {
                "block" => new Block(texture, location),
                "tile" => new Tile(texture, location),
                "gap" => new Gap(texture, location),
                "water" => new Water(texture, location),
                "floor" => new Floor(texture, location),
                "stairs" => new Stairs(texture, location),
                "ladder" => new Ladder(texture, location),
                "brick" => new Brick(texture, location),
                "left statue" => new Statue(texture, location, Direction.e, game),
                "right statue" => new Statue(texture, location, Direction.w, game),
                "movable block" => new MovableBlock(texture, location),
                "invisible block" => new InvisibleBlock(location, width, height),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }
    }
}
