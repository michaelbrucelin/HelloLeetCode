using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1377
{
    public class Test1377
    {
        public void Test()
        {
            Interface1377 solution = new Solution1377_2();
            int n; int[][] edges; int t; int target;
            double result, answer;
            int id = 0;

            // 1. 
            n = 7; edges = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } };
            t = 2; target = 4;
            answer = 0.16666666666666666;
            result = solution.FrogPosition(n, edges, t, target);
            Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 7; edges = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } };
            t = 1; target = 7;
            answer = 0.3333333333333333;
            result = solution.FrogPosition(n, edges, t, target);
            Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 7; edges = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } };
            t = 2; target = 2;
            answer = 0.0000000000000000;
            result = solution.FrogPosition(n, edges, t, target);
            Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 7; edges = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 1, 7 }, new int[] { 2, 4 }, new int[] { 2, 6 }, new int[] { 3, 5 } };
            t = 20; target = 6;
            answer = 0.16666666666666666;
            result = solution.FrogPosition(n, edges, t, target);
            Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 1; edges = new int[][] { }; t = 1; target = 1;
            answer = 1.0000000000000000;
            result = solution.FrogPosition(n, edges, t, target);
            Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            n = 4; edges = new int[][] { new int[] { 2, 1 }, new int[] { 3, 2 }, new int[] { 4, 1 } };
            t = 4; target = 1;
            answer = 0.0000000000000000;
            result = solution.FrogPosition(n, edges, t, target);
            Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
