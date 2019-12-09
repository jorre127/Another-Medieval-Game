﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
	class LevelBinder
	{
		public List<int[,]> AllLevels { get; set; }
		public int Level { get; set; } = 0;
		public int[,] currentLevel { get; set; }

		public LevelBinder()
		{
			Createlevels();
		}
		public void Createlevels()
		{
			AllLevels = new List<int[,]>
			{
				new int[,] {
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,4,0,0,0,4,0,0,0,5,3},
					{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}},

				new int[,] {
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,5,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,4,4,4,4,4,4,4,4,4,4,4,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,4,4,4,4,4,4,4,4,4,4,4,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,4,4,4,4,4,4,4,4,4,4,4,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}},
				new int[,] {
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,5,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,4,4,4,4,4,4,4,4,4,4,4,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,4,4,4,4,4,4,4,4,4,4,4,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,4,4,4,4,4,4,4,4,4,4,4,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}},
				new int[,] {
					{ 8,0,0,6,7,0,0,6,7,0,0,6,7,0,3},
					{ 0,0,0,6,7,0,0,6,7,0,0,6,7,0,3},
					{ 9,0,0,0,0,0,0,6,7,0,0,6,7,0,3},
					{ 2,0,0,0,0,0,0,6,7,0,0,0,0,0,3},
					{ 2,0,0,6,7,0,0,6,7,0,0,0,0,0,3},
					{ 2,0,0,6,7,0,0,6,7,0,0,6,7,0,3},
					{ 2,0,0,6,7,0,0,6,7,0,0,6,7,0,3},
					{ 2,0,0,6,7,0,0,0,0,0,0,6,7,0,3},
					{ 2,0,0,6,7,0,0,0,0,0,0,6,7,0,3},
					{ 2,0,0,6,7,0,0,6,7,0,0,6,7,0,3},
					{ 2,0,0,6,7,0,0,6,7,0,0,6,7,0,3},
					{ 2,0,0,6,7,0,0,6,7,0,0,6,7,0,3},
					{ 2,0,0,6,7,0,0,6,7,0,0,6,7,5,3},
					{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}},
				new int[,] {
					{ 8,0,0,6,7,0,0,0,0,0,0,0,0,0,3},
					{ 0,0,0,6,7,0,0,0,0,0,0,0,0,0,3},
					{ 9,0,0,6,7,0,0,0,0,0,0,0,0,5,3},
					{ 2,0,0,6,7,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,6,7,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,6,7,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,4,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,4,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,4,0,0,0,0,0,0,0,0,0,3},
					{ 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}},
				new int[,] {
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,0,5,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,0,4,4,3},
					{ 2,0,0,0,0,0,0,0,0,0,0,4,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,0,4,0,0,0,3},
					{ 2,0,0,0,0,0,0,0,0,4,0,0,0,0,3},
					{ 2,0,0,0,8,0,0,0,4,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,0,4,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,0,4,0,0,0,0,0,0,0,3},
					{ 2,0,0,0,0,4,0,0,0,0,0,0,0,0,3},
					{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}}
			};
			currentLevel = AllLevels[Level];
		}
		public int[,] GetCurrentLevel(int[,] levelToDraw)
		{
			currentLevel = AllLevels[Level];
			return currentLevel;
		}
	}
}
