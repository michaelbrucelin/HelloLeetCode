using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2368
{
    public class Test2368
    {
        public void Test()
        {
            Interface2368 solution = new Solution2368_3();
            int n; int[][] edges; int[] restricted;
            int result, answer;
            int id = 0;

            // 1. 
            n = 7; edges = Utils.Str2NumArray_2d<int>("[[0,1],[1,2],[3,1],[4,0],[0,5],[5,6]]"); restricted = new int[] { 4, 5 };
            answer = 4;
            result = solution.ReachableNodes(n, edges, restricted);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 7; edges = Utils.Str2NumArray_2d<int>("[[0,1],[0,2],[0,5],[0,4],[3,2],[6,5]]"); restricted = new int[] { 4, 2, 1 };
            answer = 3;
            result = solution.ReachableNodes(n, edges, restricted);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2368", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            n = 100000; restricted = new int[] { 54982 };
            answer = 99999;
            result = solution.ReachableNodes(n, edges, restricted);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
