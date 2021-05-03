using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
 
namespace GameOfLife.Data
{
	public class Blocks
	{
		public static string[] FileToBlocks(string filename, int len)
		{
			List<string> NewList = new List<string>();

			foreach (string str in File.ReadAllText(filename).Split('\n').ToList())
				if (str.Length == len)
					NewList.Add(str);
            
			return NewList.ToArray();
		}

		static string[] ConvertToBlocks(string[] strs, int blockSize)
		{
			string fullString = string.Join("", strs);
			int strlen = fullString.Length;
			string[] Blocks = new string[1 + strlen / blockSize];

			StringBuilder Block = new StringBuilder();

			int x = 0;
			int y = 0;

			for(int i = 0; i < strlen; i++)
			{
				Block.Append(fullString[i]);

				if (x == blockSize || i == strlen - 1)
				{
					Blocks[y] = Block.ToString();
					x = 0;
					y++;
					Block = new StringBuilder();
				}

				x++;
			}

			return Blocks;
		}
	}
}
