using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace hw15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть завдання:");
            Console.WriteLine("1. Переглянути вміст файлу.");
            Console.WriteLine("2. Зберегти масив у файл.");
            Console.WriteLine("3. Завантажити масив із файлу.");
            Console.WriteLine("4. Розділити випадкові числа на парні та непарні.");
            Console.Write("Ваш вибір (1/2/3/4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewFileContent();
                    break;
                case "2":
                    SaveArrayToFile();
                    break;
                case "3":
                    LoadArrayFromFile();
                    break;
                case "4":
                    SplitRandomNumbers();
                    break;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }

        static void ViewFileContent()
        {
            Console.Write("Введіть шлях до файлу: ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine("Вміст файлу:");
                Console.WriteLine(fileContent);
            }
            else
            {
                Console.WriteLine("Файл не існує.");
            }
        }

        static void SaveArrayToFile()
        {
            Console.Write("Введіть ім'я файлу для збереження масиву: ");
            string fileName = Console.ReadLine();

            Console.Write("Введіть значення елементів масиву, розділені пробілом: ");
            string input = Console.ReadLine();
            string[] values = input.Split(' ');

            File.WriteAllLines(fileName, values);

            Console.WriteLine("Масив було збережено у файлі.");
        }

        static void LoadArrayFromFile()
        {
            Console.Write("Введіть ім'я файлу для завантаження масиву: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                string[] values = File.ReadAllLines(fileName);
                Console.WriteLine("Завантажений масив:");
                foreach (string value in values)
                {
                    Console.WriteLine(value);
                }
            }
            else
            {
                Console.WriteLine("Файл не існує.");
            }
        }

        static void SplitRandomNumbers()
        {
            Random random = new Random();

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            for (int i = 0; i < 10000; i++)
            {
                int number = random.Next(1, 10000); 
                if (number % 2 == 0)
                    evenNumbers.Add(number);
                else
                    oddNumbers.Add(number);
            }

            File.WriteAllLines("even_numbers.txt", evenNumbers.Select(n => n.ToString()));
            File.WriteAllLines("odd_numbers.txt", oddNumbers.Select(n => n.ToString()));

            Console.WriteLine("Збережено парні та непарні числа у відповідні файли.");
        }
    }
}