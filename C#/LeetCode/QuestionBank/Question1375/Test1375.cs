using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1375
{
    public class Test1375
    {
        public void Test()
        {
            Interface1375 solution = new Solution1375_3();
            int[] flips;
            int result, answer;
            int id = 0;

            // 1. 
            flips = new int[] { 3, 2, 4, 1, 5 };
            answer = 2;
            result = solution.NumTimesAllBlue(flips);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            flips = new int[] { 4, 1, 2, 3 };
            answer = 1;
            result = solution.NumTimesAllBlue(flips);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "1375", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            flips = File.ReadAllText(path)[1..^1].Split(',').Select(int.Parse).ToArray();
            answer = 66;
            result = solution.NumTimesAllBlue(flips);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
