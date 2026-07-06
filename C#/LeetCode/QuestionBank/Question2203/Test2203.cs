using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2203
{
    public class Test2203
    {
        public void Test()
        {
            Interface2203 solution = new Solution2203();
            int n; int[][] edges; int src1, src2, dest;
            long result, answer;
            int id = 0;

            // 1. 
            n = 6; edges = [[0, 2, 2], [0, 5, 6], [1, 0, 3], [1, 4, 5], [2, 1, 1], [2, 3, 3], [2, 3, 4], [3, 4, 2], [4, 5, 1]]; src1 = 0; src2 = 1; dest = 5;
            answer = 9;
            result = solution.MinimumWeight(n, edges, src1, src2, dest);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; edges = [[0, 1, 1], [2, 1, 1]]; src1 = 0; src2 = 1; dest = 2;
            answer = -1;
            result = solution.MinimumWeight(n, edges, src1, src2, dest);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2203", testcase = "03", arg = "edges";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            n = 100000;
            src1 = 39895; src2 = 74993; dest = 71702;
            answer = 9999900000;
            result = solution.MinimumWeight(n, edges, src1, src2, dest);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
