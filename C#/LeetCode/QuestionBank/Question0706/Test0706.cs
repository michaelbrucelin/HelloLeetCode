using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0706
{
    public class Test0706
    {
        public void Test()
        {
            Interface0706 solution;
            int result, answer;
            int id;

            // 1. 
            Console.WriteLine($"TestCase01"); id = 0;
            solution = new MyHashMap_2();
            solution.Put(1, 1);
            solution.Put(2, 2);
            result = solution.Get(1); answer = 1; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Get(3); answer = -1; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Put(2, 1);
            result = solution.Get(2); answer = 1; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Remove(2);
            result = solution.Get(2); answer = -1; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Remove(2);
            result = solution.Get(2); answer = -1; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            Console.WriteLine($"{Environment.NewLine}TestCase02"); id = 0; id = 0;
            solution = new MyHashMap_2();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question0706\TestCases\");
            string[] opts = File.ReadAllText(Path.Combine(path, "Testcases0706_2_operation.txt"))[1..^1].Split(',').Select(s => s.Trim('"')).Skip(1).ToArray();
            string[] args = File.ReadAllText(Path.Combine(path, "Testcases0706_2_arg.txt"))[1..^1].Split("],[").Select(s => s.Trim('[', ']')).Skip(1).ToArray();
            string[] answers = File.ReadAllText(Path.Combine(path, "Testcases0706_2_answer.txt"))[1..^1].Split(',').Skip(1).ToArray();
            for (int i = 0; i < opts.Length; i++)
            {
                switch (opts[i])
                {
                    case "put":
                        solution.Put(Convert.ToInt32(args[i].Split(',')[0]), Convert.ToInt32(args[i].Split(',')[1]));
                        break;
                    case "get":
                        result = solution.Get(Convert.ToInt32(args[i]));
                        answer = Convert.ToInt32(answers[i]);
                        Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
                        break;
                    case "remove":
                        solution.Remove(Convert.ToInt32(args[i]));
                        break;
                    default:
                        throw new Exception($"\"{opts[i]}\" is a illegal operation.");
                }
            }
        }
    }
}
