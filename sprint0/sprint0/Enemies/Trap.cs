using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Author: Stuti Shah
//Movemnet added by Hannah Johnson
namespace sprint0
{
    public class Trap : IEnemy
    {
        public Rectangle Location { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle source;
        private readonly int width = 16, height = 16;
        private Direction direction;
        private Game1 game;
        private Rectangle HomeLocation;
  

        public Trap(Texture2D texture, Vector2 location, Game1 game)
        {
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            HomeLocation = Location;
            Texture = texture;
            this.game = game;

            //Initialy does not move
            //Let ne be the direction trap "moves" if it is not moving
            direction = Direction.ne;
           
            //load sprite
            source = new Rectangle(164, 59, width, height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, source, Color.White);
        }

        public void Update()
        {

            if (direction == Direction.ne)
            { //The trap is not moving so check if link triggered it
                direction = CheckIfTriggered();
            }
            else
            {
                //move the traps
                if (direction == Direction.s)
                {
                    //moves sprite down
                    Location = new Rectangle(Location.X, Location.Y + 1, Location.Width, Location.Height);

                }
                else if (direction == Direction.w)
                {
                    //moves sprite left
                    Location = new Rectangle(Location.X - 1, Location.Y, Location.Width, Location.Height);

                }
                else if (direction == Direction.e)
                {
                    //moves sprite right
                    Location = new Rectangle(Location.X + 1, Location.Y, Location.Width, Location.Height);

                }
                else
                {   //direction == Direction.n
                    //moves sprite up
                    Location = new Rectangle(Location.X, Location.Y - 1, Location.Width, Location.Height);

                }

                //if the traps moved to their home location, make them still again
                if (Location == HomeLocation) { direction = Direction.ne; }

            }

           
        }

        //Checks if link triggered the trap, and if so returns the direction
        //Only call if not already triggered, ie trap is not moving
        public Direction CheckIfTriggered()
        {
            //If not triggered return north east, since traps can only move in n, s, w, e
            Direction moveDirection = Direction.ne;
            Vector2 playerPos=game.Player.Pos;
            if (playerPos.X == Location.X && playerPos.Y >= Location.Y)
            { //Link is directly under  trap
                moveDirection = Direction.s;
            }
            else if (playerPos.X == Location.X && playerPos.Y <= Location.Y)
            { //Link is directly above trap
                moveDirection = Direction.n;
            }
            else if (playerPos.Y == Location.Y && playerPos.X <= Location.X)
            { //Link is  directly left of trap
                moveDirection = Direction.w;
            }
            else if (playerPos.Y == Location.Y && playerPos.X >= Location.X)
            { //Link is  directly right of trap
                moveDirection = Direction.e;
            }

            return moveDirection;
        }

        public void ChangeDirection()
        {

            if (direction == Direction.s && Location != HomeLocation)
            {
                direction = Direction.n;
            }
            else if (direction == Direction.w && Location != HomeLocation)
            {
                direction = Direction.e;
            }
            else if (direction == Direction.e && Location != HomeLocation)
            {
                direction = Direction.w;
            }
            else if(direction == Direction.n && Location != HomeLocation)
            {
                direction = Direction.s;
            }


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
