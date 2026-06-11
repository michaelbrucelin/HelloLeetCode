using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3559
{
    public class Test3559
    {
        public void Test()
        {
            Interface3559 solution = new Solution3559_2();
            int[][] edges, queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            edges = [[1, 2]]; queries = [[1, 1], [1, 2]];
            answer = [0, 1];
            result = solution.AssignEdgeWeights(edges, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            edges = [[1, 2], [1, 3], [3, 4], [3, 5]]; queries = [[1, 4], [3, 4], [2, 5]];
            answer = [2, 1, 4];
            result = solution.AssignEdgeWeights(edges, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "3559", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.AssignEdgeWeights(edges, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)[..10]}, answer: {Utils.ToString(answer)[..10]}");

            // 4. 
            testcase = "04";
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            queries = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.AssignEdgeWeights(edges, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)[..10]}, answer: {Utils.ToString(answer)[..10]}");
        }
    }
}
