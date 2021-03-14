using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class Trapparatus : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }

        private readonly List<IEnemy> traps;

        public Trapparatus(Texture2D texture, Vector2 location, Game1 game)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, 0, 0);
            Texture = texture;

            Vector2 center = Location.Location.ToVector2();
            int xOffset = 219;
            int yOffset = 120;

            traps = new List<IEnemy>
            {
                new Trap(Texture, center + new Vector2(xOffset, yOffset)),
                new Trap(Texture, center + new Vector2(-xOffset, yOffset)),
                new Trap(Texture, center + new Vector2(-xOffset, -yOffset)),
                new Trap(Texture, center + new Vector2(xOffset, -yOffset)),
            };

            //register traps as enemies for collision handeling
            game.RegisterEnemies(traps);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Update()
        {
            //for (int i = 0; i < traps.Count; i++)
            //{
            //    Trap trap = (Trap)traps[i];
            //    trap.CheckIfTriggered();
            //    if (!trap.IsMoving() && !NeighborsMoving(trap))
            //    {

            //        trap.SetDirection(trap.CheckIfTriggered());
            //    }

            //}
            //for (int i = 0; i < traps.Count; i++)
            //{
            //    Trap trap = (Trap)traps[i];
            //    trap.Update();
            //}
        }

        private bool NeighborsMoving(Trap trap)
        {

            int currentTrap = traps.IndexOf(trap);
            Trap neighbor1 = (Trap)traps[(currentTrap + 1) % traps.Count];
            Trap neighbor2 = (Trap)traps[(currentTrap -1 + traps.Count) % traps.Count];
            if (neighbor1.IsMoving() || neighbor2.IsMoving())
            {
                return true;
            }
            return false;
        }

        public void ChangeDirection()
        {
            //no-op
        }

        public void TakeDamage()
        {
            // not necessary; unkillable
        }

        public void TakeDamage(int damage)
        {
            //no-op
        }

        public void Perish()
        {
            //no-op
        }
    }
}
