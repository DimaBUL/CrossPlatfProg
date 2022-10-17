using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lab1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            string pathInpFile = "/Users/mac/CrossProgr/Lab1/Lab1/INPUT.txt"; //Шлях до файлів
            string pathOutFile = "/Users/mac/CrossProgr/Lab1/Lab1/OUTPUT.txt";
            


            //Перевірка типу введених даних
            
            // Console.WriteLine("Input number not < 4 and not > 1032");
            // string c = Console.ReadLine();

            string c = "";
            
            //File.WriteAllText(pathInpFile, c);
            // Console.WriteLine("Please enter new content for the file:");  //Запис вмісту в вх. файл
            // string newContent = Console.ReadLine();

            //while (c is string || Decimal.TryParse(c, out _) || string.IsNullOrEmpty(c))
            
            Repeat:
            
            if(File.Exists(pathInpFile) && File.ReadAllText(pathInpFile) != "")  //Вивід коненту вх. файлу
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
            
            while(!Int32.TryParse(c, out _))  //Поки не буде int , буде змушувати переписати введені дані
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
                //File.WriteAllText(pathInpFile, c);
                
            }
            
            
            //Check of < 4 or > 1032 and retype incorrect
            if (Convert.ToInt32(c) < 4 || Convert.ToInt32(c) > 1032)
            {
                Console.WriteLine("You entered incorrect number, please input number not < 4 and not > 1032  \n");
                c = Console.ReadLine();
                File.WriteAllText(pathInpFile, c);
                goto Repeat;
            }
            
            
            int lenNum = Convert.ToInt32(c);

            Console.WriteLine("Searchable number : " + lenNum);
            
            
            // Console.WriteLine("Search_lenght = " + lenNum + "\n");
            // Console.WriteLine("3 / 2: " + 3/2);

            List<int> lucky_numb = new List<int>();

            lucky_numb.Add(0);
            lucky_numb.Add( 4); 
            lucky_numb.Add( 7);


            int ind = 3;

             while (lucky_numb.Last() <= lenNum)
             {
                 
                 if (ind % 2 != 0) 
                     lucky_numb.Add(lucky_numb[ind/2] * 10 + 4);
                 else
                     lucky_numb.Add(lucky_numb[(ind/2)-1] * 10 +7);
                 ind += 1;
             }
            // for (int i = 3; lucky_numb.Last() <= lenNum; i++)
            // { 
            //     // If i is odd
            //     if (i % 2 != 0) 
            //         lucky_numb.Add(lucky_numb[i/2] * 10 +4);
            //     else
            //         lucky_numb.Add(lucky_numb[(i/2)-1] * 10 +7);
            // }
            
            //Console.WriteLine("Count all lucky numbers = " + (lucky_numb.Count - 2)  + "\n");
            //Console.WriteLine(lucky_numb[3] + " kek " + lucky_numb[4] + " = " + lucky_numb[ind-2]);

            int res = (lucky_numb.Count - 2);
            string result = Convert.ToString(res);
            File.WriteAllText(pathOutFile, result);
            
            if(File.Exists(pathInpFile))  //Вивід коненту вих. файлу
            {
                string contentOut = File.ReadAllText(pathOutFile);
                Console.WriteLine("Current content of output file:");
                Console.WriteLine(contentOut);
            }
        }
    }
}

