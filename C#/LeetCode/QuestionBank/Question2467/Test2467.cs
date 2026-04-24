using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2467
{
    public class Test2467
    {
        public void Test()
        {
            Interface2467 solution = new Solution2467_2();
            int[][] edges; int bob; int[] amount;
            int result, answer;
            int id = 0;

            // 1. 
            edges = [[0, 1], [1, 2], [1, 3], [3, 4]]; bob = 3; amount = [-2, 4, 2, -4, 6];
            answer = 6;
            result = solution.MostProfitablePath(edges, bob, amount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = [[0, 1]]; bob = 1; amount = [-7280, 2350];
            answer = -7280;
            result = solution.MostProfitablePath(edges, bob, amount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2467", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            amount = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_amount.txt"));
            bob = 3945;
            answer = 98070;
            result = solution.MostProfitablePath(edges, bob, amount);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
