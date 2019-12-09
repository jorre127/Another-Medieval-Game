using _710_InLes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes.Tutorial
{
	public abstract class State
	{

		protected ContentManager content;

		protected GraphicsDevice graphicsDevice;

		protected IStateChanger stateChanger;



		public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);


		public State(IStateChanger game, GraphicsDevice graphicsDevice, ContentManager content)
		{
			this.stateChanger = game;

			this.graphicsDevice = graphicsDevice;

			this.content = content;
		}

		public abstract void Update(GameTime gameTime);

	}
}
