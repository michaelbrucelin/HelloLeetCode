using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1617
{
    public class Test1617
    {
        public void Test()
        {
            Interface1617 solution = new Solution1617();
            int n; int[][] edges;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 4; edges = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 2, 4 } };
            answer = new int[] { 3, 4, 0 };
            result = solution.CountSubgraphsForEachDiameter(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            n = 2; edges = new int[][] { new int[] { 1, 2 } };
            answer = new int[] { 1 };
            result = solution.CountSubgraphsForEachDiameter(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3 . 
            n = 3; edges = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 } };
            answer = new int[] { 2, 1 };
            result = solution.CountSubgraphsForEachDiameter(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4 . 
            n = 5; edges = new int[][] { new int[] { 1, 5 }, new int[] { 2, 3 }, new int[] { 2, 4 }, new int[] { 2, 5 } };
            answer = new int[] { 4, 5, 3, 0 };
            result = solution.CountSubgraphsForEachDiameter(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            n = 7; edges = new int[][] { new int[] { 1, 4 }, new int[] { 1, 3 }, new int[] { 2, 5 }, new int[] { 2, 6 }, new int[] { 3, 6 }, new int[] { 6, 7 } };
            answer = new int[] { 6, 7, 7, 5, 2, 0 };
            result = solution.CountSubgraphsForEachDiameter(n, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
