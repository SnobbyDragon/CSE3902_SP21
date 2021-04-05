using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace sprint0
{
    public class RoomEffect
    {
        public List<IEffect> RoomEffects { get; set; }
        public List<IEffect> EffectsToDie { get; set; }
        public readonly EffectSpriteFactory effectFactory;
        public RoomEffect(Game1 game)
        {
            effectFactory = new EffectSpriteFactory(game);
            RoomEffects = new List<IEffect>();
            EffectsToDie = new List<IEffect>();
        }

        public void AddEffect(Vector2 location, EffectEnum sprite)
            => RoomEffects.Add(effectFactory.MakeSprite(sprite, location));

        public void AddEffect(IEffect effect) => RoomEffects.Add(effect);

        public void RemoveProjectile(IEffect effect) => EffectsToDie.Add(effect);

        public void RemoveDead()
        {
            foreach (IEffect effect in RoomEffects)
                if (!effect.IsAlive()) RemoveProjectile(effect);
        }

        public void RemoveDeadTwo()
        {
            foreach (IEffect effect in EffectsToDie)
                RoomEffects.Remove(effect);
        }

        public void Clear() => EffectsToDie.Clear();

        public void Update()
        {
            foreach (IEffect _sprite in RoomEffects)
                _sprite.Update();
        }
        public void UpdateOffset(Vector2 Offset)
        {
            foreach (IEffect item in RoomEffects)
                item.Location = new Rectangle(item.Location.X + (int)Offset.X, item.Location.Y + (int)Offset.Y, item.Location.Width, item.Location.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IEffect _sprite in RoomEffects)
                _sprite.Draw(spriteBatch);
        }
    }
}
