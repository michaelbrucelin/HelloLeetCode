using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1157
{
    public class Test1157
    {
        public void Test()
        {
            Interface1157 solution;
            int[] arr;
            int result, answer;
            int id = 0;

            // 1. 
            Console.WriteLine("Test01");
            arr = new int[] { 1, 1, 2, 2, 1, 1 };
            solution = new MajorityChecker(arr);
            answer = 1; result = solution.Query(0, 5, 4); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = -1; result = solution.Query(0, 3, 3); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 2; result = solution.Query(2, 3, 2); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            Console.WriteLine("Test02"); id = 0;
            string question = "1157", testcase = "02";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_arg.txt");
            string[] args = File.ReadAllText(path).Split("],[").Select(s => s.Trim("[]".ToCharArray())).ToArray();
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_answer.txt");
            int[] answers = File.ReadAllText(path)[6..^1].Split(',').Select(s => int.Parse(s)).ToArray();
            solution = new MajorityChecker(args[0].Split(',').Select(s => int.Parse(s)).ToArray());
            int[] _args;
            for (int i = 1; i < args.Length; i++)
            {
                answer = answers[i - 1];
                _args = args[i].Split(',').Select(s => int.Parse(s)).ToArray();
                result = solution.Query(_args[0], _args[1], _args[2]);
                Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            }
            Console.ReadKey();

            // 3. 
            Console.WriteLine("Test03"); id = 0;
            question = "1157"; testcase = "03";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_arg.txt");
            args = File.ReadAllText(path).Split("],[").Select(s => s.Trim("[]".ToCharArray())).ToArray();
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_answer.txt");
            answers = File.ReadAllText(path)[6..^1].Split(',').Select(s => int.Parse(s)).ToArray();
            solution = new MajorityChecker(args[0].Split(',').Select(s => int.Parse(s)).ToArray());
            for (int i = 1; i < args.Length; i++)
            {
                answer = answers[i - 1];
                _args = args[i].Split(',').Select(s => int.Parse(s)).ToArray();
                result = solution.Query(_args[0], _args[1], _args[2]);
                Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            }
            Console.ReadKey();

            // 4. 
            Console.WriteLine("Test04"); id = 0;
            question = "1157"; testcase = "04";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_arg.txt");
            args = File.ReadAllText(path).Split("],[").Select(s => s.Trim("[]".ToCharArray())).ToArray();
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_answer.txt");
            answers = File.ReadAllText(path)[6..^1].Split(',').Select(s => int.Parse(s)).ToArray();
            solution = new MajorityChecker(args[0].Split(',').Select(s => int.Parse(s)).ToArray());
            for (int i = 1; i < args.Length; i++)
            {
                answer = answers[i - 1];
                _args = args[i].Split(',').Select(s => int.Parse(s)).ToArray();
                result = solution.Query(_args[0], _args[1], _args[2]);
                Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            }
            Console.ReadKey();
        }
    }
}
