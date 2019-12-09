using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class GameOver
	{
		private Player player;
		private LavaSheet lava;
		private CollisionManager collidy;
		
		public GameOver(Player player, LavaSheet lava,CollisionManager collidy)
		{
			this.player = player;
			this.lava = lava;
			this.collidy = collidy;
		}
		public void GameoverUpdate()
		{
			foreach (var item in lava.BlokArray)
			{
				if (collidy.Update(player.CollisionRectangle, item.CollisionRectangle))
				{
					lava.resetTimer = 0;
					lava.CreateWorld();
					player.position = player.originalPosition;
				}
			}
		}
	}
}
