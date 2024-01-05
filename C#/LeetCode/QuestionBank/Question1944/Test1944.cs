using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1944
{
    public class Test1944
    {
        public void Test()
        {
            Interface1944 solution = new Solution1944_3();
            int[] heights;
            int[] result, answer;
            int id = 0;

            // 1. 
            heights = new int[] { 10, 6, 8, 5, 11, 9 };
            answer = new int[] { 3, 1, 2, 1, 1, 0 };
            result = solution.CanSeePersonsCount(heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            heights = new int[] { 5, 1, 2, 3, 10 };
            answer = new int[] { 4, 1, 1, 1, 0 };
            result = solution.CanSeePersonsCount(heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            heights = new int[] { 32, 7, 21, 47, 2, 12, 19, 17, 5, 51, 48, 50, 3, 16, 4, 45, 27, 43, 49, 37, 10, 24, 42, 11, 18, 44, 28, 46, 15, 29, 23, 20, 36, 8, 33, 14, 22, 38, 9, 1, 40, 13, 6, 26, 30, 35, 34, 41 };
            answer = new int[] { 3, 1, 1, 4, 1, 1, 2, 2, 1, 2, 1, 4, 1, 2, 1, 3, 1, 1, 4, 3, 1, 1, 3, 1, 1, 2, 1, 6, 1, 2, 2, 1, 3, 1, 3, 1, 1, 2, 2, 1, 5, 2, 1, 1, 1, 2, 1, 0 };
            result = solution.CanSeePersonsCount(heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            heights = new int[] { 43, 49, 37, 10, 24, 42, 11, 18, 44, 28, 46, 15, 29, 23, 20, 36, 8, 33, 14, 22, 38, 9, 1, 40, 13, 6, 26, 30, 35, 34, 41 };
            answer = new int[] { 1, 4, 3, 1, 1, 3, 1, 1, 2, 1, 6, 1, 2, 2, 1, 3, 1, 3, 1, 1, 2, 2, 1, 5, 2, 1, 1, 1, 2, 1, 0 };
            result = solution.CanSeePersonsCount(heights);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
