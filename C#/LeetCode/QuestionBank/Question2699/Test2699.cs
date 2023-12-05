using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2699
{
    public class Test2699
    {
        public void Test()
        {
            Interface2699 solution = new Solution2699_err();
            int n; int[][] edges; int source, destination, target;
            int[][] result, answer;
            int id = 0;

            // 1. 
            n = 5; edges = new int[][] { new int[] { 4, 1, -1 }, new int[] { 2, 0, -1 }, new int[] { 0, 3, -1 }, new int[] { 4, 3, -1 } };
            source = 0; destination = 1; target = 5;
            answer = new int[][] { new int[] { 4, 1, 1 }, new int[] { 2, 0, 1 }, new int[] { 0, 3, 3 }, new int[] { 4, 3, 1 } };
            result = solution.ModifiedGraphEdges(n, edges, source, destination, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            n = 3; edges = new int[][] { new int[] { 0, 1, -1 }, new int[] { 0, 2, 5 } };
            source = 0; destination = 2; target = 6;
            answer = new int[0][];
            result = solution.ModifiedGraphEdges(n, edges, source, destination, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            n = 4; edges = new int[][] { new int[] { 1, 0, 4 }, new int[] { 1, 2, 3 }, new int[] { 2, 3, 5 }, new int[] { 0, 3, -1 } };
            source = 0; destination = 2; target = 6;
            answer = new int[][] { new int[] { 1, 0, 4 }, new int[] { 1, 2, 3 }, new int[] { 2, 3, 5 }, new int[] { 0, 3, 1 } };
            result = solution.ModifiedGraphEdges(n, edges, source, destination, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4. 
            n = 5; edges = new int[][] { new int[] { 1, 3, 10 }, new int[] { 4, 2, -1 }, new int[] { 0, 3, 7 }, new int[] { 4, 0, 7 }, new int[] { 3, 2, -1 }, new int[] { 1, 4, 5 }, new int[] { 2, 0, 8 }, new int[] { 1, 0, 3 }, new int[] { 1, 2, 5 } };
            source = 3; destination = 4; target = 11;
            answer = new int[][] { new int[] { 1, 3, 10 }, new int[] { 4, 2, 1 }, new int[] { 0, 3, 7 }, new int[] { 4, 0, 7 }, new int[] { 3, 2, 10 }, new int[] { 1, 4, 5 }, new int[] { 2, 0, 8 }, new int[] { 1, 0, 3 }, new int[] { 1, 2, 5 } };
            result = solution.ModifiedGraphEdges(n, edges, source, destination, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 5. 
            n = 4; edges = new int[][] { new int[] { 0, 1, -1 }, new int[] { 1, 2, -1 }, new int[] { 3, 1, -1 }, new int[] { 3, 0, 2 }, new int[] { 0, 2, 5 } };
            source = 2; destination = 3; target = 8;
            answer = new int[0][];
            result = solution.ModifiedGraphEdges(n, edges, source, destination, target);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}
