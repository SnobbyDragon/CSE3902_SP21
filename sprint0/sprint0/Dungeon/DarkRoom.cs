using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Neha Gupta

namespace sprint0
{
    public class DarkRoom : ISprite
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private RenderTarget2D darkness;
        private GraphicsDevice graph;
        private Color brightness;
        int SpotlightX, SpotlightY;
        int width = 100;
        Game1 game;

        public DarkRoom(Texture2D texture, Vector2 location, Game1 game)
        {
            Texture = texture;
            this.game = game;
            source = new Rectangle(996, 76, 47, 42);
            brightness = Color.Black;
            graph = game.GraphicsDevice;
            darkness = new RenderTarget2D(graph, Game1.Width + Game1.BorderThickness, Game1.MapHeight + Game1.BorderThickness);
            graph.SetRenderTarget(darkness);
            graph.Clear(Color.Black);
            graph.SetRenderTarget(null);
            SpotlightX = 0;
            SpotlightY = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!game.Room.Overlay.Sprites.Contains(this) && game.RoomIndex == 5) {
                game.Room.Overlay.AddOverlay(this);
            }
            else if (game.Room.Overlay.Sprites.Contains(this) && game.Room.Overlay.Sprites.IndexOf(this) != game.Room.Overlay.Sprites.Count - 1)
            {              
                    game.Room.Overlay.RemoveOverlay(this);
                    game.Room.Overlay.AddOverlay(this);
            }
            foreach (IProjectile project in game.Room.LoadLevel.RoomProjectile.Projectiles)
            {
                if (project is FlameProjectile)
                {
                    brightness = Color.Black;
                    return;
                }
            }
            if (game.Room.Player.HasItem(PlayerItems.BlueCandle) || game.Room.Player.HasItem(PlayerItems.RedCandle))
            {
                SpotlightX = (int)game.Room.Player.Pos.X - 30;
                SpotlightY = (int)game.Room.Player.Pos.Y - 30;
                spriteBatch.Draw(Texture, new Rectangle((int)game.Room.Offset.X + SpotlightX, (int)game.Room.Offset.Y + SpotlightY, width, width), source, brightness);
            }
            else
            {
                SpotlightX = 0;
                SpotlightY = 0;
            }
            spriteBatch.Draw(darkness, new Rectangle((int)game.Room.Offset.X, (int)game.Room.Offset.Y + Game1.HUDHeight * (int)Game1.Scale, SpotlightX, (Game1.MapHeight + Game1.BorderThickness * 2) * (int)Game1.Scale), brightness);
            spriteBatch.Draw(darkness, new Rectangle((int)game.Room.Offset.X + SpotlightX, (int)game.Room.Offset.Y + Game1.HUDHeight * (int)Game1.Scale, (Game1.Width + Game1.BorderThickness * 2) * (int)Game1.Scale - SpotlightX, SpotlightY - Game1.HUDHeight * (int)Game1.Scale), brightness);
            spriteBatch.Draw(darkness, new Rectangle((int)game.Room.Offset.X + SpotlightX, (int)game.Room.Offset.Y + SpotlightY + width, (Game1.Width + Game1.BorderThickness * 2) * (int)Game1.Scale - SpotlightX, ((Game1.MapHeight + Game1.HUDHeight + (Game1.BorderThickness * 2)) * (int)Game1.Scale) - SpotlightY - width), brightness);
            spriteBatch.Draw(darkness, new Rectangle((int)game.Room.Offset.X + SpotlightX + width, (int)game.Room.Offset.Y + SpotlightY, (Game1.Width + Game1.BorderThickness * 2) * (int)Game1.Scale, width), brightness);
        }

        public void Update()
        {
        }
        public bool IsAlive()
        {
            return true;
        }
    }
}
