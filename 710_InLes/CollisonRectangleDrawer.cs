using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class CollisonRectangleDrawer
	{
		Texture2D[] images;
		Texture2D currentImage;
		int currentImageInt = 0;
		int frameAmount = 1;

		Vector2 screenPos;
		Vector2 targetSize;
		Vector2 sourceSize;
		Vector2 spritesheetPos = new Vector2(0, 0);

		public CollisonRectangleDrawer(Texture2D imageIn, Vector2 screenPosIn, Vector2 targetSizeIn, Vector2 sourceSizeIn)
		{
			images = new Texture2D[frameAmount];
			images[0] = imageIn;
			currentImage = images[0];

			screenPos = screenPosIn;
			targetSize = targetSizeIn;
			sourceSize = sourceSizeIn;

		}

		//animated image
		public CollisonRectangleDrawer(Texture2D[] imagesIn, Vector2 screenPosIn, Vector2 targetSizeIn, Vector2 sourceSizeIn, int frameAmountIn)
		{
			frameAmount = frameAmountIn;
			images = imagesIn;
			currentImage = images[0];

			screenPos = screenPosIn;

			targetSize = targetSizeIn;
			sourceSize = sourceSizeIn;
		}

		//spritesheet
		public CollisonRectangleDrawer(Texture2D imageIn, Vector2 screenPosIn, Vector2 targetSizeIn, Vector2 sourceSizeIn, Vector2 spritesheetPosIn)
		{
			images = new Texture2D[frameAmount];
			images[0] = imageIn;
			currentImage = images[0];
			spritesheetPos = spritesheetPosIn;

			screenPos = screenPosIn;

			targetSize = targetSizeIn;
			sourceSize = sourceSizeIn;
		}

		public void Update()
		{
			if ((currentImageInt + 1) > frameAmount)
				currentImageInt++;

			else
				currentImageInt = 0;

			currentImage = images[currentImageInt];
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(currentImage, new Rectangle((int)screenPos.X, (int)screenPos.Y, (int)targetSize.X, (int)targetSize.Y), new Rectangle((int)spritesheetPos.X, (int)spritesheetPos.Y, (int)sourceSize.X, (int)sourceSize.Y), Color.White);
		}
	}
}
