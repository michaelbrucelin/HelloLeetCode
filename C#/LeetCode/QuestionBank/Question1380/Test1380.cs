using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1380
{
    public class Test1380
    {
        public void Test()
        {
            Interface1380 solution = new Solution1380();
            int[][] matrix;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            matrix = new int[][] { new int[] { 3, 7, 8 }, new int[] { 9, 11, 13 }, new int[] { 15, 16, 17 } };
            answer = new List<int>() { 15 };
            result = solution.LuckyNumbers(matrix);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            matrix = new int[][] { new int[] { 1, 10, 4, 2 }, new int[] { 9, 3, 8, 7 }, new int[] { 15, 16, 17, 12 } };
            answer = new List<int>() { 12 };
            result = solution.LuckyNumbers(matrix);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            matrix = new int[][] { new int[] { 7, 8 }, new int[] { 1, 2 } };
            answer = new List<int>() { 7 };
            result = solution.LuckyNumbers(matrix);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            matrix = new int[][] { new int[] { 3, 6 }, new int[] { 7, 1 }, new int[] { 5, 2 }, new int[] { 4, 8 } };
            answer = new List<int>();
            result = solution.LuckyNumbers(matrix);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
