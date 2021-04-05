using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Room
    {
        private readonly SpriteBatch _spriteBatch;
        public Game1 Game { get; }
        private readonly string message = "EASTMOST PENINSULA IS THE SECRET.";
        private readonly Vector2 messageLoc= new Vector2(170,250);
        public static PlayerSpriteFactory PlayerFactory { get => Game1.PlayerFactory; }
        public IPlayer Player { get => Game.Player; set => Game.Player = value; }
        private LoadLevel loadLevel;
        public LoadLevel LoadLevel { get => loadLevel; set => loadLevel = value; }
        public RoomSound RoomSound { get => roomSound; }
        private RoomSound roomSound;
        public Overlay Overlay { get => overlay; }
        private Overlay overlay;

        private readonly Vector2 linkInitialPos;
        private const int LinkDefaultPos = 300;
        private readonly bool loadedPos;

        private AllCollisionHandler collisionHandler;
        private readonly int roomIndex;
        public int RoomIndex { get => roomIndex; }
        private Text text;

        public bool SuspendPlayer { get => suspendPlayer; set => suspendPlayer = value; }
        private bool suspendPlayer;

        public Vector2 Offset { get => offset; set => offset = value; }
        private Vector2 offset;
        private ISprite sprite;
        private SpriteFont font;
        public ISprite Sprite { get => sprite; set => sprite = value; }
        public SpriteFont Font { get => font; set => font = value; }

        public Room(SpriteBatch spriteBatch, Game1 game, int roomIndex, Vector2 Offset, float linkX = LinkDefaultPos, float linkY = LinkDefaultPos, bool loadedPos = false)
        {
            suspendPlayer = false;
            offset = Offset;
            Game = game;
            _spriteBatch = spriteBatch;
            this.roomIndex = roomIndex;
            linkInitialPos = new Vector2(linkX, linkY);
            this.loadedPos = loadedPos;
        }

        public void LoadContent()
        {
            overlay = new Overlay();
            collisionHandler = new AllCollisionHandler(this);
            roomSound = new RoomSound(Game);
<<<<<<< HEAD
            loadLevel = new LoadLevel(Game, RoomIndex);
            loadLevel.PopulateLists(new LevelLoader(Game, RoomIndex, offset).LoadLevel());
=======
            loadLevel = new LoadLevel(Game, roomIndex);
            loadLevel.PopulateLists(new LevelLoader(Game, roomIndex, offset).LoadLevel());
>>>>>>> fe4b4f0... overlay moves correctly
            loadLevel.UpdateOffsets(offset);
            Overlay.UpdateOffset(offset);

            text = new Text(Game, message, messageLoc, Color.White);
            if (!loadedPos)
                Player.Pos = linkInitialPos;
        }

        public void UpdateOffsets(Vector2 ofst) {
            offset += ofst;
            loadLevel.UpdateOffsets(ofst);
            Overlay.UpdateOffset(ofst);
        }

        public void Update()
        {
            if (!suspendPlayer)
            {
                Player.Update();
            }
            loadLevel.Update();
            collisionHandler.HandleAllCollisions(Player, loadLevel.RoomEnemies.Enemies, loadLevel.RoomWeapon.Weapons, loadLevel.RoomProjectile.Projectiles, loadLevel.RoomBlocks.Blocks, loadLevel.RoomNPCs.NPCs, loadLevel.RoomItems.Items, overlay.Sprites, loadLevel.RoomSprite.RoomSprites);
            loadLevel.RemoveDead();
            loadLevel.AddNew();
            roomSound.RemoveDead();
            loadLevel.Clear();
            roomSound.Clear();
            overlay.Update();
        }

        public void Draw()
        {
            loadLevel.Draw(_spriteBatch);
            if (!suspendPlayer) {
                Player.Draw(_spriteBatch);
            }
            overlay.Draw(_spriteBatch);
            if (roomIndex == 4)
                text.Draw(_spriteBatch);
        }
    }
}
