using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class Gravity
	{
		private float originalgravityStrength, gravityStrength, changeInStrength, changeInJumpheight;
		private CollisionManager collidy;
		private Player player;
		private Level level;
		public Gravity(Player player, Level level, int gravity,CollisionManager collidy)
		{
			this.originalgravityStrength = gravity;
			this.gravityStrength = this.originalgravityStrength;
			this.player = player;
			this.changeInStrength = 0.3f;
			this.changeInJumpheight = 0.7f;
			this.level = level;
			this.collidy = collidy;
		}
		public void Update()
		{
			if (!player.collideDown)
			{
				gravityStrength += changeInStrength;
				player.movement.jumpheight -= changeInJumpheight;
				player.position.Y += gravityStrength;
			}
			else
			{
				player.movement.IsDoubleJump = false;
				gravityStrength = originalgravityStrength;
				player.movement.jumpheight = player.movement.originalJumpheight;
				player.movement.movementSpeed = player.movement.originalmovementSpeed;
			}
			if (((player.collideLeft || player.collideRight)) && !player.collideDown && !player.movement.IsDoubleJump && (player.remote.left || player.remote.right))
			{
				gravityStrength = 2.5f;
				player.movement.jumpheight = 0;
				player.movement.IsWallSliding = true;
				player.movement.IsDoubleJump = false;
			}
			if ((player.collideLeft || player.collideRight) && !player.collideDown)
			{
				player.movement.IsDoubleJump=false;
			}
			else
			{
				player.movement.IsWallSliding = false;
			}
		}
	}
}
