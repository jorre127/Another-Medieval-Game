using _710_InLes.GameStates;
using _710_InLes.Interfaces;
using _710_InLes.Tutorial;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class NextLevel
	{
		private Player player;
		private Level level;
		private CollisionManager collidy;

		private IStateChanger stateChanger;
		private GraphicsDevice graphicsDevice;
		private ContentManager content;
		private bool skip = false;
		
	


		public NextLevel(Player player, Level level, CollisionManager collidy, IStateChanger stateChanger,GraphicsDevice graphicsDevice,ContentManager content)
		{
			this.player = player;
			this.level = level;
			this.collidy = collidy;
			this.stateChanger = stateChanger;
			this.graphicsDevice = graphicsDevice;
			this.content = content;
		}
		public void nextLevelUpdate()
		{
			foreach (var item in level.BlokArray)
			{
				Tile temptile = (Tile)collidy.ReturnCollision(player, (ICollidable)item);
				if (temptile != null && temptile.IsPortal)
				{
					for (int x = 0; x < 14; x++)
					{
						for (int y = 0; y < 15; y++)
						{
							level.BlokArray[x, y] = null;
						}
					}
					level.levelbinder.Level++;
					if (level.levelbinder.Level  >= level.levelbinder.AllLevels.Count)
					{
						stateChanger.ChangeState(new EndState(stateChanger, graphicsDevice, content));
						skip = true;
					}
					if (!skip)
					{
						level.CreateWorld();
						player.position = player.originalPosition;
					}
				}
			}
		}
	}
}
