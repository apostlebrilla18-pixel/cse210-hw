using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2026;
        job1._endYear = 2028;

        Job job2 = new Job();
        job2._jobTitle = "Production Engineer";
        job2._company = "CBI";
        job2._startYear = 2023;
        job2._endYear = 2026;

        Resume myResume = new Resume();
        myResume._name = "Akrofi Randy Manasseh";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}