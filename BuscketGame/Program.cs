using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscketGame
{
    class Program
    {
        public static IPlayers[] alllist = new IPlayers[]
        {
            new HardPlayer() { Name = "Hard player", ID = 1},
            new Player() { Name = "Simple player", ID = 2},
            new SmartPlayer() { Name="Simple smart player", ID = 3},
            new HardCheater() { Name = "Hard cheater", ID = 4},
            new Cheater() { Name = "Cheater", ID = 5}
        };

        static void Main(string[] args)
        {
            int minValue = 0;
            int maxValue = 0;
            int GuessNumber = 0;

            while (true)
            {
                Console.Write("Enter min number: ");
                minValue = Convert.ToInt32(Console.ReadLine());

                if (minValue < 0)
                {
                    Console.WriteLine("Min value must be 0 or higher. Try again.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Enter max number: ");
                maxValue = Convert.ToInt32(Console.ReadLine());

                if (maxValue <= minValue)
                {
                    Console.WriteLine("Max value must be higher than min value. Try again.");
                    continue;
                }
                break;
            }

            while (true)
            {
                Console.Write("Enter right number: ");
                GuessNumber = Convert.ToInt32(Console.ReadLine());

                if (GuessNumber < minValue || GuessNumber > maxValue)
                {
                    Console.WriteLine("Guess number must be between min and max values.");
                    continue;
                }
                break;
            }

            // steps for players
            int first = 0;
            int second = 0;
            Random rnd = new Random(); // for second and fifth
            int third = 0;
            int thirdnum = 0; // for third
            int[] thirdmass = new int[maxValue]; // mass for third player
            int fourth = 0;
            int fifth = 0;


            // Дважды выводит Console.WriteLine($"He thought that this numbers is: {first}.");
            // в чём ошибка не знаю.
            while (true)
            {
                for (int i = 0; i < alllist.Count(); i++)
                {
                    if (alllist[i].ID == 1)
                    {
                        Console.WriteLine($"{alllist[i].Name} walks.");
                        first = minValue++;
                        if (first == GuessNumber)
                        {
                            Console.WriteLine($"{alllist[i].Name} won.");
                            Console.WriteLine($"The number - {GuessNumber}.");
                            Console.ReadLine();
                            return;
                        }
                        Console.WriteLine($"He thought that this numbers is: {first}.");
                    }
                    if (alllist[i].ID == 2)
                    {
                        Console.WriteLine($"{alllist[i].Name} walks.");
                        second = rnd.Next(minValue, maxValue);
                        if (second == GuessNumber)
                        {
                            Console.WriteLine($"{alllist[i].Name} won.");
                            Console.WriteLine($"The number - {GuessNumber}.");
                            Console.ReadLine();
                            return;
                        }
                        Console.WriteLine($"He thought that this numbers is: {second}.");
                    }
                    if (alllist[i].ID == 3)
                    {
                        Console.WriteLine($"{alllist[i].Name} walks.");
                        for (int j = thirdnum; minValue < maxValue; j++)
                        {
                            third = rnd.Next(minValue, maxValue);
                            if (thirdmass.Contains(third))
                                j--;
                            else
                                thirdmass[j] = third;
                            break;
                        }
                        if (third == GuessNumber)
                        {
                            Console.WriteLine($"{alllist[i].Name} won.");
                            Console.WriteLine($"The number - {GuessNumber}.");
                            Console.ReadLine();
                            return;
                        }
                        Console.WriteLine($"He thought that this numbers is: {third}.");
                    }
                    if (alllist[i].ID == 4)
                    {
                        Console.WriteLine($"{alllist[i].Name} walks.");
                        if (first == fourth || second == fourth || third == fourth)
                        {
                            fourth++;
                        }
                    }
                    if (fourth == GuessNumber)
                    {
                        Console.WriteLine($"{alllist[i].Name} won.");
                        Console.WriteLine($"The number - {GuessNumber}.");
                        Console.ReadLine();
                        return;
                    }
                    Console.WriteLine($"He thought that this numbers is: {fourth}.");
                    if (alllist[i].ID == 5)
                    {
                        Console.WriteLine($"{alllist[i].Name} walks.");
                        fifth = rnd.Next(minValue, maxValue);
                        if (first == fifth || second == fifth || third == fifth || fourth == fifth)
                        {
                            fifth++;
                        }
                        if (fifth == GuessNumber)
                        {
                            Console.WriteLine($"{alllist[i].Name} won.");
                            Console.WriteLine($"The number - {GuessNumber}.");
                            Console.ReadLine();
                            return;
                        }
                        Console.WriteLine($"He thought that this numbers is: {fifth}.");
                    }
                }
                Console.WriteLine("Step passed. Press any key to continue.");
                Console.ReadLine();
            }

        }
    }
    interface IPlayers
    {
        string Name { get; set; }
        int ID { get; set; }
    }
    class HardPlayer : IPlayers // trying all numbers
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    class Player : IPlayers // random
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    class SmartPlayer : IPlayers // random + remember his numbers
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    class HardCheater : IPlayers // trying all numbers + remember all numbers of all players
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    class Cheater : IPlayers // random + remembers all numbers of all players
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
