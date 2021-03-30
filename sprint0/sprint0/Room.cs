using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Room
    {
        private readonly SpriteBatch _spriteBatch;
        public readonly Game1 game;
        private readonly string message = "EASTMOST PENINSULA IS THE SECRET.";
        private readonly Vector2 messageLoc = new Vector2(170,170);
        private static PlayerSpriteFactory playerFactory;
        public static PlayerSpriteFactory PlayerFactory { get => playerFactory; }
        private IPlayer player;
        public IPlayer Player { get => player; set => player = value; }
        private LoadLevel loadLevel;
        public LoadLevel LoadLevel { get => loadLevel; set => loadLevel = value; }
        public RoomSound RoomSound { get => roomSound; }
        private RoomSound roomSound;
        public Overlay Overlay { get => overlay; }
        private Overlay overlay;

        private readonly int LinkDefaultX = 250;
        private readonly int LinkDefaultY = 250;

        private AllCollisionHandler collisionHandler;
        private readonly int RoomIndex;
        private Text text;

        private ISprite sprite;
        private SpriteFont font;
        public ISprite Sprite { get => sprite; set => sprite = value; }
        public SpriteFont Font { get => font; set => font = value; }

        public Room(SpriteBatch spriteBatch, Game1 game, int RoomIndex)
        {
            this.game = game;
            _spriteBatch = spriteBatch;
            this.RoomIndex = RoomIndex;
            collisionHandler = new AllCollisionHandler(game, this);
        }

        public void LoadContent()
        {
            overlay = new Overlay();
            playerFactory = new PlayerSpriteFactory(game);
            Player = new Link(game, new Vector2(LinkDefaultX, LinkDefaultY));
            roomSound = new RoomSound(game);
            loadLevel = new LoadLevel(game);
            loadLevel.PopulateLists(new LevelLoader(game, RoomIndex).LoadLevel());
            text = new Text(game, message, messageLoc, Color.White);
        }

        public void Update()
        {
            player.Update();
            loadLevel.Update();
            collisionHandler.HandleAllCollisions(Player, loadLevel.RoomEnemies.Enemies, loadLevel.RoomWeapon.Weapons, loadLevel.RoomProjectile.Projectiles, loadLevel.RoomBlocks.Blocks, loadLevel.RoomNPCs.NPCs, loadLevel.RoomItems.Items, overlay.Sprites);
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
            player.Draw(_spriteBatch);
            overlay.Draw(_spriteBatch);
            if (RoomIndex == 4)
                text.Draw(_spriteBatch);
        }
    }
}
