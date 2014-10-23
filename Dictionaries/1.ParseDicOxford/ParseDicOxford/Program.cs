using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ParseDicOxford
{
	class Program
	{
		static void Main()
		{
			var g = File.ReadAllLines("1.txt");
			var m = new List<string>();
			foreach (var s in g)
			{
				var f = s.Split('*');
				if (f[2].Length < 20 && f[1].Length < 20)
				{
					m.Add(f[1]+":::"+f[2]);
				}

			}

			var fs = new FileStream("DicOxford.txt", FileMode.Create);
			var sw = new StreamWriter(fs);
			foreach (var r in m)
			{
				sw.WriteLine(r);
			}
			sw.Close();
			fs.Close();
			Console.ReadKey();
		}
	}
}