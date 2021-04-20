using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    class StepLadderBlock : AbstractBlock, IBlock
    {
        private readonly int xOffset = 1053, yOffset = 11;
        private readonly Room room;
        public bool UnderLink { get; set; } = true;
        public StepLadderBlock(Texture2D texture, Vector2 location, Room room)
        {
            this.room = room;
            Location = new Rectangle((int)location.X, (int)location.Y, (int)(width * Game1.Scale), (int)(height * Game1.Scale));
            Texture = texture;
            source = new Rectangle(xOffset, yOffset, width, height);
        }
        public override bool IsWalkable() => true;
        public override void Update()
        {
            if(!UnderLink)
            {
                room.LoadLevel.RoomBlocks.RemoveBlock(this);
                room.LoadLevel.RoomBlocks.AddBlock(new Vector2(Location.X, Location.Y), BlockEnum.Water);
            }
        }
    }
}
