using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes.Tutorial
{
	public class Button : Component
	{

		private MouseState currentMouse;

		private bool isHovering;

		private MouseState previousMouse;

		private Texture2D texture;


		public event EventHandler Click;

		public bool Clicked { get; private set; }

		public Color PenColour { get; set; }

		public Vector2 Position { get; set; }
		public Rectangle DrawRectangle { get; set; }
		public Rectangle PositionRectangle
		{
			get
			{
				return new Rectangle((int)Position.X, (int)Position.Y, (int)(300), (int)(100));
			}
		}

		public string Text { get; set; }


		public Button(Texture2D texture, Rectangle rectangle)
		{
			this.texture = texture;
			this.DrawRectangle = rectangle;
			this.PenColour = Color.Black;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			var colour = Color.White;

			if (isHovering)
				colour = Color.Gray;

			spriteBatch.Draw(texture,PositionRectangle, DrawRectangle, colour);
		}

		public override void Update(GameTime gameTime)
		{
			previousMouse = currentMouse;
			currentMouse = Mouse.GetState();

			var mouseRectangle = new Rectangle(currentMouse.X+100, currentMouse.Y, 1, 1);

			isHovering = false;
			if (mouseRectangle.Intersects(PositionRectangle))
			{
				isHovering = true;

				if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
				{
					Click?.Invoke(this, new EventArgs());
				}
			}
		}

	}
}
