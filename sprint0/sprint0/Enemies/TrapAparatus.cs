using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Hannah Johnson

namespace sprint0
{
    public class TrapAparatus : IEnemy
    {
        public Rectangle Location { get; set; }
        private readonly int width = 16, height = 16;
        public Texture2D Texture { get; set; }
        private Direction direction;
        private readonly Game1 game;
        private List<IEnemy> traps;


        public TrapAparatus(Texture2D texture, Vector2 location, Game1 game)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, 0, 0);
            Texture = texture;
            this.game = game;

            Vector2 center = Location.Location.ToVector2();
            int xOffset =219;
            int yOffset = 120;

            traps = new List<IEnemy>
            {
                new Trap(Texture,center+ new Vector2(xOffset, yOffset), game),
                new Trap(Texture,center+ new Vector2(-xOffset, yOffset), game),
                new Trap(Texture,center+ new Vector2(-xOffset, -yOffset), game),
                new Trap(Texture,center+ new Vector2(-xOffset, yOffset), game)

            };
            //register limbs as enemies for collision handeling
            game.RegisterEnemies(traps);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(IEnemy trap in traps){
                trap.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            foreach (Trap trap in traps)
            {
                if (!trap.IsMoving() && !NeighborsMoving(trap)) {
                    trap.CheckIfTriggered();
                }
                trap.Update();
            }
            

        }

        private bool NeighborsMoving(Trap trap)
        {
            
            int currentTrap=traps.IndexOf(trap);
            Trap neighbor1 = (Trap)traps[(currentTrap + 1) % 4];
            Trap neighbor2 = (Trap)traps[(currentTrap + -1 +4) % 4];
            if (neighbor1.IsMoving() || neighbor2.IsMoving()) {
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
