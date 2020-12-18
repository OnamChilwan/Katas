using System;

namespace FrogJmp
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem();
            problem.Solve(10, 85, 30);

            Console.Read();
        }

        public class Problem
        {
            public void Solve(int x, int y, int d)
            {
                var iteration = 0;

                Console.WriteLine($"Starting position {x}");
                Console.WriteLine($"End position {y}");

                while (x < y)
                {
                    x += d;
                    iteration++;
                    Console.WriteLine($"After jump {iteration}, at position {x}");
                }

                Console.WriteLine($"Iterations {iteration}");
            }
        }
    }
}
