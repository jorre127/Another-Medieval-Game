using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	public class Movement
	{

		private int sprintSpeed;
		public float jumpheight { get; set; }
		public bool IsWallSliding { get; set; }
		public bool IsWallJumping { get; set; }
		public bool IsJumping { get; set; }
		public int originalmovementSpeed { get; set; }
		public float originalJumpheight { get; set; }
		public int movementSpeed { get; set; }
		public Movement(int Movementspeed, int sprintSpeed, int jumpheight)
		{
			this.originalmovementSpeed = Movementspeed;
			this.movementSpeed = this.originalmovementSpeed;
			this.sprintSpeed = sprintSpeed;
			this.originalJumpheight = jumpheight;
			this.jumpheight = this.originalJumpheight;
		}

		public void MoveLeft(ref Vector2 position)
		{
			position.X -= movementSpeed;
		}
		public void MoveRight(ref Vector2 position)
		{
			position.X += movementSpeed;
		}
		public void SprintLeft(ref Vector2 position)
		{
			position.X -= sprintSpeed;
		}
		public void SprintRight(ref Vector2 position)
		{
			position.X += sprintSpeed;
		}
		public void Jump(ref Vector2 position)
		{
			position.Y -= jumpheight;
		}
		public void WallJump(ref Vector2 position)
		{
			Jump(ref position);
			IsWallJumping = true;
		}
		public void WallSliding(Player player, Gravity gravity)
		{
			if (((player.collideLeft && player.remote.left) || (player.remote.right && player.collideRight)) && !player.collideDown && !IsWallJumping)
			{
				gravity.gravityStrength = 2.5f;
				player.movement.jumpheight = 0;
			}
			else
			{
				IsWallJumping = false;
			}
		}
	}
}
