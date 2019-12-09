using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class Level
	{
		private Texture2D texture, portalTexture;
		private Vector2 InitialPosition;
		private LavaSheet lava;
		private Player player;
		private float scale = 1;
		private int[,] levelToDraw;
		private bool IsLavaLevel;

		public LevelBinder levelbinder { get; set; }
		public Level(Player player, Texture2D texture, Texture2D portalTexture, Vector2 position, LevelBinder levelbinder, LavaSheet lava, float scale)
		{
			this.texture = texture;
			this.InitialPosition = position;
			this.scale = scale;
			this.levelbinder = levelbinder;
			this.levelToDraw = levelbinder.currentLevel;
			this.lava = lava;
			this.portalTexture = portalTexture;
			this.player = player;
			CreateWorld();
		}
		public Tile[,] BlokArray { get; set; } = new Tile[14, 15];

		public void CreateWorld()
		{
			DecideTypeOfLevel();
			levelToDraw = levelbinder.GetCurrentLevel(levelToDraw);
			for (int x = 0; x < 14; x++)
			{
				for (int y = 0; y < 15; y++)
				{
					if (levelToDraw[x, y] == 1)
						BlokArray[x, y] = new Blok(texture, new Vector2((y * 83 * scale) + InitialPosition.X, (x * 49 * scale) + InitialPosition.Y), 57, 50, scale, Spriteblock.Grass1);
					if (levelToDraw[x, y] == 2)
						BlokArray[x, y] = new Blok(texture, new Vector2((y * 48 * scale) + InitialPosition.X, (x * 64 * scale) + InitialPosition.Y), 40, 50, scale, Spriteblock.WallLeft);
					if (levelToDraw[x, y] == 3)
						BlokArray[x, y] = new Blok(texture, new Vector2((y * 81 * scale) + InitialPosition.X, (x * 64 * scale) + InitialPosition.Y), 40, 50, scale, Spriteblock.WallRight);
					if (levelToDraw[x, y] == 4)
						BlokArray[x, y] = new Blok(texture, new Vector2((y * 81 * scale) + InitialPosition.X, (x * 47 * scale) + InitialPosition.Y), 55, 50, scale, Spriteblock.Platform);
					if (levelToDraw[x, y] == 5)
						BlokArray[x, y] = new Portal(portalTexture, new Vector2((y * 81 * scale) + InitialPosition.X, (x * 45 * scale) + InitialPosition.Y), 64, 64, scale);
					if (levelToDraw[x, y] == 6)
						BlokArray[x, y] = new Blok(texture, new Vector2((y * 80 * scale) + InitialPosition.X, (x * 64 * scale) + InitialPosition.Y), 40, 50, scale, Spriteblock.WallRight);
					if (levelToDraw[x, y] == 7)
						BlokArray[x, y] = new Blok(texture, new Vector2((y * 80 * scale) + InitialPosition.X, (x * 64 * scale) + InitialPosition.Y), 40, 50, scale, Spriteblock.WallLeft);
					if (levelToDraw[x, y] == 8)
						player.originalPosition = new Vector2((y * 80 * scale) + InitialPosition.X, (x * 64 * scale) + InitialPosition.Y);
					if (levelToDraw[x, y] == 9)
						BlokArray[x, y] = new Blok(texture, new Vector2((y * 48 * scale) + InitialPosition.X, (x * 54 * scale) + InitialPosition.Y), 45, 85, scale, Spriteblock.Cliff);
				}
			}
		}
		public void DecideTypeOfLevel()
		{
			if (levelbinder.Level == 2)
			{
				IsLavaLevel = true;
			}
			else
			{
				IsLavaLevel = false;
			}
		}
		public void DrawLevel(SpriteBatch spritebatch)
		{
			for (int x = 0; x < 14; x++)
			{
				for (int y = 0; y < 15; y++)
				{
					if (BlokArray[x, y] != null)
					{

						BlokArray[x, y].Draw(spritebatch);
					}
				}
			}
			if (IsLavaLevel)
			{
				lava.DrawLevel(spritebatch);
			}
		}
		public void Update(GameTime gameTime)
		{
			if (IsLavaLevel)
			{
				lava.Update(gameTime);
			}
			foreach (var item in BlokArray)
			{
				if (item != null)
				{
					if (item.IsPortal)
					{
						Portal tempPortal = (Portal)item;
						tempPortal.Update(gameTime);
					}
				}
			}
		}
	}
}
