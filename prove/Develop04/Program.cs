using System;
    public abstract class Activity
    {
        private string _name;
        private string _description;
        protected int _duration;
        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.\n");
            Console.WriteLine($"{_description}\n");
            Console.Write("How long, in seconds, would you like for your session? ");
            if (!int.TryParse(Console.ReadLine(), out _duration))
            {
                _duration = 20;
            Console.WriteLine("\nGet ready...");
            ShowSpinner(3);
            }
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("\nWell done!!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(3);
        }

        public void ShowSpinner(int seconds)
        {
            List<string> animationChars = new List<string> { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < endTime)
            {
                string s = animationChars[i % animationChars.Count];
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;
            }
            Console.WriteLine();
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
        public abstract void Run();
    }
    // Breathing Activity 
    public class BreathingActivity : Activity
    {
                public BreathingActivity() : base("Breathing Activity", 
            "This activity will help you relax by helping you breathing in and out slowly. Clear your mind and focus on your breathing.") 
        {}

        public override void Run()
        {
            DisplayStartingMessage();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in...");
                ShowCountDown(5);
                Console.Write("Now breathe out...");
                ShowCountDown(5);
                Console.WriteLine();
            }
            DisplayEndingMessage();
        }
    }
    // Reflection Activity 
    public class ReflectingActivity : Activity
    {
        private List<string> prompts = new List<string> {
            "Think of a time when you helped someone.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you served others.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new List<string> {
            "Why was this experience sticking out to you?",
            "Have you ever done anything like this before?",
            "How did you feel when it was complete?",
            "What did you learn about yourself through this experience?"
        };

        public ReflectingActivity() : base("Reflection Activity", 
            "This activity will help you reflect on times in your life when you have shown kindness.") 
        {}

        public override void Run()
        {
            DisplayStartingMessage();
            Random rand = new Random();

            Console.WriteLine("\nConsider the following prompt:");
            Console.WriteLine($" --- {prompts[rand.Next(prompts.Count)]} ---");
            Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(5);

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                Console.Write($"- {questions[rand.Next(questions.Count)]} ");
                ShowSpinner(7);
            }
            DisplayEndingMessage();
        }
    }
    // Listing Activity 
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string> {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity", 
            "This activity will help you reflect on the good things in your life by listing as many things as you can.") 
        {}
        public override void Run()
        {
            DisplayStartingMessage();
            Random rand = new Random();
            Console.WriteLine("\nList as many items as you can for the following prompt:");
            Console.WriteLine($" --- {_prompts[rand.Next(_prompts.Count)]} ---");
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            int count = 0;
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                Console.ReadLine();
                count++;
            }

            Console.WriteLine($"List complete! You listed {count} items.");
            DisplayEndingMessage();
        }
    }
    // Program
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Start breathing activity");
                Console.WriteLine("  2. Start reflecting activity");
                Console.WriteLine("  3. Start listing activity");
                Console.WriteLine("  4. Quit");
                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();
                Activity activity = null;
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectingActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        running = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Thread.Sleep(1000);
                        continue;
                }

                activity.Run();
            }
        }
    }