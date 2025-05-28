using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3372
{
    public class Test3372
    {
        public void Test()
        {
            Interface3372 solution = new Solution3372();
            int[][] edges1, edges2; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            edges1 = [[0, 1], [0, 2], [2, 3], [2, 4]]; edges2 = [[0, 1], [0, 2], [0, 3], [2, 7], [1, 4], [4, 5], [4, 6]]; k = 2;
            answer = [9, 7, 9, 8, 8];
            result = solution.MaxTargetNodes(edges1, edges2, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            edges1 = [[0, 1], [0, 2], [0, 3], [0, 4]]; edges2 = [[0, 1], [1, 2], [2, 3]]; k = 1;
            answer = [6, 3, 3, 3, 3];
            result = solution.MaxTargetNodes(edges1, edges2, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            edges1 = [[0, 1]]; edges2 = [[0, 1]]; k = 0;
            answer = [1, 1];
            result = solution.MaxTargetNodes(edges1, edges2, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
