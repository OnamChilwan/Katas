using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrencesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem();
            problem.Solve(new [] { 9, 3, 9, 3, 9, 7, 9 });

            Console.Read();
        }

        public class Problem
        {
            public void Solve(int[] numbers)
            {
                var distinctNumbers = new List<int>(numbers).Distinct();
                var targetState = distinctNumbers
                    .Where(i => !IsDivisibleByTwo(i) && IsNumberUnique(numbers, i))
                    .ToList();

                Console.WriteLine($"Distinct odd numbers {string.Join(",", targetState)}");
            }

            private static bool IsNumberUnique(int[] numbers, int i)
            {
                return numbers.Count(x => x == i) == 1;
            }

            private static bool IsDivisibleByTwo(int i)
            {
                return i % 2 == 0;
            }
        }
    }
}
