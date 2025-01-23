using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2920
{
    public class Test2920
    {
        public void Test()
        {
            Interface2920 solution = new Solution2920_4();
            int[][] edges; int[] coins; int k;
            int result, answer;
            int id = 0;

            // 1. 
            edges = [[0, 1], [1, 2], [2, 3]]; coins = [10, 10, 3, 3]; k = 5;
            answer = 11;
            result = solution.MaximumPoints(edges, coins, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = [[0, 1], [0, 2]]; coins = [8, 4, 4]; k = 0;
            answer = 16;
            result = solution.MaximumPoints(edges, coins, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2920", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            coins = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_coins.txt"));
            k = 10000;
            answer = 9995;
            result = solution.MaximumPoints(edges, coins, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
