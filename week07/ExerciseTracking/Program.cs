using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // One list holds every kind of activity (polymorphism).
            List<Activity> activities = new List<Activity>();

            activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
            activities.Add(new Cycling(new DateTime(2022, 11, 4), 45, 12.0));
            activities.Add(new Swimming(new DateTime(2022, 11, 5), 40, 30));

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
