using System;
using System.Collections.Generic;
using System.Linq;

namespace FindDuplicateNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine($"Duplicate number: {solution.FindDuplicate(new[] { 1, 3, 4, 2, 2 })}");
            Console.Read();
        }
    }

    public class Solution
    {
        public int FindDuplicate(int[] nums)
        {
            var list = new List<int>(nums);
            var duplicateNumber = list.GroupBy(g => g).Where(g => g.Count() > 1).Select(y => y.Key).FirstOrDefault();

            return duplicateNumber;
        }
    }
}
