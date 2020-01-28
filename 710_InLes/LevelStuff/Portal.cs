using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _710_InLes
{
	class Portal :Tile,IAnimatedTile,ICollidable
	{
		private AnimationCreator aniCreator;

		public Animation animation { get; set; }
		public Rectangle CollisionRectangle { get; set; }

		public Portal(Texture2D texture, Vector2 position, int width, int height, float scale) :base (texture,position,width,height,scale)
		{
			this.IsPortal = true;
			this.CollisionRectangle = new Rectangle((int)position.X-10, (int)position.Y, width+10, height);
			this.aniCreator = new AnimationCreator();
			CreateAnimation();
		}

		public void CreateAnimation()
		{
			animation = new Animation();
			aniCreator.Add(animation, 0, 0, 64, 64, 5);
		}
		public void Update(GameTime gameTime)
		{
			animation.Update(gameTime);
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)(100 * scale), (int)(100 * scale)), animation.currentFrame.SourceRectangle, Color.AliceBlue);
		}
	}
}
