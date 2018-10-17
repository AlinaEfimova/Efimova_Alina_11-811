using System;

namespace GuessNumber
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            int secretNumber = random.Next(0, 100);
            int userNumber;
            Console.WriteLine("Давай поиграем с тобой в игру! Я загадал число от 0 до 100. Попробуй угадать)");
            do
            {
                Console.Write("Введи свое число: ");
                userNumber = int.Parse(Console.ReadLine());
                while (userNumber != secretNumber)
                {
                    if (userNumber > secretNumber)
                        Console.WriteLine("Мое число меньше) Попробуй еще раз!");
                    else
                        Console.WriteLine("Мое число больше) У тебя есть еще попытка!");
                    Console.Write("Введи свое число: ");
                    userNumber = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Молодец! Ты угадал) Сыграем еще раз?");
                Console.WriteLine("Нажми 1, чтобы сыграть еще раз, или 0, чтобы выйти");
            }
            while (Console.ReadKey().KeyChar == '1');
        }
    }
}