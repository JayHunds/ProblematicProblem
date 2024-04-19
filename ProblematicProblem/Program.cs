using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static Random rng = new Random();
    static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

    static void Main(string[] args)
    {
        Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
        var contInput = Console.ReadLine().ToLower();
        bool cont = contInput == "yes";

        Console.WriteLine();
        Console.Write("We are going to need your information first! What is your name? ");
        string userName = Console.ReadLine();
        Console.WriteLine();
        Console.Write("What is your age? ");
        int userAge = int.Parse(Console.ReadLine());
        Console.WriteLine();

        if (userAge < 21)
        {
            activities.Remove("Wine Tasting");
        }

        Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
        bool seeList = Console.ReadLine().ToLower() == "sure";
        if (seeList)
        {
            foreach (string activity in activities)
            {
                Console.Write($"{activity} ");
                Thread.Sleep(250);
            }
            Console.WriteLine();
            Console.Write("Would you like to add any activities before we generate one? yes/no: ");
            bool addToList = Console.ReadLine().ToLower() == "yes";
            Console.WriteLine();
            while (addToList)
            {
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();
                activities.Add(userAddition);
                foreach (string act in activities)
                {
                    Console.Write($" {act} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.WriteLine("Would you like to add more? yes/no: ");
                addToList = Console.ReadLine().ToLower() == "yes";
            }
        }

        while (cont)
        {
            if (userAge >= 21 || activities.Count > 1)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                var randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: \n");
                contInput = Console.ReadLine().ToLower();
                cont = contInput == "keep";
                if (cont)
                {
                    Console.WriteLine("You have chosen to keep your activity.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("There are no activities available.");
                break;
            }
        }
    }
}



