using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	public class AnimationCreator
	{
		public void Add(Animation currentAnimation, int startx,int starty, int Width ,int height, int NumberOfFrames)
		{
			for (int i = 0; i < NumberOfFrames; i++)
			{
				currentAnimation.AddFrame(new Rectangle(startx, starty, Width, height));
				startx += Width;
			}
		}
	}
}
