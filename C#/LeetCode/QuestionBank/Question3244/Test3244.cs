using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3244
{
    public class Test3244
    {
        public void Test()
        {
            Interface3244 solution = new Solution3244();
            int n; int[][] queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 5; queries = [[2, 4], [0, 2], [0, 4]];
            answer = [3, 2, 1];
            result = solution.ShortestDistanceAfterQueries(n, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 4; queries = [[0, 3], [0, 2]];
            answer = [1, 1];
            result = solution.ShortestDistanceAfterQueries(n, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "3244", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            n = 100000;
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.ShortestDistanceAfterQueries(n, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
