using System;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
namespace Lab2
{
    class Program
    {
        
    static int countWays(int m, int n)  //Funct for count of ways
        {
     
            // table to store values
            // of subproblems
            int[] count = new int[n + 1];
            count[0] = 0;
     
            // Fill the table upto value n
            int i;
            for (i = 1; i <= n; i++) 
            {
                // int m = 25; // height
                // int n = 50;  // widht
                
                // recurrence relation
                if (i > m)
                    count[i] = count[i - 1] + count[i - m];
     
                // base cases and i = m = 1
                else if (i < m || i == 1)
                    count[i] = 1;
     
                // i = m
                else
                    count[i] = 2;
            }
     
            // number of ways
            return count[n];
        }
    
    
        static void Main(string[] args)
        {
            string pathInpFile = "/Users/mac/CrossProgr/Lab2/Lab2/INPUT.txt"; //Шлях до файлів
            string pathOutFile = "/Users/mac/CrossProgr/Lab2/Lab2/OUTPUT.txt";
            
            List<int> numb = new List<int>(); //List of numbers

            
            //int m = 25; // height
            //int n = 50;  // widht
            //Console.Write("Number of ways = " + countWays(m, n));
            
            //2 ≤ M ≤ N ≤ 50.
            //M (длина плитки и ширина коридора) и N (длина коридора)
            // M - довжина плитки(в бік) і висота коридора(в висоту ), N - довжина коридора(в бік)
            
            
            //Прямоугольный коридор длиной N метров и шириной M метров
            //решили застелить N прямоугольными плитками шириной 1 метр и длиной M метров,
            //таким образом, чтобы не было не застеленной поверхности.
            
            Repeat:
            numb.Clear();
            if(File.Exists(pathInpFile) && File.ReadAllText(pathInpFile) != "")  //Вивід коненту вх. файлу
            {
                string content = File.ReadAllText(pathInpFile);
                Console.WriteLine("Current content of inp file:");
                Console.WriteLine(content);
                
                string[] subs = content.Split(' '); //Розділення на підстроки
                
                
                foreach (var sub in subs)  //Перевірка на тип даних, потрібен int
                {
                    if (Int32.TryParse(sub, out _))
                    {
                        numb.Add(Convert.ToInt32(sub));
                        //Console.WriteLine($"Substring: {sub}");
                    }
                }

                int m = numb[0];
                int n = numb[1];
                
                Console.WriteLine($"m = {m} , n = {n} \n");
                Console.WriteLine($"{m} x {n} using 1 x {m} blocks");
                
                
                //2 ≤ M ≤ N ≤ 50.
                
                if( 2 <= m && m <= n  && n <=50 )
                {
                    Console.Write("Number of ways = " + countWays(m, n));
                    string result = Convert.ToString(countWays(m,n));
                    File.WriteAllText(pathOutFile, result);
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
}