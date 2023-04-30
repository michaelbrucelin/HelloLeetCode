using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1615
{
    public class Test1615
    {
        public void Test()
        {
            Interface1615 solution = new Solution1615_3();
            int n; int[][] roads;
            int result, answer;
            int id = 0;

            // 1. 
            n = 4; roads = new int[][] { new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 1, 2 }, new int[] { 1, 3 } };
            answer = 4;
            result = solution.MaximalNetworkRank(n, roads);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 5; roads = new int[][] { new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 2, 4 } };
            answer = 5;
            result = solution.MaximalNetworkRank(n, roads);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 8; roads = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 2, 4 }, new int[] { 5, 6 }, new int[] { 5, 7 } };
            answer = 5;
            result = solution.MaximalNetworkRank(n, roads);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 3; roads = new int[][] { new int[] { 0, 2 }, new int[] { 0, 1 } };
            answer = 2;
            result = solution.MaximalNetworkRank(n, roads);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
