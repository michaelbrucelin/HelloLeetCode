using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2316
{
    public class Test2316
    {
        public void Test()
        {
            Interface2316 solution = new Solution2316_2();
            int n; int[][] edges;
            long result, answer;
            int id = 0;

            // 1. 
            n = 3; edges = Utils.Str2NumArray_2d<int>("[[0,1],[0,2],[1,2]]");
            answer = 0;
            result = solution.CountPairs(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 7; edges = Utils.Str2NumArray_2d<int>("[[0,2],[0,5],[2,4],[1,6],[5,4]]");
            answer = 14;
            result = solution.CountPairs(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 16; edges = Utils.Str2NumArray_2d<int>("[[0,15],[1,14],[2,11],[4,3],[5,15],[8,2],[14,12]]");
            answer = 110;
            result = solution.CountPairs(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 4; edges = Utils.Str2NumArray_2d<int>("[[3,2],[1,2],[3,0]]");
            answer = 0;
            result = solution.CountPairs(n, edges);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
