using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1124
{
    public class Test1124
    {
        public void Test()
        {
            Interface1124 solution = new Solution1124_2();
            int[] hours;
            int result, answer;
            int id = 0;

            // 1. 
            hours = new int[] { 9, 9, 6, 0, 6, 6, 9 }; answer = 3;
            result = solution.LongestWPI(hours);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            hours = new int[] { 6, 6, 6 }; answer = 0;
            result = solution.LongestWPI(hours);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            hours = new[] { 5, 6, 9, 9, 9, 6, 0, 6, 6, 9 }; answer = 5;
            result = solution.LongestWPI(hours);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            hours = new[] { 9, 9, 0, 0, 0, 9, 9 }; answer = 7;
            result = solution.LongestWPI(hours);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "1124", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            hours = File.ReadAllText(path)[1..^1].Split(',').Select(s => int.Parse(s)).ToArray();
            answer = 737;
            result = solution.LongestWPI(hours);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
