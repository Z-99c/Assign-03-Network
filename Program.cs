/*
* FILE : Program.cs
* PROJECT : PROG2126 - Assignment #3
* PROGRAMMER : Eric Moutoux, Will Jessel, Zemmat Hagos
* FIRST VERSION : 2026-3-17
* DESCRIPTION :
* this will be used to test and mesure performances
*/
using System.Diagnostics;
using System;
using System.Threading;

namespace A03_Q1
{
    internal class Program
    {
        // used constant variables 
        private const int kTheNumberTen = 10;
        private const int kTheNumberThirty = 30;
        private const int kTheNumberOne = 1;
        private const int kTheNumberTwo = 2;
        private const int kTheNumberThree = 3;
        private static readonly object locker = new object(); // made a locker to ensure threads of the performance is safe

        static void Main(string[] args)
        {
            // made a loop to run 5 times
            for (int iterator = 0; iterator <= 4; iterator++)
            {
                // used floats for accurate performances
                float initialTime = InitialCode();
                float betterTime = BetterCode();

                PercentCalculator(initialTime, betterTime); // call the percentcalculator to compare them two times and to display the difference
            }

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();

            return;
        }

        /// <summary>
        /// the initalcode given by us to measure the performance instead we use floats
        /// </summary>
        static float InitialCode()
        {
            // You may add code in this method for purposes of 
            Stopwatch sw = Stopwatch.StartNew();

            int temp = 0;

            Random rand = new Random();

            int LOOPCOUNT = 10000;

            for (int counter = 0; counter < LOOPCOUNT; counter++)
            {
                float randomFloat = rand.NextSingle();
                if (randomFloat < .10)
                {
                    temp = 1;
                }
                if (randomFloat >= .10 && randomFloat < .30)
                {
                    temp = 2;
                }
                if (randomFloat >= .3)
                {
                    temp = 3;
                }
            }

            sw.Stop();

            float elapsedMs = (float)sw.Elapsed.TotalMilliseconds;  // use a typecast to convert value to float

            Console.WriteLine($"InitialCode Execution Time: {elapsedMs} ms");

            return elapsedMs;
        }

        /// <summary>
        /// this is the method provide our way to measure performances better
        /// </summary>
        static float BetterCode()
        {
            // Rewrite the code from initial code here, with
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int checkTemp = 0;  //set the variable to be timed

            int loopCount = 10000;   // set the loop count

            Random rand = new Random();

            // used task to a background thread
            Task loopRunner = Task.Run(() =>
            {
                for (int counter = 0; counter < loopCount; counter++)
                {
                    int randomFloat = (int)(kTheNumberTen * rand.NextSingle());

                    if (randomFloat < kTheNumberTen)
                    {
                        lock (locker)
                        {
                            checkTemp = kTheNumberOne;
                        }
                    }
                    else if (randomFloat < kTheNumberThirty)
                    {
                        lock (locker)
                        {
                            checkTemp = kTheNumberTwo;
                        }
                    }
                    else
                    {
                        lock (locker)
                        {
                            checkTemp = kTheNumberThree;
                        }
                    }
                }
            });

            stopwatch.Stop();

            float elapsedMs = (float)stopwatch.Elapsed.TotalMilliseconds; // use a typecast to convert value to float 

            Console.WriteLine($"BetterCode Execution Time: {elapsedMs} ms");

            return elapsedMs;

        }


        /// <summary>
        /// Calculates and displays the time difference and percent change between the two methods
        /// </summary>
        /// <param name="initialTime">time of the original code in ms</param>
        /// <param name="betterTime">time of the improved code in ms</param>
        private static void PercentCalculator(float initialTime, float betterTime)
        {
            float checkDifference = initialTime - betterTime; // subtract them to calculate the difference
            Console.WriteLine($"Difference: {checkDifference} ms");

            float percentChange = (((betterTime - initialTime) / initialTime) * 100) * -1;
            Console.WriteLine("Percent Change: " + percentChange.ToString());
            Console.WriteLine("______________________");
        }
    }
}
