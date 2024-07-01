using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2065
{
    public class Test2065
    {
        public void Test()
        {
            Interface2065 solution = new Solution2065();
            int[] values; int[][] edges; int maxTime;
            int result, answer;
            int id = 0;

            // 1. 
            values = [0, 32, 10, 43]; edges = [[0, 1, 10], [1, 2, 15], [0, 3, 10]]; maxTime = 49;
            answer = 75;
            result = solution.MaximalPathQuality(values, edges, maxTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            values = [5, 10, 15, 20]; edges = [[0, 1, 10], [1, 2, 10], [0, 3, 10]]; maxTime = 30;
            answer = 25;
            result = solution.MaximalPathQuality(values, edges, maxTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            values = [1, 2, 3, 4]; edges = [[0, 1, 10], [1, 2, 11], [2, 3, 12], [1, 3, 13]]; maxTime = 50;
            answer = 7;
            result = solution.MaximalPathQuality(values, edges, maxTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            values = [0, 1, 2]; edges = [[1, 2, 10]]; maxTime = 10;
            answer = 0;
            result = solution.MaximalPathQuality(values, edges, maxTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "2065", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            values = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_values.txt"));
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            maxTime = 83;
            answer = 1690286;
            result = solution.MaximalPathQuality(values, edges, maxTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            testcase = "06";
            values = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_values.txt"));
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            maxTime = 100;
            answer = 498794167;
            result = solution.MaximalPathQuality(values, edges, maxTime);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
