using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class LevelCollision
	{
		private Player player;
		private Level level;
		private CollisionManager collidy;
		private ICollidable tempblok1, tempblok2, tempblok3, tempblok4;

		public LevelCollision(Player player, Level level, CollisionManager collidy)
		{
			this.player = player;
			this.level = level;
			this.collidy = collidy;
		}
		public void Update()
		{
			foreach (ICollidable item in level.BlokArray)
			{
				if (item != null)
				{
					if (collidy.Update(player.CollisionRectangleRight,item.CollisionRectangle))
					{
						player.collideRight = true;
						tempblok1 = item;
					}
					if((tempblok1 != null)&&!collidy.Update(player.CollisionRectangleRight, tempblok1.CollisionRectangle))
					{
						player.collideRight = false;
					}
					if (collidy.Update(player.CollisionRectangleLeft, item.CollisionRectangle))
					{
						player.collideLeft = true;
						tempblok2 = item;
					}
					if ((tempblok2 != null) && !collidy.Update(player.CollisionRectangleLeft, tempblok2.CollisionRectangle))
					{
						player.collideLeft= false;
					}
					if (collidy.Update(player.CollisionRectangleUp, item.CollisionRectangle))
					{
						player.collideUp = true;
						tempblok4 = item;
					}
					if ((tempblok4 !=null) && !collidy.Update(player.CollisionRectangleUp, tempblok4.CollisionRectangle))
					{
						player.collideUp = false;
					}
					if (collidy.Update(player.CollisionRectangleDown, item.CollisionRectangle))
					{
						player.collideDown = true;
						tempblok3= item;
					}
					if ((tempblok3 != null) && !collidy.Update(player.CollisionRectangleDown, tempblok3.CollisionRectangle))
					{
						player.collideDown = false;
					}
				}
			}
		}
	}
}
