using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class HUDFactory
    {
        readonly Game1 game;
        readonly Texture2D texture;
        readonly int nameLen = 4;

        public HUDFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/HUDPauseScreen");
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {
            //note: wherever the location is modified is how far the corresponding object is from the top-left corner of the HUD
            String subSpriteType = spriteType.Substring(0, nameLen);
            String numString = spriteType[nameLen..];
            switch (subSpriteType)
            {

                case "hudM":
                    return new HUD(texture, location);

                case "hudA":
                    //spriteType format: hudA <itemName>
                    return new HUDItemA(texture, new Vector2(location.X + 153 * Game1.Scale, location.Y + 24 * Game1.Scale), spriteType[(nameLen + 1)..]);

                case "hudB":
                    //spriteType format: hudB <itemName>
                    return new HUDItemB(texture, new Vector2(location.X + 128 * Game1.Scale, location.Y + 24 * Game1.Scale), spriteType[(nameLen + 1)..]);

                case "rin ": //rupee inventory
                    //spriteType format: rin <rupeeAmount>
                    int rupeeNum;
                    int.TryParse(numString, out rupeeNum);
                    return new RupeeHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 16 * Game1.Scale), rupeeNum);

                case "kin ":
                    //spriteType format: kin <keyAmount>
                    int keyNum;
                    int.TryParse(numString, out keyNum);
                    return new KeyHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 32 * Game1.Scale), keyNum);

                case "bin ": //bomb inventory
                    //spriteType format: bin <bombAmount>
                    int bombNum;
                    int.TryParse(numString, out bombNum);

                    return new BombHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 40 * Game1.Scale), bombNum);

                case "hin ": //heart inventory/state
                    //spriteType format: hin <halfHeartAmount>,<fullHeartAmount>
                    String[] heartNumString = numString.Split(',');
                    int[] heartNum = { 0, 0, 0 }; //array that stores the number of empty, half, and full hearts
                    int sum = 16; //total number of hearts

                    for (int i = 0; i < heartNumString.Length; i++)
                    {
                        int.TryParse(heartNumString[i], out heartNum[i + 1]);
                        sum -= heartNum[i + 1];
                    }
                    heartNum[0] = sum;
                    /* 
                     * heartNum[0] : # of empty hearts 
                     * heartNum[1] : # of half hearts
                     * heartNum[2] : # of full hearts
                    */
                    return new HeartHUD(texture, new Vector2(location.X + 176 * Game1.Scale, location.Y + 32 * Game1.Scale), heartNum);

                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
