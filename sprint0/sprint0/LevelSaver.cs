using System;
using System.IO;
using System.Text;

namespace sprint0
{
    public static class LevelSaver
    {
        public static string SavedGamePath { get; } = "../../../SavedGame/";
        private static readonly string heading = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        private static readonly string startTag = "<XnaContent>?";
        private static readonly string endTag = "?</XnaContent>";

        public static void SaveGame(Game1 game)
        {
            Console.WriteLine("Saving...");
            try
            {
                SaveLink(game);
                SaveRooms(game);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to save game: " + e.ToString());
            }
        }

        private static void SaveLink(Game1 game)
        {
            string filePath = SavedGamePath + "/Link.xml";
            using StreamWriter fileWriter = File.CreateText(filePath);
            fileWriter.WriteLine(heading);
            fileWriter.WriteLine(startTag);
            fileWriter.WriteLine("<Game Level=\"" + game.LevelString + "\" />?");
            fileWriter.WriteLine(endTag);
        }

        private static void SaveRooms(Game1 game)
        {
            foreach (Room room in game.Rooms.Values)
                SaveRoom(room);
        }

        private static void SaveRoom(Room room)
        {
            string filePath = SavedGamePath + "/Room" + room.RoomIndex + ".xml";
            using StreamWriter fileWriter = File.CreateText(filePath);
            fileWriter.WriteLine(heading);
            fileWriter.WriteLine(startTag);
            foreach (ISprite roomSprite in room.RoomSprites)
                fileWriter.WriteLine(SaveRoomSprite(room, roomSprite));
            foreach (IItem item in room.Items)
                fileWriter.WriteLine(SaveItem(room, item));
            foreach (INpc npc in room.Npcs)
                fileWriter.WriteLine(SaveNPC(room, npc));
            foreach (IBlock block in room.Blocks)
                fileWriter.WriteLine(SaveBlock(room, block));
            foreach (IEnemy enemy in room.Enemies)
                if (ValidEnemy(enemy))
                    fileWriter.WriteLine(SaveEnemy(room, enemy));
            foreach (IEffect effect in room.Effects)
                if (effect is SpawnCloud spawnCloud)
                    fileWriter.WriteLine(SaveEnemy(room, spawnCloud));
            fileWriter.WriteLine("<Player LocationX=\"300\" LocationY=\"300\" />?");
            fileWriter.WriteLine(endTag);
        }

        private static bool ValidEnemy(IEnemy enemy)
            => !(enemy is Trap || enemy is ManhandlaLimb || enemy is PatraMinion || enemy is GleeokHead || enemy is GleeokNeck || enemy is GleeokNeckPiece);

        private static string SaveRoomSprite(Room room, ISprite roomSprite)
        {
            int x = roomSprite.Location.X - (int)room.Offset.X;
            int y = roomSprite.Location.Y - (int)room.Offset.Y;
            if (roomSprite is Wall wall && wall.CanBeBombed)
                return "<Dungeon ObjectName=\"" + wall.ToBombedOpening().GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" />?";
            return "<Dungeon ObjectName=\"" + roomSprite.ToDungeonEnum().GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" />?";
        }

        private static string SaveItem(Room room, IItem item)
        {
            int x = item.Location.X - (int)room.Offset.X;
            int y = item.Location.Y - (int)room.Offset.Y;
            return "<Item ObjectName=\"" + item.ToItemEnum().GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" />?";
        }

        private static string SaveNPC(Room room, INpc npc)
        {
            int x = npc.Location.X - (int)room.Offset.X;
            int y = npc.Location.Y - (int)room.Offset.Y;
            return "<NPC ObjectName=\"" + npc.ToNPCEnum().GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" />?";
        }

        private static string SaveBlock(Room room, IBlock block)
        {
            int x = block.Location.X - (int)room.Offset.X;
            int y = block.Location.Y - (int)room.Offset.Y;
            if (block is MovableBlock1 movableBlock1)
            {
                int homeX = (int)movableBlock1.HomeLocation.X - (int)room.Offset.X;
                int homeY = (int)movableBlock1.HomeLocation.Y - (int)room.Offset.Y;
                return "<Block ObjectName=\"" + BlockEnum.MovableBlock.GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" HomeLocationX=\"" + homeX + "\" HomeLocationY=\"" + homeY + "\" />?";
            }
            if (block is MovableBlock5 movableBlock5)
            {
                int homeX = (int)movableBlock5.HomeLocation.X - (int)room.Offset.X;
                int homeY = (int)movableBlock5.HomeLocation.Y - (int)room.Offset.Y;
                return "<Block ObjectName=\"" + BlockEnum.MovableBlock5.GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" HomeLocationX=\"" + homeX + "\" HomeLocationY=\"" + homeY + "\" />?";
            }
            if (block is MovableBlock20 movableBlock20)
                return "<Block ObjectName=\"" + BlockEnum.MovableBlock20.GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" Direction=\"" + movableBlock20.Direction + "\" />?";
            if (block is InvisibleBlock invisibleBlock && (invisibleBlock.Width != InvisibleBlock.DefaultSize || invisibleBlock.Height != InvisibleBlock.DefaultSize))
                return "<Block ObjectName=\"" + BlockEnum.InvisibleBlock.GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" Width=\"" + invisibleBlock.Width + "\" Height=\"" + invisibleBlock.Height + "\" />?";
            if (block is SoundBlock soundBlock)
                return "<Block ObjectName=\"" + block.ToBlockEnum().GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" Sound=\"" + soundBlock.Sound + "\" />?";
            return "<Block ObjectName=\"" + block.ToBlockEnum().GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" />?";
        }


        private static string SaveEnemy(Room room, IEnemy enemy)
        {
            int x = enemy.Location.X - (int)room.Offset.X;
            int y = enemy.Location.Y - (int)room.Offset.Y;
            if (IsBoss(enemy))
                return "<Boss ObjectName=\"" + enemy.ToEnemyEnum().GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" />?";
            return "<Enemy ObjectName=\"" + enemy.ToEnemyEnum().GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" />?";
        }

        private static string SaveEnemy(Room room, SpawnCloud cloud)
        {
            int x = cloud.Location.X - (int)room.Offset.X;
            int y = cloud.Location.Y - (int)room.Offset.Y;
            return "<Enemy ObjectName=\"" + cloud.enemyAfter.GetName() + "\" LocationX=\"" + x + "\" LocationY=\"" + y + "\" />?";
        }

        private static bool IsBoss(IEnemy enemy)
            => enemy is Aquamentus || enemy is Digdogger || enemy is Dodongo || enemy is Ganon || enemy is Gleeok || enemy is Gohma || enemy is Manhandla || enemy is Patra;
    }
}
