using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1703
{
    public class Test1703
    {
        public void Test()
        {
            Interface1703 solution = new Solution1703();
            int[] nums; int k;
            int result, answer;
            int id = 0;

            // 1.
            nums = new int[] { 1, 0, 0, 1, 0, 1 }; k = 2; answer = 1;
            result = solution.MinMoves(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            nums = new int[] { 1, 0, 0, 0, 0, 0, 1, 1 }; k = 3; answer = 5;
            result = solution.MinMoves(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            nums = new int[] { 1, 1, 0, 1 }; k = 2; answer = 0;
            result = solution.MinMoves(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1703\TestCases\TestCase1703_04.txt");
            string nums_str = File.ReadAllText(path);
            nums = nums_str.Split(',').Select(str => Convert.ToInt32(str)).ToArray();
            k = 25000; answer = 156250000;
            result = solution.MinMoves(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
