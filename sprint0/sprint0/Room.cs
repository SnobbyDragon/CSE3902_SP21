using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
    public class Room
    {
        private SpriteBatch _spriteBatch;
        public readonly Game1 game;

        private static PlayerSpriteFactory playerFactory;
        public static PlayerSpriteFactory PlayerFactory { get => playerFactory; }
        private IPlayer player;
        public IPlayer Player { get => player; set => player = value; }
        private LoadLevel loadLevel;
        public LoadLevel LoadLevel { get => loadLevel; set => loadLevel = value; }
        public RoomSound RoomSound { get => roomSound; }
        private RoomSound roomSound;

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
        }

        public void LoadContent()
        {
            playerFactory = new PlayerSpriteFactory(game);
            player = new Link(game, new Vector2(200, 250));
            roomSound = new RoomSound(game);
            loadLevel = new LoadLevel(game);
            collisionHandler = new AllCollisionHandler(this);
            loadLevel.PopulateLists(new LevelLoader(game, RoomIndex).LoadLevel());
            text = new Text(game);
        }

        public void Update()
        {
            player.Update();
            loadLevel.Update();
            collisionHandler.HandleAllCollisions(Player, loadLevel.RoomEnemies.Enemies, loadLevel.RoomWeapon.Weapons, loadLevel.RoomProjectile.Projectiles, loadLevel.RoomBlocks.Blocks, loadLevel.RoomNPCs.NPCs, loadLevel.RoomItems.Items);
            loadLevel.RemoveDead();
            roomSound.RemoveDead();
            loadLevel.Clear();
            roomSound.Clear();
        }

        public void Draw()
        {
            loadLevel.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            if (RoomIndex == 4)
                text.Draw(_spriteBatch);
        }
    }
}
