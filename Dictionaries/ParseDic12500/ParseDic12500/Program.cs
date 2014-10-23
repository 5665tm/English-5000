// Changed: 2014 10 23 8:49 PM : 5665tm

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ParseDic12500
{
	internal static class Program
	{
		private static void Main()
		{
			var lines = File.ReadAllLines("1.txt");
			var lineList = new List<string>();
			for (int index = 1; index < lines.Length; index += 3)
			{
				string line = lines[index];
				line = line.ToLowerInvariant();
				var l = line.ToCharArray().ToList();

				var engWord = new StringBuilder();

				bool findStart = false;
				int start = 0;
				int end = 0;
				foreach (char t in l)
				{
					if (t >= 'a' && t <= 'z')
					{
						findStart = true;
					}
					if (findStart)
					{
						if (t == ' ' || t == '[' || t == ',')
						{
							break;
						}
						engWord.Append(t);
					}
				}

				line = line.Split(new[]{"mfw_12500_en-ru::mfw_0001-12520"}, StringSplitOptions.None)[1];
				line = line.Split(new[]{';', ','})[0].Trim();
				if (line.Length < 20)
				{
					lineList.Add(engWord + ":::" + line);
				}

			}
			var fs = new FileStream("out.txt", FileMode.Create);
			var sw = new StreamWriter(fs);
			foreach (var li in lineList)
			{
				sw.WriteLine(li);
			}
			sw.WriteLine();
		}
	}
}