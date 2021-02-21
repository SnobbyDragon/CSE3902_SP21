using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

//Author: Stuti Shah
namespace sprint0
{
    public class DungeonSprites
    {
        Game1 game;
        DungeonFactory dungeonFactory;
        public DungeonSprites(Game1 game)
        {
            this.game = game;
            dungeonFactory = new DungeonFactory(this.game);
        }
        public List<ISprite> LoadDungeonSprites() //loads all dungeon sprites
        {
            List<ISprite> dungeonSprites = LoadMiscSprites();
            dungeonSprites.AddRange(LoadStatueSprites());
            dungeonSprites.AddRange(LoadWallSprites());
            dungeonSprites.AddRange(LoadDoorSprites());
            dungeonSprites.AddRange(LoadOpeningSprites());

            return dungeonSprites;
        }

        private List<ISprite> LoadMiscSprites() //only loads misc sprites
        {
            List<ISprite> miscSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("block", new Vector2(90,45)),
                dungeonFactory.MakeSprite("tile", new Vector2(90,45)),
                dungeonFactory.MakeSprite("gap", new Vector2(90,45)),
                dungeonFactory.MakeSprite("stairs", new Vector2(90,45)),
                dungeonFactory.MakeSprite("ladder", new Vector2(90,45)),
                dungeonFactory.MakeSprite("brick", new Vector2(90,45)),
                dungeonFactory.MakeSprite("water", new Vector2(90,45)),
            };
            return miscSprites;
        }

        private List<ISprite> LoadStatueSprites() //only loads statue sprites
        {
            List<ISprite> statueSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("left statue", new Vector2(90,45)),
                dungeonFactory.MakeSprite("right statue", new Vector2(90,45)),
            };
            return statueSprites;
        }

        private List<ISprite> LoadWallSprites() //loads wall sorites
        {
            List<ISprite> wallSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("up wall", new Vector2(90,45)),
                dungeonFactory.MakeSprite("down wall", new Vector2(90,45)),
                dungeonFactory.MakeSprite("left wall", new Vector2(90,45)),
                dungeonFactory.MakeSprite("right wall", new Vector2(90,45)),
            };
            return wallSprites;
        }

        private List<ISprite> LoadDoorSprites() //loads open, locked, and shut door sprites
        {
            List<ISprite> doorSprites = new List<ISprite>
            {

                dungeonFactory.MakeSprite("up open door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("left open door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("right open door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("right locked door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("left locked door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("up locked door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("down shut door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("right shut door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("left shut door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("up shut door", new Vector2(90,45)),
                dungeonFactory.MakeSprite("down shut door", new Vector2(90,45))
            };
            return doorSprites;
        }

        private List<ISprite> LoadOpeningSprites() //loads opening sprites
        {
            List<ISprite> openingSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("left bombed opening", new Vector2(90,45)),
                dungeonFactory.MakeSprite("right bombed opening", new Vector2(90,45)),
                dungeonFactory.MakeSprite("up bombed opening", new Vector2(90,45)),
                dungeonFactory.MakeSprite("down bombed opening", new Vector2(90,45)),
            };
            return openingSprites;
        }
    }
}
