﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	interface ICollidable
	{
		Rectangle CollisionRectangle { get; set; }
	}
}