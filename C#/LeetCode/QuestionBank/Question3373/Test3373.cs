using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3373
{
    public class Test3373
    {
        public void Test()
        {
            Interface3373 solution = new Solution3373();
            int[][] edges1, edges2;
            int[] result, answer;
            int id = 0;

            // 1. 
            edges1 = [[0, 1], [0, 2], [2, 3], [2, 4]]; edges2 = [[0, 1], [0, 2], [0, 3], [2, 7], [1, 4], [4, 5], [4, 6]];
            answer = [8, 7, 7, 8, 8];
            result = solution.MaxTargetNodes(edges1, edges2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            edges1 = [[0, 1], [0, 2], [0, 3], [0, 4]]; edges2 = [[0, 1], [1, 2], [2, 3]];
            answer = [3, 6, 6, 6, 6];
            result = solution.MaxTargetNodes(edges1, edges2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            edges1 = [[0, 1]]; edges2 = [[0, 1], [1, 2]];
            answer = [3, 3];
            result = solution.MaxTargetNodes(edges1, edges2);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
