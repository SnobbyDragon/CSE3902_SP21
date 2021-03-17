using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
namespace sprint0
{
    public class NpcsSpriteFactory
    {
        private readonly Game1 game;
        private readonly Texture2D texture;

        public NpcsSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/NPCs");
        }

        public INpc MakeSprite(string spriteType, Vector2 location)
        {

            return spriteType switch
            {
                "old man 1" => new OldPerson(texture, location, "man 1"),
                "old man 2" => new OldPerson(texture, location, "man 2"),
                "old woman" => new OldPerson(texture, location, "woman"),
                "green merchant" => new Merchant(texture, location, "green"),
                "white merchant" => new Merchant(texture, location, "white"),
                "red merchant" => new Merchant(texture, location, "red"),
                "flame" => new Flame(texture, location),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }
    }
}
