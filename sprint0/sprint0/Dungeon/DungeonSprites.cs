using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

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
        public List<ISprite> LoadDungeonSprites()
        {
            List<ISprite> dungeonSprites = LoadMiscSprites();
            dungeonSprites.AddRange(LoadStatueSprites());
            dungeonSprites.AddRange(LoadWallSprites());
            dungeonSprites.AddRange(LoadDoorSprites());
            dungeonSprites.AddRange(LoadOpeningSprites());

            return dungeonSprites;
        }

        private List<ISprite> LoadMiscSprites()
        {
            List<ISprite> miscSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("block", new Vector2(600,200)),
                dungeonFactory.MakeSprite("tile", new Vector2(620,200)),
                dungeonFactory.MakeSprite("gap", new Vector2(640,200)),
                dungeonFactory.MakeSprite("stairs", new Vector2(660,200)),
                dungeonFactory.MakeSprite("ladder", new Vector2(680,200)),
                dungeonFactory.MakeSprite("brick", new Vector2(700,200)),
                dungeonFactory.MakeSprite("water", new Vector2(720,200)),
            };
            return miscSprites;
        }

        private List<ISprite> LoadStatueSprites()
        {
            List<ISprite> statueSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("left statue", new Vector2(720,220)),
                dungeonFactory.MakeSprite("right statue", new Vector2(700,220)),
            };
            return statueSprites;
        }

        private List<ISprite> LoadWallSprites()
        {
            List<ISprite> wallSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("up wall", new Vector2(600, 150)),
                dungeonFactory.MakeSprite("down wall", new Vector2(600, 150)),
                dungeonFactory.MakeSprite("left wall", new Vector2(600, 150)),
                dungeonFactory.MakeSprite("right wall", new Vector2(600, 150)),
            };
            return wallSprites;
        }

        private List<ISprite> LoadDoorSprites()
        {
            List<ISprite> doorSprites = new List<ISprite>
            {

                dungeonFactory.MakeSprite("up open door", new Vector2(640, 150)),
                dungeonFactory.MakeSprite("left open door", new Vector2(640, 150)),
                dungeonFactory.MakeSprite("right open door", new Vector2(640, 150)),
                dungeonFactory.MakeSprite("right locked door", new Vector2(680, 150)),
                dungeonFactory.MakeSprite("left locked door", new Vector2(680, 150)),
                dungeonFactory.MakeSprite("up locked door", new Vector2(680, 150)),
                dungeonFactory.MakeSprite("down shut door", new Vector2(680, 150)),
                dungeonFactory.MakeSprite("right shut door", new Vector2(680, 150)),
                dungeonFactory.MakeSprite("left shut door", new Vector2(680, 150)),
                dungeonFactory.MakeSprite("up shut door", new Vector2(680, 150)),
                dungeonFactory.MakeSprite("down shut door", new Vector2(680, 150)),
            };
            return doorSprites;
        }

        private List<ISprite> LoadOpeningSprites()
        {
            List<ISprite> openingSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("left bombed opening", new Vector2(720, 150)),
                dungeonFactory.MakeSprite("right bombed opening", new Vector2(720, 150)),
                dungeonFactory.MakeSprite("up bombed opening", new Vector2(720, 150)),
                dungeonFactory.MakeSprite("down bombed opening", new Vector2(720, 150)),
            };
            return openingSprites;
        }

        private List<ISprite> LoadDungeonBorderSprites()
        {
            List<ISprite> openingSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("left bombed opening", new Vector2(720, 150)),
                dungeonFactory.MakeSprite("right bombed opening", new Vector2(720, 150)),
                dungeonFactory.MakeSprite("up bombed opening", new Vector2(720, 150)),
                dungeonFactory.MakeSprite("down bombed opening", new Vector2(720, 150)),
            };
            return openingSprites;
        }

        private List<ISprite> LoadDungeonFloorSprites()
        {
            List<ISprite> openingSprites = new List<ISprite>
            {
                dungeonFactory.MakeSprite("left bombed opening", new Vector2(720, 150)),
                dungeonFactory.MakeSprite("right bombed opening", new Vector2(720, 150)),
                dungeonFactory.MakeSprite("up bombed opening", new Vector2(720, 150)),
                dungeonFactory.MakeSprite("down bombed opening", new Vector2(720, 150)),
            };
            return openingSprites;
        }
    }
}
