using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                try
                {
                    Console.Write("Введите количество элементов в массиве: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Введено некорректное значение: " + ex.Message);
                }
            }
            App[] apps = new App[n];
        }
        private void fillApps(App[] apps)
        {
            for(int i = 0; i < apps.Length; i++)
            {
                Console.WriteLine($"Введите наименование программы {i+1}: ");
                string stmp = Console.ReadLine();
                if (!string.IsNullOrEmpty(stmp))
                {
                    apps[i].Name = stmp;
                }
                else
                {
                    Console.WriteLine("Введена пустая строка");
                    i--;
                    continue;
                }
                Console.WriteLine($"Введите производителя программы {i + 1}: ");
                stmp = Console.ReadLine();
                if (!string.IsNullOrEmpty(stmp))
                {
                    apps[i].Producer = stmp;
                }
                else
                {
                    Console.WriteLine("Введена пустая строка");
                    i--;
                    continue;
                }
                Console.WriteLine($"Введите цену программы {i + 1}: ");
                try
                {
                    apps[i].Price = Convert.ToDouble(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Введено некорректное значение: " + ex.Message);
                    i--;
                    continue;
                }
            }
        }
    }
}
