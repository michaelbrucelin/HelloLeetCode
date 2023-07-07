using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2532
{
    public class Test2532
    {
        public void Test()
        {
            Interface2532 solution = new Solution2532_2();
            int n, k; int[][] time;
            int result, answer;
            int id = 0;

            // 1. 
            n = 1; k = 3; time = new int[][] { new int[] { 1, 1, 2, 1 }, new int[] { 1, 1, 3, 1 }, new int[] { 1, 1, 4, 1 } };
            answer = 6;
            result = solution.FindCrossingTime(n, k, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; k = 2; time = new int[][] { new int[] { 1, 9, 1, 8 }, new int[] { 10, 10, 10, 10 } };
            answer = 50;
            result = solution.FindCrossingTime(n, k, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 10000; k = 114;
            string question = "2532", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            time = File.ReadAllText(path)[2..^2].Split("],[").Select(str => str.Split(',').Select(int.Parse).ToArray()).ToArray();
            answer = 19995000;
            result = solution.FindCrossingTime(n, k, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 10000; k = 156; testcase = "04";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            time = File.ReadAllText(path)[2..^2].Split("],[").Select(str => str.Split(',').Select(int.Parse).ToArray()).ToArray();
            answer = 19995000;
            result = solution.FindCrossingTime(n, k, time);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
