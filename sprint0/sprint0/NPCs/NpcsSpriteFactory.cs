using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co
namespace sprint0
{
    public enum NPCEnum
    {
        OldMan1, OldMan2, OldWoman, GreenMerchant, WhiteMerchant, RedMerchant, Flame
    }
    public class NpcsSpriteFactory
    {
        private readonly Texture2D texture;

        public NpcsSpriteFactory(Game1 game)
            => texture = game.Content.Load<Texture2D>("Images/NPCs");

        public INpc MakeSprite(NPCEnum spriteType, Vector2 location)
        {
            return spriteType switch
            {
                NPCEnum.OldMan1 => new OldPerson(texture, location, "man 1"),
                NPCEnum.OldMan2 => new OldPerson(texture, location, "man 2"),
                NPCEnum.OldWoman => new OldPerson(texture, location, "woman"),
                NPCEnum.GreenMerchant => new Merchant(texture, location, "green"),
                NPCEnum.WhiteMerchant => new Merchant(texture, location, "white"),
                NPCEnum.RedMerchant => new Merchant(texture, location, "red"),
                NPCEnum.Flame => new Flame(texture, location),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType.ToString() + " Sprite factory failed."),
            };
        }
    }
}
