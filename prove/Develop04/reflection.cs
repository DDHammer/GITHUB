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