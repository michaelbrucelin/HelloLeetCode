using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0685
{
    public class Test0685
    {
        public void Test()
        {
            Interface0685 solution = new Solution0685();
            int[][] edges;
            int[] result, answer;
            int id = 0;

            // 1. 
            edges = edges = [[1, 2], [1, 3], [2, 3]];
            answer = [2, 3];
            result = solution.FindRedundantDirectedConnection(edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            edges = [[1, 2], [2, 3], [3, 4], [4, 1], [1, 5]];
            answer = [4, 1];
            result = solution.FindRedundantDirectedConnection(edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            edges = [[2, 3], [3, 1], [3, 4], [4, 2]];
            answer = [4, 2];
            result = solution.FindRedundantDirectedConnection(edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
