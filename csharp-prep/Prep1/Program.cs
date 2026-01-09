using System;
using System.Runtime.ExceptionServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your first name?");
        string First=Console.ReadLine();
        Console.WriteLine("What is your last name?");
        string Last=Console.ReadLine();
        Console.WriteLine($"Your name is {Last}, git{First} {Last}.");
    }
}