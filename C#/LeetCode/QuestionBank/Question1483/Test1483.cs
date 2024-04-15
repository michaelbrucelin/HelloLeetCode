using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Solution1483_N = LeetCode.QuestionBank.Question1483.TreeAncestor_4;

namespace LeetCode.QuestionBank.Question1483
{
    public class Test1483
    {
        public void Test()
        {
            Interface1483 solution;
            int n; int[] parent;
            int result, answer;
            int id = 0, id2;

            // 1. 
            id++; id2 = 0; n = 7; parent = new int[] { -1, 0, 0, 1, 1, 2, 2 };
            solution = new Solution1483_N(n, parent);
            answer = 1; result = solution.GetKthAncestor(3, 1);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 0; result = solution.GetKthAncestor(5, 2);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = -1; result = solution.GetKthAncestor(6, 3);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            id++; id2 = 0; n = 5; parent = new int[] { -1, 0, 0, 2, 1 };
            solution = new Solution1483_N(n, parent);
            answer = -1; result = solution.GetKthAncestor(3, 5);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = -1; result = solution.GetKthAncestor(2, 3);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = -1; result = solution.GetKthAncestor(1, 2);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = -1; result = solution.GetKthAncestor(1, 5);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = -1; result = solution.GetKthAncestor(1, 5);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            id++; id2 = 0; n = 4; parent = new int[] { -1, 2, 3, 0 };
            solution = new Solution1483_N(n, parent);
            answer = -1; result = solution.GetKthAncestor(2, 3);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 0; result = solution.GetKthAncestor(2, 2);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 3; result = solution.GetKthAncestor(2, 1);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            id++; id2 = 0; n = 2; parent = new int[] { -1, 0 };
            solution = new Solution1483_N(n, parent);
            answer = -1; result = solution.GetKthAncestor(1, 2);
            Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            id++; id2 = 0; string question = "1483", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path_args = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_args.txt");
            string[] raw = File.ReadAllText(path_args)[2..^2].Split("],[");
            n = int.Parse(raw[0].Split(",[")[0]);
            parent = raw[0].Replace("[", "").Replace("]", "").Split(',')[1..].Select(int.Parse).ToArray();
            solution = new Solution1483_N(n, parent);
            string path_answer = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_answer.txt");
            int[] answers = File.ReadAllText(path_answer)[6..^1].Split(',').Select(int.Parse).ToArray();
            for (int i = 1; i < raw.Length; i++)
            {
                answer = answers[i - 1];
                result = solution.GetKthAncestor(int.Parse(raw[i].Split(',')[0]), int.Parse(raw[i].Split(',')[1]));
                // Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
                ++id2;
                if (result != answer)
                {
                    Console.WriteLine($"{$"{id}.{id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
                    goto END5;
                }
            }
            Console.WriteLine($"{id} is true.");
            END5:;

            // 6. 
            id++; id2 = 0; testcase = "06";
            path_args = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_args.txt");
            raw = File.ReadAllText(path_args)[2..^2].Split("],[");
            n = int.Parse(raw[0].Split(",[")[0]);
            parent = raw[0].Replace("[", "").Replace("]", "").Split(',')[1..].Select(int.Parse).ToArray();
            solution = new Solution1483_N(n, parent);
            path_answer = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}_answer.txt");
            answers = File.ReadAllText(path_answer)[6..^1].Split(',').Select(int.Parse).ToArray();
            for (int i = 1; i < raw.Length; i++)
            {
                answer = answers[i - 1];
                result = solution.GetKthAncestor(int.Parse(raw[i].Split(',')[0]), int.Parse(raw[i].Split(',')[1]));
                // Console.WriteLine($"{$"{id}.{++id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
                ++id2;
                if (result != answer)
                {
                    Console.WriteLine($"{$"{id}.{id2}",4}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
                    goto END6;
                }
            }
            Console.WriteLine($"{id} is true.");
            END6:;
        }
    }
}
