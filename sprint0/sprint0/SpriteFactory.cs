using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class SpriteFactory
    {
        Game1 game;

        public SpriteFactory(Game1 game)
        {
            this.game = game;
        }

        public ISprite MakeSprite(String spriteType)
        {
            Texture2D texture;
            switch (spriteType)
            {
                case "old man 1":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new OldPerson(texture, new Rectangle(1,11,16,16));
                case "old man 2":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new OldPerson(texture, new Rectangle(18, 11, 16, 16));
                case "old woman":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new OldPerson(texture, new Rectangle(35, 11, 16, 16));
                case "green merchant":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new Merchant(texture, new Rectangle(109, 11, 16, 16));
                case "white merchant":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new Merchant(texture, new Rectangle(126, 11, 16, 16));
                case "red merchant":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new Merchant(texture, new Rectangle(143, 11, 16, 16));
                default:
                    return null;
            }
        }
    }
}
