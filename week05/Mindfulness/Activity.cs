using System;
using System.Threading;

namespace Mindfulness
{
    /// <summary>
    /// Base class for every mindfulness activity. It holds what the
    /// activities share: the name, description, duration, the common starting
    /// and ending messages, and the spinner / countdown animations.
    /// </summary>
    public class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _duration = 0;
        }

        public int GetDuration()
        {
            return _duration;
        }

        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            _duration = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(5);
            Console.WriteLine();
        }

        protected void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
            ShowSpinner(5);
        }

        protected void ShowSpinner(int seconds)
        {
            string[] frames = { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write(frames[i % frames.Length]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;
            }
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}
