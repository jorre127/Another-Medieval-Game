using _710_InLes.Interfaces;
using _710_InLes.Tutorial;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _710_InLes
{
	enum Spriteblock { Grass1,WallLeft,WallRight,Platform,PlatformSmall,Cliff,Finish};
    public class Game1 : Game ,IStateChanger
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
		private Background background;
		private State currentState;
		private State nextState;

		public void ChangeState(State state)
		{
			this.nextState = state;
		}

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
			graphics.PreferredBackBufferWidth = 1920;
			graphics.PreferredBackBufferHeight = 1080;
		}
        protected override void Initialize()
        {
			IsMouseVisible = true;

            base.Initialize();
        }
        protected override void LoadContent()
        {
			spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
			currentState = new MenuState(this,this, graphics.GraphicsDevice, Content);

			Texture2D backgroundtexture1 = Content.Load<Texture2D>("sea");
			Texture2D backgroundtexture2 = Content.Load<Texture2D>("clouds");
			Texture2D backgroundtexture3 = Content.Load<Texture2D>("sky");
			background = new Background(backgroundtexture1, backgroundtexture2, backgroundtexture3);
		}
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			if(nextState != null)
			{
				currentState = nextState;
				nextState = null;
			}

			currentState.Update(gameTime);

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			background.Draw(spriteBatch);
			currentState.Draw(gameTime, spriteBatch);


            base.Draw(gameTime);
        }
    }
}
