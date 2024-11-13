using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3261
{
    public class Test3261
    {
        public void Test()
        {
            Interface3261 solution = new Solution3261_3();
            string s; int k; int[][] queries;
            long[] result, answer;
            int id = 0;

            // 1. 
            s = "0001111"; k = 2; queries = [[0, 6]];
            answer = [26];
            result = solution.CountKConstraintSubstrings(s, k, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            s = "010101"; k = 1; queries = [[0, 5], [1, 4], [2, 3]];
            answer = [15, 9, 3];
            result = solution.CountKConstraintSubstrings(s, k, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            Stopwatch sw = new Stopwatch();
            string question = "3261", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_s.txt");
            k = 1;
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = Utils.Str2NumArray<long>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            sw.Reset(); sw.Start();
            result = solution.CountKConstraintSubstrings(s, k, queries);
            sw.Stop();
            Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
