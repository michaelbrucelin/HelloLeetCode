using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1330
{
    public class Test1330
    {
        public void Test()
        {
            Interface1330 solution = new Solution1330();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 2, 3, 1, 5, 4 }; answer = 10;
            result = solution.MaxValueAfterReverse(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 2, 4, 9, 24, 2, 1, 10 }; answer = 68;
            result = solution.MaxValueAfterReverse(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1 }; answer = 0;
            result = solution.MaxValueAfterReverse(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "1330", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            nums = File.ReadAllText(path)[1..^1].Split(',').Select(str => int.Parse(str)).ToArray();
            answer = 1988832659;
            result = solution.MaxValueAfterReverse(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
