using System;

using System;

class Program
{
    static void Main()
    {
        Random randomGenerator = new Random();
        int Number = randomGenerator.Next(1, 101);
        int guess = -1;
        while (guess != Number)
        {
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();
            guess = int.Parse(input);
            if (Number > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (Number < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You got it!");
            }
        }
    }
}