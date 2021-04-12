using System;
using Microsoft.Xna.Framework;

namespace sprint0
{
    public class AquamentusFireballBehaviour
    {
        private readonly int fireballRate = 100;
        private int fireballCounter = 0;
        private readonly Game1 game;
        private readonly Aquamentus aquamentus;

        public AquamentusFireballBehaviour(Game1 game, Aquamentus aquamentus)
        {
            this.game = game;
            this.aquamentus = aquamentus;
        }

        public void Update()
        {
            if (CanShoot()) ShootFireballs();
        }

        private bool CanShoot()
        {
            fireballCounter++;
            fireballCounter %= fireballRate;
            return fireballCounter == 0;
        }

        private void ShootFireballs()
        {
            Vector2 currLoc = aquamentus.Location.Center.ToVector2();
            game.Room.RoomSound.AddSoundEffect(ParseSound(aquamentus.GetType().Name));
            Vector2 dir = Link.position - currLoc;
            dir.Normalize();
            game.Room.LoadLevel.RoomProjectile.AddFireball(currLoc, dir, aquamentus);
            game.Room.LoadLevel.RoomProjectile.AddFireball(currLoc, Vector2.Transform(dir, Matrix.CreateRotationZ((float)(Math.PI / 6))), aquamentus); // 30 degrees up
            game.Room.LoadLevel.RoomProjectile.AddFireball(currLoc, Vector2.Transform(dir, Matrix.CreateRotationZ((float)(-Math.PI / 6))), aquamentus); // 30 degrees down
        }

        private SoundEnum ParseSound(string sound)
             => (SoundEnum)Enum.Parse(typeof(SoundEnum), sound, true);
    }
}
