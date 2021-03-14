﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson and co

namespace sprint0
{
    public class NpcsSpriteFactory
    {
        Game1 game;
        Texture2D texture;

        public NpcsSpriteFactory(Game1 game)
        {
            this.game = game;
            texture = game.Content.Load<Texture2D>("Images/NPCs");
        }

        public INpc MakeSprite(string spriteType, Vector2 location)
        {
            
            switch (spriteType)
            {
                case "old man 1":
                    return new OldPerson(texture, location, "man 1");
                case "old man 2":
                    return new OldPerson(texture, location, "man 2");
                case "old woman":
                    return new OldPerson(texture, location, "woman");
                case "green merchant":
                    return new Merchant(texture, location, "green");
                case "white merchant":
                    return new Merchant(texture, location, "white");
                case "red merchant":
                    return new Merchant(texture, location, "red");
                case "flame":
                    return new Flame(texture, location);
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
