using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1334
{
    public class Test1334
    {
        public void Test()
        {
            Interface1334 solution = new Solution1334();
            int n; int[][] edges; int distanceThreshold;
            int result, answer;
            int id = 0;

            // 1. 
            n = 4; edges = Utils.Str2NumArray_2d<int>("[[0,1,3],[1,2,1],[1,3,4],[2,3,1]]"); distanceThreshold = 4;
            answer = 3;
            result = solution.FindTheCity(n, edges, distanceThreshold);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 5; edges = Utils.Str2NumArray_2d<int>("[[0,1,2],[0,4,8],[1,2,3],[1,4,2],[2,3,1],[3,4,1]]"); distanceThreshold = 2;
            answer = 0;
            result = solution.FindTheCity(n, edges, distanceThreshold);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 6; edges = Utils.Str2NumArray_2d<int>("[[0,3,7],[2,4,1],[0,1,5],[2,3,10],[1,3,6],[1,2,1]]"); distanceThreshold = 417;
            answer = 5;
            result = solution.FindTheCity(n, edges, distanceThreshold);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
