using System;

namespace TapeEquilibrium
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem();
            problem.Solve(new []{ 3, 1, 2, 4, 3 });

            Console.Read();
        }

        public class Problem
        {
            public void Solve(int[] numbers)
            {
                for (var i = 0; i < numbers.Length - 1; i++)
                {
                    var leftTotal = numbers[i];
                    var rightTotal = CountItForwards(numbers, i + 1);

                    if (i > 0)
                    {
                        leftTotal = CountItBackwards(numbers, i);
                    }

                    var difference = Math.Abs(leftTotal - rightTotal);
                    Console.WriteLine($"Iteration {i + 1}, difference = |{leftTotal} - {rightTotal}| = {difference}");
                }
            }

            private static int CountItForwards(int[] numbers, int startIndex)
            {
                var total = 0;

                for (var i = startIndex; i < numbers.Length; i++)
                    total += numbers[i];

                return total;
            }

            private static int CountItBackwards(int[] numbers, int startIndex)
            {
                var total = 0;

                for (var i = startIndex; i >= 0; i--)
                    total += numbers[i];

                return total;
            }
        }
    }
}
