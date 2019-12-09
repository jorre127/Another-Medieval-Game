using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
    public class Animation
    {
        private List<AnimationFrame> frames;
        public AnimationFrame currentFrame;
        private double xOffset;
        int counter = 0;

        public Animation()
        {
            frames = new List<AnimationFrame>();
            xOffset = 0;
        }

        public void AddFrame(Rectangle rectangle)
        {
            AnimationFrame frame = new AnimationFrame()
            {
                SourceRectangle = rectangle
            };

            frames.Add(frame);
            currentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            xOffset += 64 * gameTime.ElapsedGameTime.Milliseconds / 70;
            if (xOffset >= 64)
            {
                counter++;
                if (counter >= frames.Count)
                    counter = 0;

                currentFrame = frames[counter];
                xOffset = 0;
            }
        }
	}
}
