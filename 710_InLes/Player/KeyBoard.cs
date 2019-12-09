using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{

 

    public abstract class Remote
    {
        public bool left { get; set; }
        public bool right { get; set; }
		public bool Sprint { get; set; }
		public bool up { get; set; }
        public abstract void Update();
    }

    public class JoyStick : Remote
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class KeyBoard : Remote
    {
        public Keys leftk { get; set; }
        public Keys rightk { get; set; }
        public Keys upk { get; set; }
        public Keys downk { get; set; }
		public Keys sprintk { get; set; }
		public Keys jumpk { get; set; }

        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(leftk))
            {
                left = true;
            }
            if (stateKey.IsKeyUp(leftk))
            {
                left = false;
            }

            if (stateKey.IsKeyDown(rightk))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(rightk))
            {
                right = false;
            }
			if (stateKey.IsKeyDown(sprintk))
			{
				Sprint = true;
			}
			if (stateKey.IsKeyUp(sprintk))
			{
				Sprint = false;
			}
			if (stateKey.IsKeyDown(upk))
			{
				up = true;
			}
			if (stateKey.IsKeyUp(upk))
			{
				up = false;
			}

		}
    }
}
