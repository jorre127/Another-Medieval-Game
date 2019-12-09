using _710_InLes.Interfaces;
using _710_InLes.Tutorial;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes.GameStates
{
	class EndState : State
	{
		Texture2D texture;
		public EndState(IStateChanger game, GraphicsDevice graphicsDevice, ContentManager content)
		: base(game, graphicsDevice, content)
		{
			this.texture = content.Load<Texture2D>("EndScreenGame");

		}
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
			spriteBatch.Draw(texture, new Rectangle(0, 0, 2000, 1000), Color.AliceBlue);
			spriteBatch.End();
		}

		public override void Update(GameTime gameTime)
		{
		}
	}
}
