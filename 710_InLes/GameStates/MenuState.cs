using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _710_InLes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _710_InLes.Tutorial
{
	public class MenuState : State
	{
		private Game game;
		private List<Component> components;
		private Texture2D titleTexture, buttonTexture;

		public MenuState(IStateChanger stateChanger,Game game, GraphicsDevice graphicsDevice, ContentManager content)
		  : base(stateChanger, graphicsDevice, content)
		{
			this.game = game;
			this.buttonTexture = content.Load<Texture2D>("GUI2");
			this.titleTexture = content.Load<Texture2D>("Title");

			var newGameButton = new Button(buttonTexture, new Rectangle(550, 160, 440, 145))
			{
				Position = new Vector2(810, 700),
			};

			newGameButton.Click += NewGameButton_Click;

			var CreditsGameButton = new Button(buttonTexture, new Rectangle(550, 465, 440, 145))
			{
				Position = new Vector2(810, 800),
			};

			var quitGameButton = new Button(buttonTexture, new Rectangle(550,620, 440, 138))
			{
				Position = new Vector2(810, 900),
			};

			quitGameButton.Click += QuitGameButton_Click;

			components = new List<Component>()
			{
				newGameButton,
				CreditsGameButton,
				quitGameButton,
			};
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
			foreach (var component in components)
				component.Draw(gameTime, spriteBatch);
			spriteBatch.Draw(titleTexture, new Rectangle(0, 0, 2000, 1000), Color.AliceBlue);
			spriteBatch.End();
		}

		private void NewGameButton_Click(object sender, EventArgs e)
		{
			stateChanger.ChangeState(new GameState(stateChanger, graphicsDevice, content));
		}


		public override void Update(GameTime gameTime)
		{
			foreach (var component in components)
				component.Update(gameTime);
		}

		private void QuitGameButton_Click(object sender, EventArgs e)
		{
			game.Exit();
		}
	}
}
