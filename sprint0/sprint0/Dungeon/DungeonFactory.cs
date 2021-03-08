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

        public ISprite MakeSprite(string spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "room floor plain" => new RoomFloor(texture, location),
                "room border" => new RoomBorder(texture, location),
                "darkness" => new Darkness(texture, location),
                "block" => new Block(texture, location),
                "tile" => new Tile(texture, location),
                "gap" => new Gap(texture, location),
                "water" => new Water(texture, location),
                "floor" => new Floor(texture, location),
                "stairs" => new Stairs(texture, location),
                "ladder" => new Ladder(texture, location),
                "brick" => new Brick(texture, location),
                "left statue" => new Statue(texture, location, "left", game),
                "right statue" => new Statue(texture, location, "right", game),
                "down wall" => new Wall(texture, location, "down"),
                "right wall" => new Wall(texture, location, "right"),
                "left wall" => new Wall(texture, location, "left"),
                "up wall" => new Wall(texture, location, "up"),
                "down open door" => new OpenDoor(texture, location, "down"),
                "right open door" => new OpenDoor(texture, location, "right"),
                "left open door" => new OpenDoor(texture, location, "left"),
                "up open door" => new OpenDoor(texture, location, "up"),
                "down locked door" => new LockedDoor(texture, location, "down"),
                "right locked door" => new LockedDoor(texture, location, "right"),
                "left locked door" => new LockedDoor(texture, location, "left"),
                "up locked door" => new LockedDoor(texture, location, "up"),
                "down shut door" => new ShutDoor(texture, location, "down"),
                "right shut door" => new ShutDoor(texture, location, "right"),
                "left shut door" => new ShutDoor(texture, location, "left"),
                "up shut door" => new ShutDoor(texture, location, "up"),
                "down bombed opening" => new BombedOpening(texture, location, "down"),
                "right bombed opening" => new BombedOpening(texture, location, "right"),
                "left bombed opening" => new BombedOpening(texture, location, "left"),
                "up bombed opening" => new BombedOpening(texture, location, "up"),
                "movable block" => new MovableBlock(texture, location),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }

        public IBlock MakeBlock(string spriteType, Vector2 location)
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
                "left statue" => new Statue(texture, location, "left", game),
                "right statue" => new Statue(texture, location, "right", game),
                "movable block" => new MovableBlock(texture, location),
                _ => throw new ArgumentException("Invalid sprite! Sprite factory failed."),
            };
        }
    }
}
