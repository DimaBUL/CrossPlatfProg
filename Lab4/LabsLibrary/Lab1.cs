namespace LabsLibrary
{
	public static class Lab1
	{
		public static string Run(string pathInpFile = "INPUT.TXT")
		{
			string c = "";

		Repeat:

			if (File.Exists(pathInpFile) && File.ReadAllText(pathInpFile) != "")  //Вивід коненту вх. файлу
			{
				string content = File.ReadAllText(pathInpFile);
				Console.WriteLine("Current content of inp file:");
				Console.WriteLine(content);
				c = content;
			}
			else
			{
				Console.WriteLine("Input_ number not < 4 and not > 1032");
				string numb = Console.ReadLine();
				File.WriteAllText(pathInpFile, numb);
			}

			while (!Int32.TryParse(c, out _))  //Поки не буде int , буде змушувати переписати введені дані
			{
				if (!string.IsNullOrEmpty(c))
				{

				}
				else
				{
					Console.WriteLine("You type nothing, please input number (int) ");
				}

				Console.Write("You used wrong type of data \n" + "Please retype data (type int) or repeat your number \n");

				c = Console.ReadLine();
			}


			if (Convert.ToInt32(c) < 4 || Convert.ToInt32(c) > 1032)
			{
				Console.WriteLine("You entered incorrect number, please input number not < 4 and not > 1032  \n");
				c = Console.ReadLine();
				File.WriteAllText(pathInpFile, c);
				goto Repeat;
			}


			int lenNum = Convert.ToInt32(c);

			Console.WriteLine("Searchable number : " + lenNum);

			List<int> lucky_numb = new List<int>();

			lucky_numb.Add(0);
			lucky_numb.Add(4);
			lucky_numb.Add(7);


			int ind = 3;

			while (lucky_numb.Last() <= lenNum)
			{

				if (ind % 2 != 0)
					lucky_numb.Add(lucky_numb[ind / 2] * 10 + 4);
				else
					lucky_numb.Add(lucky_numb[(ind / 2) - 1] * 10 + 7);
				ind += 1;
			}

			int res = (lucky_numb.Count - 2);
			string result = Convert.ToString(res);
			return  result;
		}
	}
}
