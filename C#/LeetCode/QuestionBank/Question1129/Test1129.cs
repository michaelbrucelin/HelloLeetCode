using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1129
{
    public class Test1129
    {
        public void Test()
        {
            Interface1129 solution = new Solution1129_2();
            int n; int[][] redEdges, blueEdges;
            int[] result, answer;
            int id = 0;

            // 1. 
            n = 3; redEdges = new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 } }; blueEdges = new int[][] { };
            answer = new int[] { 0, 1, -1 };
            result = solution.ShortestAlternatingPaths(n, redEdges, blueEdges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            n = 3; redEdges = new int[][] { new int[] { 0, 1 } }; blueEdges = new int[][] { new int[] { 2, 1 } };
            answer = new int[] { 0, 1, -1 };
            result = solution.ShortestAlternatingPaths(n, redEdges, blueEdges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            n = 3; redEdges = new int[][] { new int[] { 1, 0 } }; blueEdges = new int[][] { new int[] { 2, 1 } };
            answer = new int[] { 0, -1, -1 };
            result = solution.ShortestAlternatingPaths(n, redEdges, blueEdges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            n = 3; redEdges = new int[][] { new int[] { 0, 1 } }; ; blueEdges = new int[][] { new int[] { 1, 2 } }; ;
            answer = new int[] { 0, 1, 2 };
            result = solution.ShortestAlternatingPaths(n, redEdges, blueEdges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            n = 3; redEdges = new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 } }; blueEdges = new int[][] { new int[] { 1, 0 } };
            answer = new int[] { 0, 1, 1 };
            result = solution.ShortestAlternatingPaths(n, redEdges, blueEdges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
