using System;
using System.Collections.Generic;

namespace TrekTechPlanner
{
    public abstract class Location
    {
        public string DestinationName { get; set; }
        public string WeatherCondition { get; set; }

        public Location(string name, string weather)
        {
            DestinationName = name;
            WeatherCondition = weather.ToLower();
        }

        public abstract List<GearItem> GetRequiredGear();
        public abstract void ShowSafetyTips();
    }

    public class MountainTrip : Location
    {
        public MountainTrip(string name, string weather) : base(name, weather) { }
        public override List<GearItem> GetRequiredGear()
        {
            var gear = new List<GearItem>();
            gear.Add(new GearItem("Light Windbreaker/Jacket", 1.0));

            if (WeatherCondition.Contains("cold") || WeatherCondition.Contains("snow"))
            {
                gear.Add(new GearItem("Winter Clothes (Snow pants, jacket, boots, gloves)", 6.0));
                gear.Add(new GearItem("Hand warmers, Heater", 0.5));
            }
            return gear;
        }
        public override void ShowSafetyTips() 
        {
            Console.WriteLine("SAFETY: Watch for frostbite or hypothermia!");
            Console.WriteLine("FUN: Bring lots of firewood for a bonfire and some hot chocolate!");
        }
    }
    public class LakeTrip : Location
    {
        public LakeTrip(string name, string weather) : base(name, weather) { }
        public override List<GearItem> GetRequiredGear()
        {
            var gear = new List<GearItem>();
            gear.Add(new GearItem("Fishing Pole and Tackle", 3.5));

            if (WeatherCondition.Contains("sunny")) gear.Add(new GearItem("Sun Screen", 0.5));
            else gear.Add(new GearItem("A Hoodie", 1.5));
            return gear;
        }
        public override void ShowSafetyTips()
        {
            Console.WriteLine("SAFETY: Make sure you wear a Life Jacket!");
            Console.WriteLine("FUN: Try to catch some fish with your gear!");
        }
    }
    public class ForestTrip : Location
    {
        public ForestTrip(string name, string weather) : base(name, weather) { }
        public override List<GearItem> GetRequiredGear()
        {
            var gear = new List<GearItem>();
            gear.Add(new GearItem("High-power Flashlight", 1.0));
            gear.Add(new GearItem("Protection (Gun/Bear Spray)", 4.0));

            if (WeatherCondition.Contains("rain")) 
            gear.Add(new GearItem("Waterproof Tarp, Rain gear", 4.0));
            return gear;
        }
        public override void ShowSafetyTips()
        {
            Console.WriteLine("SAFETY: Store food in bear canisters!");
        Console.WriteLine("FUN: You could bring hammocks to set up in the trees!");
        }
    }
    public class EssentialGear
    {
        public List<GearItem> GetStandardItems()
        {
            return new List<GearItem>
            {
                new GearItem("Food ", 5.0),
                new GearItem("Water (2L)", 4.4),
                new GearItem("Camping Tent", 6.0),
                new GearItem("Lighter/Matches", 0.1),
                new GearItem("Sleeping Bag", 3.0),
                new GearItem("Extra Clothes", 2.5),
                new GearItem("Flashlight", 0.5),
                new GearItem("Hiking Shoes", 2.0),
                new GearItem("Pocket Knife", 0.3),
                new GearItem("First Aid Kit", 1.2),
                new GearItem("Power Bank", 0.8)
            };
        }
    }
    public class GearItem
    {
        public string ItemName { get; private set; }
        public double Weight { get; private set; }
        public GearItem(string name, double weight) { ItemName = name; Weight = weight; }
    }
    public class Pack
    {
        private List<GearItem> _items = new List<GearItem>();
        public void AddItems(List<GearItem> items) => _items.AddRange(items);
        public void DisplayPack()
        {
            double totalWeight = 0;
            Console.WriteLine("\n--- YOUR PACKING LIST ---");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item.ItemName} ({item.Weight} lbs)");
                totalWeight += item.Weight;
            }
            Console.WriteLine($"TOTAL WEIGHT: {totalWeight:F1} lbs");
        }
    }
    public class Adventurer
    {
        public string Name { get; set; }
        public Adventurer(string name) => Name = name;
    }
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
            Console.WriteLine($"\nOkay {user.Name}, here is your plan:");
            myPack.DisplayPack();
            myTrip.ShowSafetyTips();
            Console.ReadKey();
        }
    }
}