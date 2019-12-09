using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	interface IAnimatedTile
	{
		Animation animation { get; set; }
		void CreateAnimation();
		void Update(GameTime gameTime);
	}
}
