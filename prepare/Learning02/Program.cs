using System;

public class Job
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) Years/Year:{_startYear} to {_endYear}");
    }
}
public class Resume
{
    public string _name;

    public List<Job> _jobs = new List<Job>();
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "College student";
        job1._company = "BYUI";
        job1._startYear = 2024;
        job1._endYear = 2028;

        Job job2 = new Job();
        job2._jobTitle = "Screen Printer";
        job2._company = "Textile";
        job2._startYear = 2025;
        job2._endYear = 2026;

        Job job3 = new Job();
        job3._jobTitle = "Customer Service";
        job3._company = "Melaeuca";
        job3._startYear = 2024;
        job3._endYear = 2025;

        Resume myResume = new Resume();
        myResume._name = "Deagan Hammer";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume._jobs.Add(job3);
        myResume.Display();
    }
}

