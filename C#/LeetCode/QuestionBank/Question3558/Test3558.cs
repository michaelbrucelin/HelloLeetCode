using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3558
{
    public class Test3558
    {
        public void Test()
        {
            Interface3558 solution = new Solution3558();
            int[][] edges;
            int result, answer;
            int id = 0;

            // 1. 
            edges = [[1, 2]];
            answer = 1;
            result = solution.AssignEdgeWeights(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = [[1, 2], [1, 3], [3, 4], [3, 5]];
            answer = 2;
            result = solution.AssignEdgeWeights(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            edges = [[1, 2], [2, 3], [3, 4]];
            answer = 4;
            result = solution.AssignEdgeWeights(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "3558", testcase = "04", arg = "edges";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 509082729;
            result = solution.AssignEdgeWeights(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            testcase = "05";
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 151930880;
            result = solution.AssignEdgeWeights(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
