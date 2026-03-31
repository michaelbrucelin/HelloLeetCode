using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3603
{
    public class Test3603
    {
        public void Test()
        {
            Interface3603 solution = new Solution3603();
            int m, n; int[][] waitCost;
            long result, answer;
            int id = 0;

            // 1. 
            m = 1; n = 2; waitCost = [[1, 2]];
            answer = 3;
            result = solution.MinCost(m, n, waitCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            m = 2; n = 2; waitCost = [[3, 5], [2, 4]];
            answer = 9;
            result = solution.MinCost(m, n, waitCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            m = 2; n = 3; waitCost = [[6, 1, 4], [3, 2, 5]];
            answer = 16;
            result = solution.MinCost(m, n, waitCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "3603", testcase = "04", arg = "waitCost";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            waitCost = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            m = 1; n = 100000;
            answer = 14999850000;
            result = solution.MinCost(m, n, waitCost);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
