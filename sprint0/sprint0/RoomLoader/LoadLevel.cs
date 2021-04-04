using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class LoadLevel
    {
        public RoomProjectile RoomProjectile { get => roomProjectile; }
        public RoomWeapon RoomWeapon { get => roomWeapon; }
        public RoomBlocks RoomBlocks { get => roomBlocks; }
        public RoomItems RoomItems { get => roomItems; }
        public RoomNPCs RoomNPCs { get => roomNPCs; }
        public RoomEnemies RoomEnemies { get => roomEnemies; }
        public RoomSprite RoomSprite { get => roomSprite; }
        public RoomEffect RoomEffect { get => roomEffect; }
        private readonly RoomProjectile roomProjectile;
        private readonly RoomWeapon roomWeapon;
        private readonly RoomBlocks roomBlocks;
        private readonly RoomItems roomItems;
        private readonly RoomNPCs roomNPCs;
        private readonly RoomEnemies roomEnemies;
        private readonly RoomSprite roomSprite;
        private readonly RoomEffect roomEffect;

        public LoadLevel(Game1 game)
        {
            roomProjectile = new RoomProjectile(game);
            roomWeapon = new RoomWeapon(game);
            roomBlocks = new RoomBlocks(game);
            roomItems = new RoomItems(game);
            roomNPCs = new RoomNPCs();
            roomEnemies = new RoomEnemies(game);
            roomSprite = new RoomSprite();
            roomEffect = new RoomEffect(game);
        }

        public void PopulateLists((List<ISprite>, List<IProjectile>, List<IBlock>, List<IEnemy>, List<INpc>, List<IItem>, List<IEffect>) roomElements)
        {
            roomSprite.RoomSprites = roomElements.Item1;
            roomProjectile.Projectiles = roomElements.Item2;
            roomBlocks.Blocks = roomElements.Item3;
            roomEnemies.Enemies = roomElements.Item4;
            roomNPCs.NPCs = roomElements.Item5;
            roomItems.Items = roomElements.Item6;
            roomEffect.RoomEffects = roomElements.Item7;
        }

        public void UpdateOffsets(Vector2 Offset) {
            roomSprite.UpdateOffset(Offset);
            roomProjectile.UpdateOffset(Offset);
            roomBlocks.UpdateOffset(Offset);
            roomEnemies.UpdateOffset(Offset);
            roomNPCs.UpdateOffset(Offset);
            roomItems.UpdateOffset(Offset);
            roomEffect.UpdateOffset(Offset);
        }

        public void AddNew()
        {
            roomEnemies.EnemySpawnUpdate();
            roomBlocks.AddNew();
        }

        public void RemoveDead()
        {
            roomItems.ItemSpawnUpdate();
            roomEnemies.RemoveDead();
            roomWeapon.RemoveDead();
            roomProjectile.RemoveDead();
            roomEffect.RemoveDead();
            roomWeapon.RemoveDeadTwo();
            roomProjectile.RemoveDeadTwo();
            roomWeapon.RemoveDeadTwo();
            roomEffect.RemoveDeadTwo();
            roomBlocks.RemoveDestroyed();
        }

        public void Clear()
        {
            roomWeapon.Clear();
            roomProjectile.Clear();
            roomEffect.Clear();
        }

        public void Update()
        {
            roomSprite.Update();
            roomProjectile.Update();
            roomWeapon.Update();
            roomBlocks.Update();
            roomEnemies.Update();
            roomNPCs.Update();
            roomItems.Update();
            roomEffect.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            roomSprite.Draw(spriteBatch);
            roomBlocks.Draw(spriteBatch);
            roomWeapon.Draw(spriteBatch);
            roomProjectile.Draw(spriteBatch);
            roomEnemies.Draw(spriteBatch);
            roomNPCs.Draw(spriteBatch);
            roomItems.Draw(spriteBatch);
            roomProjectile.Draw(spriteBatch);
            roomEffect.Draw(spriteBatch);
        }
    }
}
