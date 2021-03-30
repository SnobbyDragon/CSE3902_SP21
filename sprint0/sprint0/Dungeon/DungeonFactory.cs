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

        public DungeonFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/DungeonTileset");
        }

        public ISprite MakeSprite(string spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "room floor plain" => new RoomFloor(texture, location),
                "room border" => new RoomBorder(texture, location),
                "darkness" => new Darkness(texture, location),
                "ladder" => new Ladder(texture, location),
                "down wall" => new Wall(texture, location, Direction.n, game),
                "right wall" => new Wall(texture, location, Direction.w, game),
                "left wall" => new Wall(texture, location, Direction.e, game),
                "up wall" => new Wall(texture, location, Direction.s, game),
                "down open door" => new OpenDoor(texture, location, Direction.n, game),
                "right open door" => new OpenDoor(texture, location, Direction.w, game),
                "left open door" => new OpenDoor(texture, location, Direction.e, game),
                "up open door" => new OpenDoor(texture, location, Direction.s, game),
                "down locked door" => new LockedDoor(texture, location, Direction.n, game),
                "right locked door" => new LockedDoor(texture, location, Direction.w, game),
                "left locked door" => new LockedDoor(texture, location, Direction.e, game),
                "up locked door" => new LockedDoor(texture, location, Direction.s, game),
                "down shut door" => new ShutDoor(texture, location, Direction.n, game),
                "right shut door" => new ShutDoor(texture, location, Direction.w, game),
                "left shut door" => new ShutDoor(texture, location, Direction.e, game),
                "up shut door" => new ShutDoor(texture, location, Direction.s, game),
                "down bombed opening" => new BombedOpening(texture, location, Direction.n, game),
                "right bombed opening" => new BombedOpening(texture, location, Direction.w, game),
                "left bombed opening" => new BombedOpening(texture, location, Direction.e, game),
                "up bombed opening" => new BombedOpening(texture, location, Direction.s, game),
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
