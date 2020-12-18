using System;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem();
            problem.Solve(272);

            //1001 = max 2, count 1
            //100010000 = max 3, gaps 1

            Console.Read();
        }

        public class Problem
        {
            public void Solve(int n)
            {
                var str = Convert.ToString(n, 2).Trim('0'); // convert to binary and remove ending 0s
                var numberOfBinaryGaps = 0; // holds number of gaps
                var currentMaxBinaryGap = 0; // holds max gap thus far
                var currentCount = 0; // count

                foreach (var c in str)
                {
                    switch (c)
                    {
                        case '0':
                            currentCount++; // increment count if its a 0
                            continue;
                        case '1':
                            {
                                // check if current count is biggest number of 0s we have
                                if (currentCount > currentMaxBinaryGap)
                                    currentMaxBinaryGap = currentCount;

                                // only if have counted a 0 before then increment binary gap
                                if (currentCount > 0)
                                    numberOfBinaryGaps++;

                                currentCount = 0;
                                break;
                            }
                    }
                }

                Console.WriteLine($"Number of binary gaps {numberOfBinaryGaps}");
                Console.WriteLine($"Max binary gap is {currentMaxBinaryGap}");
            }
        }
    }
}
