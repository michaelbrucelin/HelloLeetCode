using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1376
{
    public class Test1376
    {
        public void Test()
        {
            Interface1376 solution = new Solution1376_3();
            int n, headID; int[] manager, informTime;
            int result, answer;
            int id = 0;

            // 1. 
            n = 1; headID = 0; manager = new int[] { -1 }; informTime = new int[] { 0 };
            answer = 0;
            result = solution.NumOfMinutes(n, headID, manager, informTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 6; headID = 2; manager = new int[] { 2, 2, -1, 2, 2, 2 }; informTime = new int[] { 0, 0, 1, 0, 0, 0 };
            answer = 1;
            result = solution.NumOfMinutes(n, headID, manager, informTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 15; headID = 0; manager = new int[] { -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 }; informTime = new int[] { 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
            answer = 3;
            result = solution.NumOfMinutes(n, headID, manager, informTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 11; headID = 4; manager = new int[] { 5, 9, 6, 10, -1, 8, 9, 1, 9, 3, 4 }; informTime = new int[] { 0, 213, 0, 253, 686, 170, 975, 0, 261, 309, 337 };
            answer = 2560;
            result = solution.NumOfMinutes(n, headID, manager, informTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 28715; headID = 14539;
            string question = "1376", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_manager.txt");
            manager = File.ReadAllText(path)[1..^1].Split(',').Select(str => int.Parse(str)).ToArray();
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_informTime.txt");
            informTime = File.ReadAllText(path)[1..^1].Split(',').Select(str => int.Parse(str)).ToArray();
            answer = 189521;
            result = solution.NumOfMinutes(n, headID, manager, informTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
