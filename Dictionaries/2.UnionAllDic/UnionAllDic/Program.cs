// Changed: 2014 10 23 10:29 PM : 5665tm

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnionAllDic
{
	internal static class Program
	{
		private static void Main()
		{
			var txt1 = File.ReadAllLines("1.txt");
			var txt2 = File.ReadAllLines("2.txt");
			var listAll = txt2.ToList();
			listAll.AddRange(txt1);
			var dic = new Dictionary<string, string>();
			foreach (var ph in listAll)
			{
				string lowph = ph.ToLowerInvariant();
				var split = lowph.Split(new[] {":::"}, StringSplitOptions.None);
				if (!dic.ContainsKey(split[0]))
				{
					var g = split[0].ToCharArray();
					foreach (var t in g)
					{
						if (t < 'a' || t > 'z')
						{
							goto LABEL;
						}
					}
					dic.Add(split[0], split[1]);
					Console.WriteLine(dic.Count);
					LABEL:
					;
				}
			}
			var fs = new FileStream("outdic.txt", FileMode.Create);
			var sw = new StreamWriter(fs);
			var dic2 = dic.OrderBy(x => x.Key).ToDictionary(source => source.Key, source => source.Value);
			var usedSymbol = new List<char>();
			foreach (var source in dic2)
			{
				sw.WriteLine(source.Key + "\t" + source.Value);
			}
			foreach (var t in usedSymbol.OrderBy(x => x))
			{
				Console.WriteLine(t);
			}
			sw.Close();
			fs.Close();
			Console.ReadKey();
		}
	}
}