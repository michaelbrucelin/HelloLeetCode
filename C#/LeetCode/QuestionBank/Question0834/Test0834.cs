using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0834
{
    public class Test0834
    {
        public void Test()
        {
            Interface0834 solution = new Solution0834();
            int n; int[][] edges;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 6; edges = Utils.Str2NumArray_2d<int>("[[0, 1],[0,2],[2,3],[2,4],[2,5]]");
            answer = new int[] { 8, 12, 6, 10, 10, 10 };
            result = solution.SumOfDistancesInTree(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 1; edges = new int[0][];
            answer = new int[] { 0 };
            result = solution.SumOfDistancesInTree(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            n = 2; edges = new int[][] { new int[] { 1, 0 } };
            answer = new int[] { 1, 1 };
            result = solution.SumOfDistancesInTree(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
