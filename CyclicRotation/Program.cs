using System;
using System.Collections.Generic;

namespace CyclicRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = new Problem();
            problem.Solve(new[] { 1, 2, 3, 4, 5 }, 3);

            // 1, 2, 3, 4, 5 -- original
            // 5, 1, 2, 3, 4 -- first 
            // 4, 5, 1, 2, 3 -- second 
            // 3, 4, 5, 1, 2 -- third

            Console.Read();
        }

        public class Problem
        {
            public void Solve(int[] array, int rotations)
            {
                var targetState = new List<int>(array);

                for (var rotation = 1; rotation <= rotations; rotation++)
                {
                    targetState.Insert(0, targetState[^1]);
                    targetState.RemoveAt(targetState.Count - 1);

                    Console.WriteLine($"For iteration {rotation} output is { string.Join(",", targetState) }");
                }
            }
        }
    }
}
