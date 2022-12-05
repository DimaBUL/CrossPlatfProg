using System;
using System.Collections.Generic;
using System.Linq;

namespace LabsLibrary
{
	public class Lab3Runner
	{
		public Lab3Runner(string firstLine, string secondLine, string thirdLine)
		{
			_firstInputLine = firstLine;
			_secondInputLine = secondLine;
			_thirdInputLine = thirdLine;
		}
		private readonly string _firstInputLine;
		private readonly string _secondInputLine;
		private readonly string _thirdInputLine;

		public string RunLab()
		{
			const int MAX_INT = 2000; // константа для кордону поля
			const int FREE = 2001; // ознака вільної клітини
			const int START = 0; // початкова клітина
			const int FINISH = 2003; // кінцева точка
			const int WALL = 2004; // перешкода
			Queue<int> q = new Queue<int>();
			int n;

			n = 3;


			List<List<int>> a = new List<List<int>>();
			List<List<string>> b = new List<List<string>>();
			List<string> s = new List<string>();

			for (int i = 0; i < n + 2; i++)
			{
				List<int> sub = new List<int>();
				for (int j = 0; j < n + 2; j++) //Субполе
				{
					sub.Add(MAX_INT);
				}

				a.Add(sub);
			}

			int startX = 0, startY = 0;


			for (int i = 0; i <= n; i++)
			{
				s.Add(_firstInputLine);
				s.Add(_secondInputLine);
				s.Add(_thirdInputLine);
			}

			for (int i = 0; i < n; i++)
			{
				List<string> sub_b = new List<string>();

				foreach (var str in s[i].Split()[0])  //Субполе
				{
					sub_b.Add(Convert.ToString(str));
				}
				b.Add(sub_b); //Додавання до поля
			}

			for (int i = 0; i < n; i++)
			{
				string[,] ssl = new string[n, n];


				for (int j = 0; j < n; j++)
				{
					switch (b[i][j])
					{
						case ".":

							a[i + 1][j + 1] = FREE;

							break;

						case "X":

							a[i + 1][j + 1] = FINISH;

							ssl[i, j] = "+";

							break;

						case "O":

							a[i + 1][j + 1] = WALL;

							break;

						case "@":

							a[i + 1][j + 1] = START;

							startX = i + 1;

							startY = j + 1;

							break;
					}
				}

			}

			q.Enqueue(startX);
			q.Enqueue(startY);
			bool fin = false;

			while (q.Count() > 0)
			{
				startX = q.Peek(); // винимаємо з черги координату для обробки
				q.Dequeue(); // знімаємо її з черги
				startY = q.Peek(); // другу
				q.Dequeue();

				if (a[startX - 1][startY] == FINISH)
				{
					fin = true; // фініш знайдено

					a[startX - 1][startY] = a[startX][startY] + 1;

					startX--;

					break;
				}

				else if (a[startX + 1][startY] == FINISH)
				{
					fin = true; // фініш знайдено

					a[startX + 1][startY] = a[startX][startY] + 1;

					startX++;

					break;
				}

				else if (a[startX][startY - 1] == FINISH)
				{
					fin = true; // фініш знайдено

					a[startX][startY - 1] = a[startX][startY] + 1;

					startY--;

					break;
				}

				else if (a[startX][startY + 1] == FINISH)
				{
					fin = true; // фініш знайдено

					a[startX][startY + 1] = a[startX][startY] + 1;

					startY++;

					break;
				}

				if (a[startX - 1][startY] == FREE)
				{
					q.Enqueue(startX - 1);

					q.Enqueue(startY);

					a[startX - 1][startY] = a[startX][startY] + 1;
				}

				if (a[startX + 1][startY] == FREE)
				{
					q.Enqueue(startX + 1);

					q.Enqueue(startY);

					a[startX + 1][startY] = a[startX][startY] + 1;
				}

				if (a[startX][startY - 1] == FREE)
				{
					q.Enqueue(startX);

					q.Enqueue(startY - 1);

					a[startX][startY - 1] = a[startX][startY] + 1;
				}

				if (a[startX][startY + 1] == FREE)
				{
					q.Enqueue(startX);

					q.Enqueue(startY + 1);

					a[startX][startY + 1] = a[startX][startY] + 1;
				}
			}

			if (!fin)
			{
				string res = "No";
				Console.WriteLine(res);
				return res;
			}

			while (a[startX][startY] > 1)
			{

				if (a[startX][startY] == a[startX - 1][startY] + 1)
				{

					b[startX - 2][startY - 1] = "+";

					startX--;

				}

				else if (a[startX][startY] == a[startX + 1][startY] + 1)
				{

					b[startX][startY - 1] = "+";

					startX++;

				}

				else if (a[startX][startY] == a[startX][startY - 1] + 1)
				{

					b[startX - 1][startY - 2] = "+";

					startY--;

				}

				else if (a[startX][startY] == a[startX][startY + 1] + 1)
				{

					b[startX - 1][startY] = "+";

					startY++;

				}

			}

			// вивід шляху на екран
			Console.WriteLine("Content of output file: ");
			string resu = "Y\n";
			Console.WriteLine("\nY ");
			return resu;

			for (int i = 0; i < n; i++)
			{
				foreach (var s1 in b[i])
				{
					return s1;
					Console.Write(s1);
				}

				return "\n";
				Console.WriteLine();
			}

		}
	}
}