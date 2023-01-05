using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1803
{
    public class Test1803
    {
        public void Test()
        {
            Interface1803 solution = new Solution1803();
            int[] nums; int low, high;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 4, 2, 7 }; low = 2; high = 6; answer = 6;
            result = solution.CountPairs(nums, low, high);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            nums = new int[] { 9, 8, 4, 2, 1 }; low = 5; high = 14; answer = 8;
            result = solution.CountPairs(nums, low, high);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1803\TestCases\TestCase1803_03.txt");
            string numstr = File.ReadAllText(path);
            nums = numstr.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray();
            low = 2130; high = 13537; answer = 83370123;
            result = solution.CountPairs(nums, low, high);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
