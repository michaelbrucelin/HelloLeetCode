using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1326
{
    public class Test1326
    {
        public void Test()
        {
            Interface1326 solution = new Solution1326();
            int n; int[] ranges;
            int result, answer;
            int id = 0;

            // 1. 
            n = 5; ranges = new int[] { 3, 4, 1, 1, 0, 0 };
            answer = 1;
            result = solution.MinTaps(n, ranges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 5; ranges = new int[] { 3, 3, 1, 1, 0, 0 };
            answer = -1;
            result = solution.MinTaps(n, ranges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 3; ranges = new int[] { 0, 0, 0, 0 };
            answer = -1;
            result = solution.MinTaps(n, ranges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "1326", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            ranges = File.ReadAllText(path)[1..^1].Split(',').Select(i => int.Parse(i)).ToArray();
            n = ranges.Length - 1;
            answer = 55;
            result = solution.MinTaps(n, ranges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            question = "1326"; testcase = "05";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            ranges = File.ReadAllText(path)[1..^1].Split(',').Select(i => int.Parse(i)).ToArray();
            n = ranges.Length - 1;
            answer = 55;
            result = solution.MinTaps(n, ranges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
