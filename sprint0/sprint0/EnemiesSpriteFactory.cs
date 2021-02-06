using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class BossesSpriteFactory
    {
        Game1 game;

        public BossesSpriteFactory(Game1 game)
        {
            this.game = game;
        }

        public ISprite MakeSprite(String spriteType, Vector2 location)
        {
            Texture2D texture;
            switch (spriteType)
            {
                case "old man 1":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new OldPerson(texture, location, "man 1");
                case "old man 2":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new OldPerson(texture, location, "man 2");
                case "old woman":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new OldPerson(texture, location, "woman");
                case "green merchant":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new Merchant(texture, location, "green");
                case "white merchant":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new Merchant(texture, location, "white");
                case "red merchant":
                    texture = game.Content.Load<Texture2D>("Images/NPCs");
                    return new Merchant(texture, location, "red");
                case "red heart":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new Heart(texture, location, "red");
                case "half heart":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new Heart(texture, location, "half");
                case "pink heart":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new Heart(texture, location, "pink");
                case "blue heart":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new Heart(texture, location, "blue");
                case "heart container":
                    texture = game.Content.Load<Texture2D>("Images/ItemsAndWeapons");
                    return new HeartContainer(texture, location);
                case "wallmaster":
                    texture = game.Content.Load<Texture2D>("Images/DungeonEnemies");
                    return new Wallmaster(texture, location);
                case "aquamentus":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new Aquamentus(texture, location);
                case "aquamentus fireball":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new AquamentusFireball(texture, location);
                case "patra":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new Patra(texture, location);
                case "patra minion":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new PatraMinion(texture, location);
                case "manhandla":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new Manhandla(texture, location);
                case "manhandla fireball":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new ManhandlaFireball(texture, location);
                case "gleeok":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new Gleeok(texture, location);
                case "gleeok fireball":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GleeokFireball(texture, location);
                case "ganon":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new Ganon(texture, location);
                case "ganon fireball center":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GanonFireball(texture, location, "center");
                case "ganon fireball up":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GanonFireball(texture, location, "up");
                case "ganon fireball up left":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GanonFireball(texture, location, "up left");
                case "ganon fireball left":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GanonFireball(texture, location, "left");
                case "ganon fireball down left":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GanonFireball(texture, location, "down left");
                case "ganon fireball down":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GanonFireball(texture, location, "down");
                case "ganon fireball down right":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GanonFireball(texture, location, "down right");
                case "ganon fireball right":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GanonFireball(texture, location, "right");
                case "ganon fireball up right":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new GanonFireball(texture, location, "up right");
                case "orange gohma":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new Gohma(texture, location, "orange");
                case "blue gohma":
                    texture = game.Content.Load<Texture2D>("Images/Bosses");
                    return new Gohma(texture, location, "blue");
                default:
                    throw new ArgumentException("Invalid sprite! Sprite factory failed.");
            }
        }
    }
}
