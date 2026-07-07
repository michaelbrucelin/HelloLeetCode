using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3756
{
    public class Test3756
    {
        public void Test()
        {
            Interface3756 solution = new Solution3756();
            string s; int[][] queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            s = "10203004"; queries = [[0, 7], [1, 3], [4, 6]];
            answer = [12340, 4, 9];
            result = solution.SumAndMultiply(s, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            s = "1000"; queries = [[0, 3], [1, 1]];
            answer = [1, 0];
            result = solution.SumAndMultiply(s, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            s = "9876543210"; queries = [[0, 9]];
            answer = [444444137];
            result = solution.SumAndMultiply(s, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            string question = "3756", testcase = "04", arg_s = "s", arg_q = "queries";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg_s}.txt")[1..^1];
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg_q}.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.SumAndMultiply(s, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[..3])}, answer: {Utils.ToString(answer[..3])}");

            // 5. 
            s = "0"; queries = [[0, 0]];
            answer = [0];
            result = solution.SumAndMultiply(s, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
