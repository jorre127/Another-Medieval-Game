using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	public class Lava : Tile, IAnimatedTile, ICollidable
	{
		public Animation animation { get; set; }
		public Rectangle CollisionRectangle{get; set;}

		public Lava(Texture2D texture, Vector2 position, int width, int height, float scale) :base(texture,position,width,height,scale)
		{
			this.CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, (int)(width*scale), (int)(height*scale));
			CreateAnimation();
		}
		public void CreateAnimation()
		{
			animation = new Animation();
			animation.AddFrame(new Rectangle(0, 0, 120, 120));
			animation.AddFrame(new Rectangle(145, 0, 120, 120));
			animation.AddFrame(new Rectangle(285, 0, 120, 120));
			animation.AddFrame(new Rectangle(430, 0, 120, 120));
			animation.AddFrame(new Rectangle(0, 140, 120, 120));
			animation.AddFrame(new Rectangle(145, 140, 120, 120));
			animation.AddFrame(new Rectangle(285, 140, 120, 120));
			animation.AddFrame(new Rectangle(430, 140, 120, 120));
		}
		public void Update(GameTime gameTime)
		{
			CollisionRectangle = new Rectangle((int)position.X, (int)position.Y-20, (int)(width * scale), (int)(height * scale));
			animation.Update(gameTime);
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)(100 * scale),(int)(100 * scale)), animation.currentFrame.SourceRectangle, Color.AliceBlue);
		}
	}
}
