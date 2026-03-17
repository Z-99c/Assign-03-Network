// 
// Place your file header comments here
//
using System.Diagnostics;
using System;
using System.Threading;

namespace A03_Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float initialTime = InitialCode();
            float betterTime = BetterCode();
            float checkDifference = initialTime - betterTime; // subtract them to calculate the difference

            Console.WriteLine($"Difference: {checkDifference} ms");


            Console.WriteLine("Press any key to end...");
            Console.ReadKey();

            return;
        }

        /// <summary>
        /// change it to float
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
        /// 
        /// </summary>
        static float BetterCode()
        {
            // Rewrite the code from initial code here, with
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int checkTemp = 0;  //set the variable to be timed

            int loopCount = 10000;   // set the loop count

            Random rand = new Random();

            for (int counter = 0; counter < loopCount; counter++)
            {
                float randomFloat = rand.NextSingle();

                if (randomFloat < 0.10f)
                {
                    checkTemp = 1;
                }

                else if (randomFloat < 0.30f)
                {
                    checkTemp = 2;
                }

                else
                {
                    checkTemp = 3;
                }


            }

            stopwatch.Stop();

            float elapsedMs = (float)stopwatch.Elapsed.TotalMilliseconds; // use a typecast to convert value to float 

            Console.WriteLine($"BetterCode Execution Time: {elapsedMs} ms");

            return elapsedMs;

        }
    }
}
