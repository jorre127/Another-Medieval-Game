using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	public class Gravity
	{
		private float originalgravityStrength, changeInStrength, changeInJumpHeight;

		public float gravityStrength { get; set; }
		public Gravity(int gravity, float changeInStrength, float changeInJumpHeight)
		{
			this.originalgravityStrength = gravity;
			this.gravityStrength = this.originalgravityStrength;
			this.changeInStrength = changeInStrength;
			this.changeInJumpHeight = changeInJumpHeight;
		}
		public void Update(Player player)
		{
			if (!player.collideDown)
			{
				gravityStrength += changeInStrength;
				player.movement.jumpheight -= changeInJumpHeight;
				player.position.Y += gravityStrength;
			}
			else
			{
				gravityStrength = originalgravityStrength;
				player.movement.jumpheight = player.movement.originalJumpheight;
			}
		}
	}
}
