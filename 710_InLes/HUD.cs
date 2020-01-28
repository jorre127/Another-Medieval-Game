using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class HUD
	{
		private Texture2D heartTexture;
		private Texture2D numbersTexture;
		private AnimationCreator aniCreator;
		private Animation numberAnimation;
		private Player player;
		public HUD(Texture2D heartTexture, Texture2D numbersTexture, AnimationCreator aniCreator,Player player)
		{
			this.heartTexture = heartTexture;
			this.numbersTexture = numbersTexture;
			this.aniCreator = aniCreator;
			this.player = player;
			this.CreateAnimation();
		}
		public void CreateAnimation()
		{
			numberAnimation = new Animation();
			aniCreator.Add(numberAnimation, 0, 0, 36, 36,10);
		}
		public void Update(GameTime gameTime)
		{
			numberAnimation.currentFrame = numberAnimation.frames[player.lives];
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(heartTexture, new Rectangle(0, 0, 100, 100), Color.AliceBlue);
			spriteBatch.Draw(numbersTexture, new Rectangle(90,20,50,50), numberAnimation.currentFrame.SourceRectangle, Color.AliceBlue);
		}
	}
}
