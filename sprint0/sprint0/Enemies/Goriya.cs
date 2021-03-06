using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Goriya : AbstractEnemy
    {
        private readonly Dictionary<Color, List<Rectangle>> colorMap;
        public Color Color { get; }
        private readonly Room room;
        private int throwCounter;
        private readonly int throwMax = 100;

        public Goriya(Texture2D texture, Vector2 location, Color goriyaColor, Game1 game) : base(texture, location, game)
        {
            health = 6;
            width = height = 16;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            Color = goriyaColor;
            currentFrame = 0;
            totalFrames = 4;
            repeatedFrames = 20;
            direction = Direction.North;
            damage = 2;
            room = game.Room;
            throwCounter = 0;
            colorMap = new Dictionary<Color, List<Rectangle>>
            {
                { Color.Red, SpritesheetHelper.GetFramesH(222, 11, width, height, totalFrames) },
                { Color.Blue, SpritesheetHelper.GetFramesH(222, 28, width, height, totalFrames) }
            };
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (damageTimer % 2 == 0)
            {
                switch (direction)
                {
                    case Direction.West:
                        spriteBatch.Draw(Texture, Location, colorMap[Color][currentFrame / repeatedFrames % 2 + 2], Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0);
                        break;
                    case Direction.East:
                        spriteBatch.Draw(Texture, Location, colorMap[Color][currentFrame / repeatedFrames % 2 + 2], Color.White);
                        break;
                    case Direction.South:
                        spriteBatch.Draw(Texture, Location, colorMap[Color][0], Color.White);
                        break;
                    case Direction.North:
                        spriteBatch.Draw(Texture, Location, colorMap[Color][1], Color.White);
                        break;
                }
            }
        }

        private void UseBoomerang()
        {
            Vector2 offsetPos = Location.Location.ToVector2();
            room.LoadLevel.RoomProjectile.AddProjectile(offsetPos, this.direction, ProjectileEnum.Boomerang, this);
            room.RoomSound.AddSoundEffect(SoundEnum.Boomerang);
        }

        public override void Update()
        {
            base.Update();
            if (!game.Room.FreezeEnemies)
            {
                if (throwCounter == throwMax)
                {
                    throwCounter = 0;
                    UseBoomerang();
                }
                throwCounter++;
            }
        }

        public bool IsAlive() => health > 0;
    }
}