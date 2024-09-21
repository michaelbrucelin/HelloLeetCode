using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2374
{
    public class Test2374
    {
        public void Test()
        {
            Interface2374 solution = new Solution2374();
            int[] edges;
            int result, answer;
            int id = 0;

            // 1. 
            edges = [1, 0, 0, 0, 0, 7, 7, 5];
            answer = 7;
            result = solution.EdgeScore(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            edges = [2, 0, 0, 2];
            answer = 0;
            result = solution.EdgeScore(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2374", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            answer = 1;
            result = solution.EdgeScore(edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
