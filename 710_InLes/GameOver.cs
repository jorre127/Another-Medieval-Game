using Microsoft.Xna.Framework;
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
		private Level level;
		private int previousTime;
		
		public GameOver(Player player, LavaSheet lava,CollisionManager collidy, Level level)
		{
			this.player = player;
			this.lava = lava;
			this.collidy = collidy;
			this.level = level;
			this.previousTime = 0;
		}
		public void GameoverUpdate(GameTime gametime)
		{
			foreach (var item in lava.BlokArray)
			{
				if (collidy.Update(player.CollisionRectangle, item.CollisionRectangle))
				{
					lava.resetTimer = 0;
					lava.CreateWorld();
					player.position = player.originalPosition;

					if (gametime.TotalGameTime.Seconds - previousTime >= 1)
					{
						player.lives--;
						previousTime = gametime.TotalGameTime.Seconds;
					}
					if(player.lives == 0)
					{
						player.lives = 3;
						for (int x = 0; x < 14; x++)
						{
							for (int y = 0; y < 15; y++)
							{
								level.BlokArray[x, y] = null;
							}
						}

						level.levelbinder.Level = 0;
						level.CreateWorld();
						player.position = player.originalPosition;
					}
				}
			}
		}
	}
}
