using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class HUDMiniMap : HUDMiniMapping
    {
        public Texture2D Texture { get; set; }
        public Rectangle Location { get; set; }
        private Game1 game;
        int currentRoom;
        public HUDMiniMap(Game1 game)
        {
            this.game = game;
            Texture = new HUDFactory(this.game).Texture;
            currentRoom = this.game.RoomIndex;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (game.hudManager.HasMap())
            {
                DrawMap(spriteBatch);
            }
            if (!overlap.ContainsKey(currentRoom))
                spriteBatch.Draw(Texture, roomPos[currentRoom], source[(int)RoomPosition.Location], Color.White);
            else spriteBatch.Draw(Texture, new Rectangle(roomPos[overlap[currentRoom]].X, roomPos[overlap[currentRoom]].Y + sideLength / 4 + 2,
                roomPos[overlap[currentRoom]].Width, roomPos[overlap[currentRoom]].Height), source[(int)RoomPosition.Location], Color.White);
            spriteBatch.Draw(Texture, new Rectangle((int)(64 * Game1.Scale), (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale), (int)(sideLength * Game1.Scale)), source[(int)RoomPosition.LevelNum], Color.White);
        }

        private void DrawMap(SpriteBatch spriteBatch)
        {
            foreach (Dictionary<int, int> mapping in fullMapping)
            {
                foreach (KeyValuePair<int, int> roomMap in mapping)
                    spriteBatch.Draw(Texture, roomPos[roomMap.Key], source[roomMap.Value], Color.White);
            }
        }

        public void Update() => currentRoom = game.RoomIndex;
    }
}
