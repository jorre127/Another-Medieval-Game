using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	public abstract class Tile
	{
		protected Texture2D texture;
		protected float scale;
		protected int height, width;
		public Vector2 position;

		public bool IsPortal { get; set; } = false;


		public Tile(Texture2D texture, Vector2 pos, int width, int height, float scale)
		{
			this.texture = texture;
			this.position = pos;
			this.width = width;
			this.height = height;
			this.scale = scale;
		}

		abstract public void Draw(SpriteBatch spriteBatch);
	}
}
