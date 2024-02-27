using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2867
{
    public class Test2867
    {
        public void Test()
        {
            Interface2867 solution = new Solution2867_2();
            int n; int[][] edges;
            long result, answer;
            int id = 0;

            // 1. 
            n = 5; edges = Utils.Str2NumArray_2d<int>("[[1,2],[1,3],[2,4],[2,5]]");
            answer = 4;
            result = solution.CountPaths(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 6; edges = Utils.Str2NumArray_2d<int>("[[1,2],[1,3],[2,4],[3,5],[3,6]]");
            answer = 6;
            result = solution.CountPaths(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1; edges = new int[1][];
            answer = 0;
            result = solution.CountPaths(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 6490;
            string question = "2867", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            answer = 1371755;
            result = solution.CountPaths(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 100000;
            testcase = "05";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            answer = 4086848436;
            result = solution.CountPaths(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
