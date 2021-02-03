using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<IController> controllerList;
        private ISprite sprite;
        private ISprite text;
        private Texture2D texture;
        private SpriteFont font;
        public ISprite Sprite { get => sprite; set => sprite = value; }
        public Texture2D Texture { get => texture; }
        public SpriteFont Font { get => font; set => font = value; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            controllerList = new List<IController>();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new MouseController(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //texture = Content.Load<Texture2D>("Images/samus-sprites");
            //font = Content.Load<SpriteFont>("Font");
            //sprite = new NonMovingNonAnimatedSprite(texture, new Vector2(400, 200));
            //text = new TextSprite(Font, "Credits\n" +
            //    "Program made by: Jesse He\n" +
            //    "Sprites from: www.spriters-resource.com/game_boy_advance/metzero/sheet/106418/");
            //text.Location = new Vector2(100, 400);
            SpriteFactory spriteFactory = new SpriteFactory(this);
            sprite = spriteFactory.MakeSprite("aquamentus");
            sprite.Location = new Vector2(400, 200);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //TODO need to make new commands
            //foreach (IController controller in controllerList)
            //{
            //    controller.Update();
            //}
            Sprite.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            //text.Draw(_spriteBatch);
            sprite.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
