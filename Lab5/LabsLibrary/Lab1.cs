using System;
using System.Collections.Generic;
using System.Linq;

namespace LabsLibrary
{
	public class Lab1Runner
	{
		public Lab1Runner(string inputNumber)
		{
			_inputNumber = inputNumber;
		}
		private readonly string _inputNumber;

		public string RunLab()
		{
			string c = _inputNumber;

			if (Convert.ToInt32(c) < 4 || Convert.ToInt32(c) > 1032)
			{
				return "Incorrect number";
			}

			int lenNum = Convert.ToInt32(c);

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
