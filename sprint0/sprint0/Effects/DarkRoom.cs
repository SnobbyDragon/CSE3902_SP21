using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Neha Gupta

namespace sprint0
{
    public class DarkRoom : IEffect
    {

        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private RenderTarget2D darkness;
        private GraphicsDevice graph;
        private Color brightness;
        int x, y;
        int width = 100;
        Game1 game;

        public DarkRoom(Texture2D texture, Vector2 location, Game1 game)
        {
            Texture = texture;
            this.game = game;
            source = new Rectangle(1023,60,20, 19);
            brightness = Color.Black;
            graph = game.GraphicsDevice;
            darkness = new RenderTarget2D(graph, Game1.Width + Game1.BorderThickness, Game1.MapHeight + Game1.BorderThickness);
            graph.SetRenderTarget(darkness);
            graph.Clear(new Color(0, 0, 0, 255));
            graph.SetRenderTarget(null);
            x = 0;
            y = 0;
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {                    
            foreach (IProjectile project in game.Room.LoadLevel.RoomProjectile.Projectiles){
                if (project is FlameProjectile)
                {
                    brightness = Color.Black;
                    return;
                }
            }
            if (game.Room.Player.HasItem(PlayerItems.BlueCandle) || game.Room.Player.HasItem(PlayerItems.RedCandle))
            {               
                x = (int)game.Room.Player.Pos.X-30;
                y = (int)game.Room.Player.Pos.Y-30;
                spriteBatch.Draw(Texture, new Rectangle(x, y, width, width),source, brightness);
            }
            else
            {
                x = 0;
                y = 0;
            }

            spriteBatch.Draw(darkness, new Rectangle(0, Game1.HUDHeight * (int)Game1.Scale, x, (Game1.MapHeight+ Game1.BorderThickness*2)* (int)Game1.Scale), brightness);
            spriteBatch.Draw(darkness, new Rectangle(x, Game1.HUDHeight * (int)Game1.Scale, (Game1.Width + Game1.BorderThickness * 2) * (int)Game1.Scale -x , y- Game1.HUDHeight * (int)Game1.Scale), brightness);
            spriteBatch.Draw(darkness, new Rectangle(x, y + width ,(Game1.Width + Game1.BorderThickness * 2) * (int)Game1.Scale -x, ((Game1.MapHeight + Game1.HUDHeight + (Game1.BorderThickness*2))*(int)Game1.Scale)-y-width), brightness);
            spriteBatch.Draw(darkness, new Rectangle(x+width, y, (Game1.Width + Game1.BorderThickness * 2) * (int)Game1.Scale, width), brightness);           
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
