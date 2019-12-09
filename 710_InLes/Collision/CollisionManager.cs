using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
    class CollisionManager
    {
		public bool Update(Rectangle p1, Rectangle level)
		{
				if (level != null)
				{
					if (p1.Intersects(level))
					{
						return true;
					}
				}
			return false;
		}
		public ICollidable ReturnCollision(ICollidable p1, ICollidable level)
		{
			if (level != null)
			{
				if (p1.CollisionRectangle.Intersects(level.CollisionRectangle))
				{
					return level;
				}
			}
			return null;
		}
	}
}
