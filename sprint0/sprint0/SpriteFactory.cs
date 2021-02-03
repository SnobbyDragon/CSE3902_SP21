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
                    return new OldPerson(texture, "man 1");
                case "old man 2":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new OldPerson(texture, "man 2");
                case "old woman":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new OldPerson(texture, "woman");
                case "green merchant":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new Merchant(texture, "green");
                case "white merchant":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new Merchant(texture, "white");
                case "red merchant":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new Merchant(texture, "red");
                case "red heart":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new Heart(texture, "red");
                case "half heart":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new Heart(texture, "half");
                case "pink heart":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new Heart(texture, "pink");
                case "blue heart":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new Heart(texture, "blue");
                case "heart container":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new HeartContainer(texture);
                default:
                    return null;
            }
        }
    }
}
