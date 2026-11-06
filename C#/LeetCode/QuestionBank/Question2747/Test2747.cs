using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2747
{
    public class Test2747
    {
        public void Test()
        {
            Interface2747 solution = new Solution2747_2();
            int n; int[][] logs; int x; int[] queries;
            int[] answer, result;
            int id = 0;

            // 1. 
            n = 3; logs = [[1, 3], [2, 6], [1, 5]]; x = 5; queries = [10, 11];
            answer = [1, 2];
            result = solution.CountServers(n, logs, x, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 3; logs = [[2, 4], [2, 1], [1, 2], [3, 1]]; x = 2; queries = [3, 4];
            answer = [0, 1];
            result = solution.CountServers(n, logs, x, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            n = 1; logs = [[1, 195909]]; x = 68754; queries = [448437];
            answer = [1];
            result = solution.CountServers(n, logs, x, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            n = 6; logs = [[1, 21]]; x = 10; queries = [24, 35, 28, 26, 20, 25, 16, 31, 12];
            answer = [5, 6, 5, 5, 6, 5, 6, 5, 6];
            result = solution.CountServers(n, logs, x, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            string question = "2747", testcase = "05", arg_logs = "logs", arg_queries = "queries";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            logs = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg_logs}.txt"));
            queries = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg_queries}.txt"));
            n = 8648; x = 4409;
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.CountServers(n, logs, x, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[..3])}..., answer: {Utils.ToString(answer[..3])}...");

            // 6. 
            testcase = "06";
            logs = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg_logs}.txt"));
            queries = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg_queries}.txt"));
            n = 100000; x = 50000;
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.CountServers(n, logs, x, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[..3])}..., answer: {Utils.ToString(answer[..3])}...");
        }
    }
}
