using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.start();
            Console.ReadKey();
        }
        public void start()
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
                catch (Exception ex)
                {
                    Console.WriteLine("Введено некорректное значение: " + ex.Message);
                }
            }
            App[] apps = new App[n];
            fillApps(apps);
            Console.WriteLine("Массив до сортировки:");
            foreach(App item in apps)
                Console.WriteLine(item.ToString());
            sortApps(apps);
            Console.WriteLine("Массив после сортировки:");
            foreach (App item in apps)
                Console.WriteLine(item.ToString());
            saveInFile(apps);
        }
        public void fillApps(App[] apps)
        {
            for(int i = 0; i < apps.Length; i++)
            {
                apps[i] = new App();
                Console.Write($"Введите наименование программы {i+1}: ");
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
                Console.Write($"Введите производителя программы {i + 1}: ");
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
                Console.Write($"Введите цену программы {i + 1}: ");
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
        public bool compareApps(App a, App b)
        {
            for(int i = 0; i < (a.Producer.Length < b.Producer.Length?a.Producer.Length:b.Producer.Length); i++)
            {
                if (a.Producer.ToCharArray()[i] > b.Producer.ToCharArray()[i]) return true;
                if (a.Producer.ToCharArray()[i] < b.Producer.ToCharArray()[i]) return false;
            }
            if (a.Price > b.Price) return true;
            else return false;
        }
        public void sortApps(App[] apps)
        {
            for(int i = 0; i < apps.Length - 1; i++)
            {
                for(int j = i; j < apps.Length - 1; j++)
                {
                    if (!compareApps(apps[i], apps[j + 1]))
                    {
                        App tmp = apps[i];
                        apps[i] = apps[j + 1];
                        apps[j + 1] = tmp;
                    }
                }
            }
        }
        public void saveInFile(App[] apps)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("apps.txt"))
                {
                    foreach (App item in apps)
                        sw.WriteLine(item.ToString());
                }
                Console.WriteLine("Успешное сохранение");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Во время сохранения произошла ошибка: " + ex.Message);
            }
        }
    }
}
