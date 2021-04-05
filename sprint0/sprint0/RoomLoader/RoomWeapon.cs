using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class RoomWeapon
    {
        private WeaponsSpriteFactory weaponFactory;
        public List<IWeapon> Weapons { get => weapons; set => weapons = value; }
        public List<IWeapon> WeaponsToDie { get => weaponsToDie; set => weaponsToDie = value; }
        private List<IWeapon> weapons, weaponsToDie;
        public RoomWeapon(Game1 game)
        {
            weaponFactory = new WeaponsSpriteFactory(game);
            weapons = new List<IWeapon>();
            weaponsToDie = new List<IWeapon>();
        }

        public void AddWeapon(Vector2 Location, Direction dir, WeaponEnum item, IPlayer source)
            => weapons.Add(weaponFactory.MakeWeapon(item, Location, dir, source));

        public void RemoveWeapon(IWeapon weapon) => weaponsToDie.Add(weapon);

        public void RemoveDead()
        {
            foreach (IWeapon weapon in weapons)
                if (!weapon.IsAlive()) RemoveWeapon(weapon);
        }

        public void RemoveDeadTwo()
        {
            foreach (IWeapon weapon in weaponsToDie)
                weapons.Remove(weapon);
        }

        public void Clear() => weaponsToDie.Clear();

        public void Update()
        {
            foreach (IWeapon weapon in weapons)
                weapon.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IWeapon weapon in weapons)
                weapon.Draw(spriteBatch);
        }
    }
}
