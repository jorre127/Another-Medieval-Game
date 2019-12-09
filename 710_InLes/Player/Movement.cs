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

		private int sprintSpeed = 12;
		public float jumpheight { get; set; } = 15;
		public bool IsDoubleJump { get; set; } = false;
		public bool IsWallSliding { get; set; }
		public bool IsJumping { get; set; }
		public int originalmovementSpeed { get; set; }
		public float originalJumpheight { get; set; } = 24;
		public int movementSpeed { get; set; }
		public Movement(int Movementspeed)
		{
			originalmovementSpeed = Movementspeed;
			movementSpeed = originalmovementSpeed;
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
			IsJumping = true;
			position.Y -= jumpheight;
			movementSpeed = 11;

		}
		public void WallJump(bool left, bool right, bool jump, ref Vector2 position)
		{
			if (!IsDoubleJump)
			{
				jumpheight = 20;
				Jump(ref position);
				IsDoubleJump = true;
				movementSpeed = 12;
			}
		}
		public void Dash()
		{

		}
	}
}
