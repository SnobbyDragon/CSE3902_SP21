﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0
{
    public class PauseScreenMap : PauseScreenMapping
    {
        public Rectangle Location { get; set; }
        private Game1 game;
        public Texture2D Texture { get; set; }

        private int currentRoom;
        public PauseScreenMap(Game1 game)
        {
            this.game = game;
            Texture = new HUDFactory(this.game).Texture;
            currentRoom = game.RoomIndex;
        }

        public void Update() => currentRoom = game.RoomIndex;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)((baseX - sideLength) * Game1.Scale), (int)((baseY - sideLength) * Game1.Scale), (int)(sideLength * 9 * Game1.Scale), (int)(sideLength * 9 * Game1.Scale)), sources[(int)RoomDirection.Empty], Color.White);
            if (game.hudManager.HasMap())
                DrawMap(spriteBatch);
            if (game.hudManager.HasCompass())
                spriteBatch.Draw(Texture, new Rectangle(roomPos[currentRoom].X + 6, roomPos[currentRoom].Y + 6, roomPos[currentRoom].Width, roomPos[currentRoom].Height), sources[(int)RoomDirection.Location], Color.White);
        }

        private void DrawMap(SpriteBatch spriteBatch)
        {
            foreach (Dictionary<int, int> mapping in fullMapping)
            {
                foreach (KeyValuePair<int, int> roomMap in mapping)
                    if (game.VisitedRooms.Contains(roomMap.Key))
                        spriteBatch.Draw(Texture, roomPos[roomMap.Key], sources[roomMap.Value], Color.White);
            }
        }
    }
}