using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2846
{
    public class Test2846
    {
        public void Test()
        {
            Interface2846 solution = new Solution2846_3();
            int n; int[][] edges, queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 7;
            edges = Utils.Str2NumArray_2d<int>("[[0,1,1],[1,2,1],[2,3,1],[3,4,2],[4,5,2],[5,6,2]]");
            queries = Utils.Str2NumArray_2d<int>("[[0,3],[3,6],[2,6],[0,6]]");
            answer = new int[] { 0, 0, 1, 3 };
            result = solution.MinOperationsQueries(n, edges, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 8;
            edges = Utils.Str2NumArray_2d<int>("[[1,2,6],[1,3,4],[2,4,6],[2,5,3],[3,6,6],[3,0,8],[7,0,2]]");
            queries = Utils.Str2NumArray_2d<int>("[[4,6],[0,4],[6,5],[7,4]]");
            answer = new int[] { 1, 2, 2, 3 };
            result = solution.MinOperationsQueries(n, edges, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            n = 654;
            string question = "2846", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.MinOperationsQueries(n, edges, queries);
            // Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: [ ... ... ], answer: [ ... ... ]");

            // 4. 
            n = 924;
            testcase = "04";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.MinOperationsQueries(n, edges, queries);
            // Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: [ ... ... ], answer: [ ... ... ]");
        }
    }
}
