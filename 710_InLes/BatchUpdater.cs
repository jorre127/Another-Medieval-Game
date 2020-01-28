using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class BatchUpdater
	{
		private Gravity gravity;
		private Player player;
		private LevelCollision levelcollidy;
		private Level currentLevel;
		private GameOver gameOver;
		private NextLevel nextLevel;
		private HUD hud;
		public BatchUpdater(Gravity gravity, Player player,LevelCollision levelcollidy,Level currentLevel,GameOver gameOver,NextLevel nextLevel, HUD hud)
		{
			this.gravity = gravity;
			this.player = player;
			this.levelcollidy = levelcollidy;
			this.currentLevel = currentLevel;
			this.gameOver = gameOver;
			this.nextLevel = nextLevel;
			this.hud = hud;
		}
		public void Update(GameTime gameTime)
		{
			nextLevel.nextLevelUpdate();
			gravity.Update(player);
			player.Update(gameTime);
			levelcollidy.Update();
			currentLevel.Update(gameTime);
			gameOver.GameoverUpdate(gameTime);
			hud.Update(gameTime);
		}
	}
}
