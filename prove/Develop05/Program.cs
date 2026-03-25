using System;
namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestManager manager = new QuestManager();
            manager.Start();
        }
    }
    public class QuestManager
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;
        public void Start()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine($"\nPoints: {_score}");
                Console.WriteLine("1. Create New Goal\n2. List Goals\n3. Record Event\n4. Save Goals\n5. Load Goals\n6. Quit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": CreateGoal(); break;
                    case "2": ListGoalDetails(); break;
                    case "3": RecordEvent(); break;
                    case "4": SaveGoals(); break;
                    case "5": LoadGoals(); break;
                    case "6": running = false; break;
                }
            }
        }
        public void ListGoalDetails()
        {
            Console.WriteLine("\nYour Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }
        public void CreateGoal()
        {
            Console.WriteLine("1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
            string type = Console.ReadLine();
        
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Description: "); string desc = Console.ReadLine();
            Console.Write("Points: "); int points = int.Parse(Console.ReadLine());

            if (type == "1") _goals.Add(new SimpleGoal(name, desc, points));
            else if (type == "2") _goals.Add(new EternalGoal(name, desc, points));
            else if (type == "3")
            {
                Console.Write("Target completions: "); int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: "); int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
            }
        }
        public void RecordEvent()
        {
            ListGoalDetails();
            Console.Write("Which goal did you accomplish? ");
            int index = int.Parse(Console.ReadLine()) - 1;
            _score += _goals[index].RecordEvent();
        }
        public void SaveGoals()
        {
            using (StreamWriter outputFile = new StreamWriter("goals.txt"))
            {
                outputFile.WriteLine(_score);
                foreach (Goal g in _goals) outputFile.WriteLine(g.GetStringRepresentation());
            }
        }
        public void LoadGoals()
        {
            if (!File.Exists("goals.txt")) return;
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] data = parts[1].Split(',');

                if (type == "SimpleGoal") _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                else if (type == "EternalGoal") _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                else if (type == "ChecklistGoal") _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[5]), int.Parse(data[3])));
            }
        }
    }
}
    
    
    
    