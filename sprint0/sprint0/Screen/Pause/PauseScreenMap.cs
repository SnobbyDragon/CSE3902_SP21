using System;
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
            if (game.hudManager.HasItem(PlayerItems.Map))
                DrawMap(spriteBatch);
            if (game.hudManager.HasItem(PlayerItems.Compass))
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
