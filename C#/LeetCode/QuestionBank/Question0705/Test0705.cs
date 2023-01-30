using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0705
{
    public class Test0705
    {
        public void Test()
        {
            Interface0705 solution;
            bool? result, answer;
            int id;

            // 1. 
            Console.WriteLine($"TestCase01"); id = 0;
            solution = new MyHashSet_2();
            solution.Add(1);
            solution.Add(2);
            result = solution.Contains(1); answer = true; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Contains(3); answer = false; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Add(2);
            result = solution.Contains(2); answer = true; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Remove(2);
            result = solution.Contains(2); answer = false; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Remove(2);
            result = solution.Contains(2); answer = false; Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            Console.WriteLine($"{Environment.NewLine}TestCase02"); id = 0; id = 0;
            solution = new MyHashSet_2();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question0705\TestCases\");
            string[] opts = File.ReadAllText(Path.Combine(path, "Testcases0705_2_operation.txt"))[1..^1].Split(',').Select(s => s.Trim('"')).Skip(1).ToArray();
            string[] args = File.ReadAllText(Path.Combine(path, "Testcases0705_2_arg.txt"))[1..^1].Split(',').Select(s => s.Trim('[', ']')).Skip(1).ToArray();
            string[] answers = File.ReadAllText(Path.Combine(path, "Testcases0705_2_answer.txt"))[1..^1].Split(',').Skip(1).ToArray();
            for (int i = 0; i < opts.Length; i++)
            {
                switch (opts[i])
                {
                    case "add":
                        solution.Add(Convert.ToInt32(args[i]));
                        break;
                    case "contains":
                        result = solution.Contains(Convert.ToInt32(args[i]));
                        answer = answers[i] switch { "true" => true, "false" => false, _ => null };
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
