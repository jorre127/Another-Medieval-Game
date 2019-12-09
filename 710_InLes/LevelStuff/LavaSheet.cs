using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	public class LavaSheet
	{
		private Texture2D Texture;
		private Vector2 InitialPosition;
		private float scale;
		public int resetTimer { get; set; }
		public LavaSheet(Texture2D Texture, Vector2 position, float scale)
		{
			this.Texture = Texture;
			this.InitialPosition = position;
			this.scale = scale;
			CreateWorld();
		}
		public Lava[,] BlokArray { get; set; }= new Lava[20, 20];

		public void CreateWorld()
		{
			for (int x = 0; x < 20; x++)
			{
				for (int y = 0; y < 20; y++)
				{
						BlokArray[x, y] = new Lava(Texture, new Vector2((y * 88 * scale) + InitialPosition.X, (x * 95 * scale) + InitialPosition.Y),120,120,scale);
				}
			}
		}
		public void DrawLevel(SpriteBatch spritebatch)
		{
			for (int x = 0; x < 20; x++)
			{
				for (int y = 0; y < 20; y++)
				{
					if (BlokArray[x, y] != null)
					{
						BlokArray[x, y].Draw(spritebatch);
					}
				}
			}
		}
		public void Update(GameTime gameTime)
		{
			move(gameTime);
			foreach (var item in BlokArray)
			{
				item.Update(gameTime);
			}
		}
		public void move(GameTime gameTime)
		{
			resetTimer += gameTime.ElapsedGameTime.Milliseconds;
			foreach (var item in BlokArray)
			{
				if (resetTimer<2000)
				{
					item.position.Y -= 0.5f;
				}
				else if(resetTimer<= 2000 && resetTimer<=4000)
				{
					item.position.Y -= 1;
				}
				else if(resetTimer>=4000 && resetTimer<6000)
				{
					item.position.Y -= 2f;
				}
				else
				{
					item.position.Y -= 2;
				}
			}
		}
	}
}
