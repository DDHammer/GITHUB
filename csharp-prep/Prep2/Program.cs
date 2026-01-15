using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string percent = Console.ReadLine();
        int percent2 = int.Parse(percent);

        string letter = "";

        if (percent2 >= 90)
        {
            letter = "A";
        }
        else if (percent2 >= 80)
        {
            letter = "B";
        }
        else if (percent2 >= 70)
        {
            letter = "C";
        }
        else if (percent2 >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");
        if (percent2 >= 70)
        {
        Console.WriteLine("You did it, good work.");
        }
        else
        {
        Console.WriteLine("You got it next time.");
        }
    }
};