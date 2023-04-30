using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1886
{
    public class Test1886
    {
        public void Test()
        {
            Interface1886 solution = new Solution1886_3();
            int[][] mat; int[][] target;
            bool result, answer;
            int id = 0;

            // 1. 
            mat = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } }; target = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            answer = true;
            result = solution.FindRotation(mat, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            mat = new int[][] { new int[] { 0, 1 }, new int[] { 1, 1 } }; target = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } };
            answer = false;
            result = solution.FindRotation(mat, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            mat = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 1, 1, 1 } };
            target = new int[][] { new int[] { 1, 1, 1 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 } };
            answer = true;
            result = solution.FindRotation(mat, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
