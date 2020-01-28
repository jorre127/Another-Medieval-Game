using _710_InLes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes.Tutorial
{
	public class GameState : State
	{
		private SpriteBatch spriteBatch;
		private Player player;
		private Level currentLevel;
		private CollisionManager collidy;
		private Gravity gravity;
		private LevelCollision levelcollidy;
		private LevelBinder levelBinder;
		private BatchUpdater batchUpdater;
		private LavaSheet lava;
		private AnimationCreator aniCreator;
		private Movement movement;
		private Remote remote;
		private HUD hud;
		private float scale;

		private GameOver gameOver;
		private NextLevel nextLevel;

		public GameState(IStateChanger stateChanger, GraphicsDevice graphicsDevice, ContentManager content)
		  : base(stateChanger, graphicsDevice, content)
		{
			scale = 1.6f;
			movement = new Movement(6,12,24);
			aniCreator = new AnimationCreator();
			levelBinder = new LevelBinder();
			collidy = new CollisionManager();
			spriteBatch = new SpriteBatch(graphicsDevice);

			Texture2D texture = content.Load<Texture2D>("LightBandit_Spritesheet");
			Texture2D tileset = content.Load<Texture2D>("tileset");
			Texture2D LavaTexture = content.Load<Texture2D>("pngkey.com-lava-png-2333904");
			Texture2D portalTexture = content.Load<Texture2D>("Green Portal Sprite Sheet");
			Texture2D HeartTexture = content.Load<Texture2D>("heart-sprite-png-2");
			Texture2D NumbersTexture = content.Load<Texture2D>("aGOgp");

			remote = new KeyBoard();
			((KeyBoard)remote).downk = Keys.Down;
			((KeyBoard)remote).upk = Keys.Space;
			((KeyBoard)remote).leftk = Keys.A;
			((KeyBoard)remote).rightk = Keys.D;
			((KeyBoard)remote).sprintk = Keys.LeftShift;

			gravity = new Gravity(4,0.3f,0.7f);
			player = new Player(new Vector2(100, 800), 60, 52, scale, texture, remote, movement, aniCreator, gravity);
			lava = new LavaSheet(LavaTexture, new Vector2(-10, 1100), scale);
			currentLevel = new Level(player, tileset, portalTexture, new Vector2(-10, -40), levelBinder, lava, scale);
			levelcollidy = new LevelCollision(player, currentLevel, collidy);
			gameOver = new GameOver(player, lava, collidy,currentLevel);
			nextLevel = new NextLevel(player, currentLevel, collidy,stateChanger,graphicsDevice,content,lava);
			hud = new HUD(HeartTexture,NumbersTexture,aniCreator,player);

			batchUpdater = new BatchUpdater(gravity, player, levelcollidy, currentLevel, gameOver, nextLevel,hud);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
			player.Draw(spriteBatch);
			currentLevel.DrawLevel(spriteBatch);
			hud.Draw(spriteBatch);
			spriteBatch.End();
		}

		public override void Update(GameTime gameTime)
		{
			batchUpdater.Update(gameTime);
		}
	}
}
