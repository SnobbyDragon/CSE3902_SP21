using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class HUDFactory
    {
        Game1 game;
        Texture2D texture;
        int nameLen = 11;

        public HUDFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/HUDPauseScreen");
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {

            if (spriteType.Equals("hud"))
            {
                return new HUD(texture, location);
            }
            else
            {
                String subSpriteType = spriteType.Substring(0, nameLen);
                String numString = spriteType.Substring(nameLen);
                switch (subSpriteType)
                {

                    case "rinventory ": //rupee inventory

                        int rupeeNum = 0;
                        int.TryParse(numString, out rupeeNum);

                        return new RupeeHUD(texture, new Vector2(location.X + 97, location.Y + 16), rupeeNum);
                    //location: 96, 16 plus HUD location
                    case "kinventory ":

                        int keyNum = 0;
                        int.TryParse(numString, out keyNum);

                        return new KeyHUD(texture, new Vector2(location.X + 97, location.Y + 32), keyNum);

                    case "binventory ": //bomb inventory

                        int bombNum = 0;
                        int.TryParse(numString, out bombNum);

                        return new BombHUD(texture, new Vector2(location.X + 97, location.Y + 40), bombNum);

                    case "hinventory ": //heart inventory/state

                        String[] heartNumString = numString.Split(',');
                        int[] heartNum = { 0, 0, 0 };
                        int sum = 16;

                        for (int i = 0; i < heartNumString.Length; i++)
                        {
                            int.TryParse(heartNumString[i], out heartNum[i + 1]);
                            sum -= heartNum[i + 1];
                        }
                        heartNum[0] = sum;

                        return new HeartHUD(texture, new Vector2(location.X + 177, location.Y + 32), heartNum);

                    default:
                        throw new ArgumentException("Invalid sprite! Sprite factory failed.");
                }
            }
        }
    }
}
