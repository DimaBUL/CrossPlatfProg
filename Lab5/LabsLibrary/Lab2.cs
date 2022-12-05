using System;
using System.Collections.Generic;

namespace LabsLibrary
{
	public class Lab2Runner
	{

		public Lab2Runner(string firstInputNumber, string secondInputNumber)
		{
			_firstInputNumber = firstInputNumber;
			_secondInputNumber = secondInputNumber;
		}
		private readonly string _firstInputNumber;
		private readonly string _secondInputNumber;

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


		public string RunLab()
		{
			List<int> numb = new List<int>(); //List of numbers

			var subs = new string[] {_firstInputNumber, _secondInputNumber }; //Розділення на підстроки

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
				return "Wrong input";
			}
		}
	}
}