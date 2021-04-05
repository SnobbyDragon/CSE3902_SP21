using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * Last updated: 04/01/21 by he.1528
 */
namespace sprint0
{
    public enum EffectEnum
    {
        HitSprite, SwordBeamExplode, Death, GanonAshes
    }
    public class EffectSpriteFactory
    {
        private readonly Texture2D texture2;
        private readonly Texture2D texture1;
        private readonly Game1 game;

        public EffectSpriteFactory(Game1 Game)
        {
            this.game = Game;
            texture1 = game.Content.Load<Texture2D>("Images/Bosses");
            texture2 = game.Content.Load<Texture2D>("Images/Link");
        }
        public IEffect MakeSprite(string spriteType, Vector2 location)
        {
            return spriteType switch
            {
                "hit sprite" => new HitSprite(texture2, location),
                "sword beam explode" => new SwordBeamExplode(texture2, location),
                "death" => new DeathCloud(texture2, location, game),
                "ganonashes" => new GanonAshes(texture1, location),
                _ => throw new ArgumentException("Invalid sprite! " + spriteType + " Sprite factory failed."),
            };
        }

        public IEffect MakeSpawn(EnemyEnum enemy, Vector2 location)
            => new SpawnCloud(texture2, location, game, enemy);
    }
}
