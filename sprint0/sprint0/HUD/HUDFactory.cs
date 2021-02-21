using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
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
            /*
             * spriteType format for HUD:
             * 
             * hud: N/A
             * item A: hudA <itemName>
             * item B: hudB <itemName>
             * rupee inventopry: rin <rupeeAmount>
             * key inventory: kin <keyAmount>
             * bomb inventory: bin <bombAmount>
             * heart state: hin <halfHeartAmount>,<fullHeartAmount>
             */

            //note: wherever the location is modified is how far the corresponding object is from the top-left corner of the HUD
            String subSpriteType = spriteType.Substring(0, nameLen);
            String numString = spriteType[nameLen..];
            switch (subSpriteType)
            {
                //hud
                case "hudM":
                    return new HUD(texture, location);


                //item A
                case "hudA":
                    return new HUDItemA(texture, new Vector2(location.X + 153 * Game1.Scale, location.Y + 24 * Game1.Scale), spriteType[(nameLen + 1)..]);

                //item B
                case "hudB":
                    return new HUDItemB(texture, new Vector2(location.X + 128 * Game1.Scale, location.Y + 24 * Game1.Scale), spriteType[(nameLen + 1)..]);

                //rupee inventory
                case "rin ":
                    int rupeeNum;

                    //get number of rupees
                    int.TryParse(numString, out rupeeNum);
                    return new RupeeHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 16 * Game1.Scale), rupeeNum);

                //key inventory
                case "kin ":
                    int keyNum;

                    //get number of keys
                    int.TryParse(numString, out keyNum);
                    return new KeyHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 32 * Game1.Scale), keyNum);

                //bomb inventory
                case "bin ":
                    int bombNum;

                    //get number of bombs
                    int.TryParse(numString, out bombNum);
                    return new BombHUD(texture, new Vector2(location.X + 97 * Game1.Scale, location.Y + 40 * Game1.Scale), bombNum);


                //heart state
                case "hin ": //heart inventory/state
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
