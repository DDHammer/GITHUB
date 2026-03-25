using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Wilderness Planner!");
            Console.Write("What is your name? ");
            Adventurer user = new Adventurer(Console.ReadLine());

            Console.WriteLine("\nWhere would you like to camp?\n1. Mountain\n2. Lake\n3. Forest");
            Console.Write("Choice (1-3): ");

            string choice = Console.ReadLine();
            Console.Write("Weather (Cold, Sunny, Rainy): ");
            string weather = Console.ReadLine();
            Location myTrip = choice switch
            {
                "1" => new MountainTrip("Mountain Trip (Ideas: Grand tetons, Wind river, Rocky mountains)", weather),
                "2" => new LakeTrip("Lake trip (Ideas:Lake powell, Bear lake, Ririe Resivoir)", weather),
                _ => new ForestTrip("Forest Trip (Idea:Hiese, Island park, Swan Valley)", weather)
            };
            Pack myPack = new Pack();
            EssentialGear essentials = new EssentialGear();
            myPack.AddItems(essentials.GetStandardItems());
            myPack.AddItems(myTrip.GetRequiredGear());
            Console.WriteLine($"\nOkay {user._name}, here is your plan:");
            myPack.DisplayPack();
            myTrip.ShowSafetyTips();
            Console.ReadKey();
        }
    }