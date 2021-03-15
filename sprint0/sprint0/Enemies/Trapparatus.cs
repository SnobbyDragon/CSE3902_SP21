﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Authors: Hannah Johnson, Angela Li
namespace sprint0
{
    public class Trapparatus : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }

        private readonly Dictionary<Direction, Trap> traps;

        public Trapparatus(Texture2D texture, Vector2 location, Game1 game)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, 0, 0);
            Texture = texture;

            Vector2 center = Location.Location.ToVector2();
            int xOffset = 219;
            int yOffset = 120;

            traps = new Dictionary<Direction, Trap>
            {
                { Direction.se, new Trap(Texture, center + new Vector2(xOffset, yOffset), game) },
                { Direction.sw, new Trap(Texture, center + new Vector2(-xOffset, yOffset), game) },
                { Direction.nw, new Trap(Texture, center + new Vector2(-xOffset, -yOffset), game) },
                { Direction.ne, new Trap(Texture, center + new Vector2(xOffset, -yOffset), game) }
            };

            //register traps as enemies for collision handeling
            game.RegisterEnemies(traps.Values);
        }

        public void Draw(SpriteBatch spriteBatch) {}

        public void Update()
        {
            Collision linkByWall = DetectLinkByWall();
            if (linkByWall != Collision.None) // try to activate traps
            {
                List<Direction> trapDirs = linkByWall.ToDirection().AdjacentDirectionsDiffType();
                if (!traps[trapDirs[0]].IsMoving && !traps[trapDirs[1]].IsMoving)
                {
                    foreach (Direction trapDir in trapDirs)
                    {
                        SetDirectionToMove(linkByWall, trapDir);
                        traps[trapDir].IsMoving = true;
                    }
                }
            }
        }

        private void SetDirectionToMove(Collision linkByWall, Direction trapDir)
        {
            List<Direction> adjDirs = trapDir.AdjacentDirectionsDiffType();
            Direction dirToMove;
            if (linkByWall.ToDirection() != adjDirs[0])
                dirToMove = adjDirs[0];
            else
                dirToMove = adjDirs[1];
            traps[trapDir].SetDirection(dirToMove.OppositeDirection());
        }

        private Collision DetectLinkByWall()
        {
            // TODO 16 link size magic number
            if (Link.position.Y <= (Game1.HUDHeight + Game1.BorderThickness) * Game1.Scale + traps[Direction.nw].Location.Height)
                return Collision.Top;
            if (Link.position.Y >= (Game1.HUDHeight + Game1.MapHeight - Game1.BorderThickness - 16) * Game1.Scale - traps[Direction.nw].Location.Height)
                return Collision.Bottom;
            if (Link.position.X <= Game1.BorderThickness * Game1.Scale + traps[Direction.nw].Location.Width)
                return Collision.Left;
            if (Link.position.X >= Game1.Width * Game1.Scale - traps[Direction.nw].Location.Width - (Game1.BorderThickness + 16) * Game1.Scale)
                return Collision.Right;
            return Collision.None;
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
