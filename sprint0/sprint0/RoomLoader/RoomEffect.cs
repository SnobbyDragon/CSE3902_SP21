using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    public class RoomEffect
    {
        public List<IEffect> RoomeEffects { get ; set; }
        public List<IEffect> EffectsToDie { get; set; }
        private readonly EffectSpriteFactory effectFactory;
        public RoomEffect(Game1 game)
        {
            effectFactory = new EffectSpriteFactory(game);
            RoomeEffects = new List<IEffect>();
            EffectsToDie = new List<IEffect>();
        }

        public void AddEffect(Vector2 location, string sprite)
            => RoomeEffects.Add(effectFactory.MakeSprite(sprite, location));

        public void AddEffect(IEffect effect) => RoomeEffects.Add(effect);

        public void RemoveProjectile(IEffect effect) => EffectsToDie.Add(effect);

        public void RemoveDead()
        {
            foreach (IEffect effect in RoomeEffects)
                if (!effect.IsAlive()) RemoveProjectile(effect);
        }

        public void RemoveDeadTwo()
        {
            foreach (IEffect effect in EffectsToDie)
                RoomeEffects.Remove(effect);
        }

        public void Clear() => EffectsToDie.Clear();

        public void Update()
        {
            foreach (IEffect _sprite in RoomeEffects)
                _sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEffect _sprite in RoomeEffects)
                _sprite.Draw(spriteBatch);
        }
    }
}
