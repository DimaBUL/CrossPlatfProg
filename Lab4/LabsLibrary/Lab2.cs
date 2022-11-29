namespace LabsLibrary
{
	public static class Lab2
	{

		static int countWays(int m, int n)  //Funct for count of ways
		{
			int[] count = new int[n + 1];
			count[0] = 0;
			int i;

			for (i = 1; i <= n; i++)
			{
				if (i > m)
					count[i] = count[i - 1] + count[i - m];

				else if (i < m || i == 1)
					count[i] = 1;

				else
					count[i] = 2;
			}

			return count[n];
		}


		public static string Run(string pathInpFile = "INPUT.TXT")
		{
			List<int> numb = new List<int>(); //List of numbers

		Repeat:
			numb.Clear();

			string content = File.ReadAllText(pathInpFile);
			string[] subs = content.Split(' '); //Розділення на підстроки

			foreach (var sub in subs)  //Перевірка на тип даних, потрібен int
			{
				if (Int32.TryParse(sub, out _))
				{
					numb.Add(Convert.ToInt32(sub));
				}
			}

			int m = numb[0];
			int n = numb[1];

			Console.WriteLine($"m = {m} , n = {n} \n");
			Console.WriteLine($"{m} x {n} using 1 x {m} blocks");

			if (2 <= m && m <= n && n <= 50)
			{
				Console.Write("Number of ways = " + countWays(m, n));
				string result = Convert.ToString(countWays(m, n));

				return result;
			}
			else
			{
				Console.WriteLine("The entered data in file does not meet the condition 2 ≤ M ≤ N ≤ 50. ");
				Console.WriteLine("Rewrite the input file for reach the right condition 2 ≤ M ≤ N ≤ 50. ");
				string c = Console.ReadLine();
				File.WriteAllText(pathInpFile, c);
				goto Repeat;
			}
		}
	}
}