using System;
using System.Linq;

namespace PermMissingElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem();
            problem.Solve(new[] { 2, 3, 1, 5 });

            Console.Read();
        }

        public class Problem
        {
            public void Solve(int[] numbers)
            {
                var orderedList = numbers
                    .OrderBy(x => x)
                    .ToList();

                for (var i = 0; i < orderedList.Count() - 1; i++)
                {
                    var expectedNextNumber = orderedList[i] + 1;
                    var actualNext = orderedList[i + 1];

                    if (actualNext != expectedNextNumber)
                    {
                        Console.WriteLine($"Missing number here is {expectedNextNumber}");
                    }
                }
            }
        }
    }
}
