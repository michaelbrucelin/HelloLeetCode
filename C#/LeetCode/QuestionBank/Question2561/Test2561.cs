using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2561
{
    public class Test2561
    {
        public void Test()
        {
            Interface2561 solution = new Solution2561_2();
            int[] basket1, basket2;
            long result, answer;
            int id = 0;

            // 1. 
            basket1 = [4, 2, 2, 2]; basket2 = [1, 4, 1, 2];
            answer = 1;
            result = solution.MinCost(basket1, basket2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            basket1 = [2, 3, 4, 1]; basket2 = [3, 2, 5, 1];
            answer = -1;
            result = solution.MinCost(basket1, basket2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            basket1 = [84, 80, 43, 8, 80, 88, 43, 14, 100, 88]; basket2 = [32, 32, 42, 68, 68, 100, 42, 84, 14, 8];
            answer = 48;
            result = solution.MinCost(basket1, basket2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            basket1 = [183, 259, 304, 201, 128, 68, 289, 346, 257, 259, 300, 167, 167, 289, 33, 304, 382, 21, 183, 252];
            basket2 = [97, 128, 169, 21, 382, 169, 201, 68, 365, 183, 346, 97, 300, 257, 56, 183, 252, 365, 33, 56];
            answer = 168;
            result = solution.MinCost(basket1, basket2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5.
            string question = "2561", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            basket1 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_basket1.txt"));
            basket2 = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_basket2.txt"));
            answer = 99999;
            result = solution.MinCost(basket1, basket2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
