using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class Background
	{
		private Texture2D backgroundTexture1;
		private Texture2D backgroundTexture2;
		private Texture2D backgroundTexture3;
		public Background(Texture2D bg1, Texture2D bg2, Texture2D bg3)
		{
			backgroundTexture1 = bg1;
			backgroundTexture2 = bg2;
			backgroundTexture3 = bg3;
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
			spriteBatch.Draw(backgroundTexture3, new Rectangle(0, 0, 2000, 500), Color.White);
			spriteBatch.Draw(backgroundTexture1, new Rectangle(0, 750,2000,500), Color.White);
			spriteBatch.Draw(backgroundTexture2, new Rectangle(0,250, 2000, 500), Color.White);
			spriteBatch.End();
		}

	}
}