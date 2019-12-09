using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class Blok : Tile, ICollidable
	{
		private Spriteblock sprite;
		private  Rectangle DrawRectangle;
		public Rectangle CollisionRectangle { get; set; }

		public Blok(Texture2D texture, Vector2 pos,int Width, int Height,float scale, Spriteblock sprite):base(texture,pos,Width,Height,scale)
		{
			this.sprite = sprite;
			this.CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width * scale), (int)(height * scale));
			FindDrawRectangle();
		}
		public void FindDrawRectangle()
		{
			switch (sprite)
			{
				case Spriteblock.Grass1:
					DrawRectangle = new Rectangle(190, 175, width, height);
					break;
				case Spriteblock.WallLeft:
					DrawRectangle = new Rectangle(815, 90, width, height);
					CollisionRectangle = new Rectangle((int)position.X, (int)position.Y-25, (int)(width * scale)-10, (int)(height * scale));
					break;
				case Spriteblock.WallRight:
					DrawRectangle = new Rectangle(767, 90, width, height);
					CollisionRectangle = new Rectangle((int)position.X+17, (int)position.Y-25, (int)(width * scale), (int)(height * scale));
					break;
				case Spriteblock.Platform:
					DrawRectangle = new Rectangle(600, 40, width, height);
					break;
				case Spriteblock.Cliff:
					DrawRectangle = new Rectangle(510,185, width, height);
					CollisionRectangle = new Rectangle((int)position.X, (int)position.Y - 35, (int)(width * scale), (int)(height * scale));
					break;
				case Spriteblock.PlatformSmall:
					DrawRectangle = new Rectangle(530, 40, width, height);
					CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width * scale), (int)(height * scale));
					break;
				default:
					break;
			}
		}

		public override void Draw(SpriteBatch spritebatch)
		{
			spritebatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)(100*scale), (int)(100*scale)),DrawRectangle, Color.AliceBlue);
		}
	}
}
