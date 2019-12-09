using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	public class Player : ICollidable
	{
		private AnimationCreator aniCreator;

		public bool collideRight, collideLeft, collideUp, collideDown;
		private Texture2D texture, currentTexture;
		public Vector2 position, originalPosition;
		public Movement movement;
		public Animation animationLeft, animationRight, animationIdle, currentAnimation, animationSprintLeft, animationSprintRight, animationJump;
		public Remote remote;
		public Rectangle CollisionRectangleLeft, CollisionRectangleRight, CollisionRectangleUp, CollisionRectangleDown;
		public Rectangle CollisionRectangle{get;set;}
		public int width, height;
		float scale;

		public Player(Vector2 _position, int width, int height, float scale, Texture2D texture, Remote keyBoard, Movement movement,AnimationCreator aniCreator)
		{
			this.texture = texture;
			this.currentTexture = texture;
			this.remote = keyBoard;
			this.movement = movement;
			this.width = width;
			this.height = height;
			this.scale = scale;
			this.aniCreator = aniCreator;
			CreateAnimationLeftRight();
			Init(_position, keyBoard);
		}
		private void Init(Vector2 _position, Remote keyBoard)
		{
			originalPosition = _position;
			position = originalPosition;
			remote = keyBoard;
		}
		private void CreateAnimationLeftRight()
		{
			animationLeft = new Animation();
			animationRight = new Animation();
			animationIdle = new Animation();
			animationSprintLeft = new Animation();
			animationSprintRight = new Animation();
			animationJump = new Animation();

			aniCreator.Add(animationLeft, 0, 50, 48, 45, 4);
			aniCreator.Add(animationRight, 0, 50, 48, 45, 4);
			aniCreator.Add(animationIdle, 0, 0, 48, 45, 4);
			aniCreator.Add(animationSprintLeft, 240, 50, 48, 45, 3);
			aniCreator.Add(animationSprintRight, 240, 50, 48, 45, 3);
			aniCreator.Add(animationJump, 240, 190, 48, 45, 1);
			currentAnimation = animationLeft;
		}
		private void MoveLeft()
		{
			if (remote.Sprint)
			{
				movement.SprintLeft(ref position);
				currentAnimation = animationSprintLeft;
			}
			else
			{
				movement.MoveLeft(ref position);
				currentAnimation = animationLeft;
			}
		}
		private void MoveRight()
		{
			if (remote.Sprint)
			{
				movement.SprintRight(ref position);
				currentAnimation = animationSprintRight;
			}
			else
			{
				movement.MoveRight(ref position);
				currentAnimation = animationRight;
			}
		}
		private void Jump()
		{
			movement.Jump(ref position);
			if (movement.IsWallSliding)
			{
				if ((remote.left && collideRight) || (remote.right && collideLeft))
				{
					movement.IsWallSliding = false;
					movement.WallJump(collideLeft, collideRight, movement.IsJumping, ref position);
				}
			}
			currentAnimation = animationJump;

			if (!remote.up)
			{
				movement.IsJumping = false;
			}
		}
		private void DoNothing()
		{
				currentAnimation = animationIdle;
		}
		private void MovementManager()
		{
			if (remote.left && !collideLeft && (!movement.IsWallSliding))
			{
				MoveLeft();
			}
			if (remote.right && !collideRight && (!movement.IsWallSliding))
			{
				MoveRight();
			}
			if (!collideUp && remote.up)
			{
				Jump();
			}
			if (!remote.up && !remote.left && !remote.right)
			{
				DoNothing();
			}
			if (collideUp)
			{
				movement.jumpheight = 0;
			}
		}
		public void Update(GameTime gameTime)
		{
			remote.Update();
			MovementManager();
			CollisionRectangle = new Rectangle((int)position.X-20, (int)position.Y, (int)(width * scale)+30, (int)(height * scale) + 30);
			CollisionRectangleLeft = new Rectangle((int)position.X - 20, (int)position.Y, (int)((width / 2) * scale), (int)((height / 2) * scale));
			CollisionRectangleRight = new Rectangle((int)position.X + (width / 2), (int)position.Y + 10, (int)((width / 2) + 30 * scale), (int)((height / 2) * scale));
			CollisionRectangleUp = new Rectangle((int)position.X, (int)position.Y - 20, (int)(width * scale), (int)((height / 10) * scale));
			CollisionRectangleDown = new Rectangle((int)position.X + 1, (int)position.Y + (int)(height / 2), (int)(width * scale), (int)(height + 20 * scale));
			currentAnimation.Update(gameTime);
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			// spriteBatch.Draw(currentTexture, position,currentAnimation.currentFrame.SourceRectangle, Color.White);
			if (remote.left)
			{
				spriteBatch.Draw(currentTexture, new Rectangle((int)position.X, (int)position.Y, (int)(100 * scale), (int)(100 * scale)), currentAnimation.currentFrame.SourceRectangle, Color.AliceBlue);
			}
			else
			{
				spriteBatch.Draw(currentTexture, new Rectangle((int)position.X, (int)position.Y, (int)(100 * scale), (int)(100 * scale)), currentAnimation.currentFrame.SourceRectangle, Color.AliceBlue, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
			}
		}
	}
}
