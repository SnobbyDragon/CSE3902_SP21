using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace sprint0
{
    public class SoundLoader
    {
        private readonly List<Song> songs;
        private readonly Dictionary<string, SoundEffect> soundEffects;

        public SoundLoader(Game1 game)
        {
            songs = new List<Song>
            {
                game.Content.Load<Song>("Sound/music1"),
                game.Content.Load<Song>("Sound/music2"),
                game.Content.Load<Song>("Sound/music3"),
            };
            soundEffects = new Dictionary<string, SoundEffect>
            {
                { "sword slash", game.Content.Load<SoundEffect>("Sound/Sword_Slash") },
                { "sword shoot", game.Content.Load<SoundEffect>("Sound/Sword_Shoot") },
                { "arrow", game.Content.Load<SoundEffect>("Sound/Arrow_Boomerang") },
                { "boomerang", game.Content.Load<SoundEffect>("Sound/Arrow_Boomerang") },
                { "shield", game.Content.Load<SoundEffect>("Sound/Shield") },
                { "use bomb", game.Content.Load<SoundEffect>("Sound/Bomb_Drop") },
                { "bomb explode", game.Content.Load<SoundEffect>("Sound/Bomb_Blow") },
                { "candle", game.Content.Load<SoundEffect>("Sound/Candle") },
                { "magical rod", game.Content.Load<SoundEffect>("Sound/MagicalRod") },
                { "recorder", game.Content.Load<SoundEffect>("Sound/Recorder") },
                { "enemy damaged", game.Content.Load<SoundEffect>("Sound/Enemy_Hit") },
                { "enemy death", game.Content.Load<SoundEffect>("Sound/Enemy_Die") },
                //{ "link damaged", game.Content.Load<SoundEffect>("Sound/Link_Hurt") },
                { "link damaged", game.Content.Load<SoundEffect>("Sound/ow") },
                { "link death", game.Content.Load<SoundEffect>("Sound/Link_Die") },
                { "low health", game.Content.Load<SoundEffect>("Sound/LowHealth") },
                { "new item", game.Content.Load<SoundEffect>("Sound/Fanfare") },
                { "get item", game.Content.Load<SoundEffect>("Sound/Get_Item") },
                { "get heart", game.Content.Load<SoundEffect>("Sound/Get_Heart") },
                { "get key", game.Content.Load<SoundEffect>("Sound/Get_Heart") },
                { "get rupee", game.Content.Load<SoundEffect>("Sound/Get_Rupee") },
                { "refill", game.Content.Load<SoundEffect>("Sound/Refill_Loop") },
                { "text appear", game.Content.Load<SoundEffect>("Sound/Text") },
                { "text appear slow", game.Content.Load<SoundEffect>("Sound/Text_Slow") },
                { "key appear", game.Content.Load<SoundEffect>("Sound/Key_Appear") },
                { "unlock door", game.Content.Load<SoundEffect>("Sound/Door_Unlock") },
                { "aquamentus", game.Content.Load<SoundEffect>("Sound/Boss_Scream1") },
                { "gleeok", game.Content.Load<SoundEffect>("Sound/Boss_Scream1") },
                { "ganon", game.Content.Load<SoundEffect>("Sound/Boss_Scream1") },
                { "dodongo", game.Content.Load<SoundEffect>("Sound/Boss_Scream2") },
                { "gohma", game.Content.Load<SoundEffect>("Sound/Boss_Scream2") },
                { "manhandla", game.Content.Load<SoundEffect>("Sound/Boss_Scream3") },
                { "digdogger", game.Content.Load<SoundEffect>("Sound/Boss_Scream3") },
                { "patra", game.Content.Load<SoundEffect>("Sound/Boss_Scream3") },
                { "stairs", game.Content.Load<SoundEffect>("Sound/Stairs") },
                { "shore", game.Content.Load<SoundEffect>("Sound/Shore") },
                { "secret", game.Content.Load<SoundEffect>("Sound/Secret") },
            };
        }

        public List<Song> GetMusic()
        {
            return songs;
        }

        public SoundEffect GetSoundEffect(string soundEffectType)
        {
            return soundEffects[soundEffectType];
        }
    }
}
