using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2559
{
    public class Test2559
    {
        public void Test()
        {
            Interface2559 solution = new Solution2559_api();
            string[] words; int[][] queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            words = new string[] { "aba", "bcb", "ece", "aa", "e" };
            queries = new int[][] { new int[] { 0, 2 }, new int[] { 1, 4 }, new int[] { 1, 1 } };
            answer = new int[] { 2, 3, 0 };
            result = solution.VowelStrings(words, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            words = new string[] { "a", "e", "i" };
            queries = new int[][] { new int[] { 0, 2 }, new int[] { 0, 1 }, new int[] { 2, 2 } };
            answer = new int[] { 3, 2, 1 };
            result = solution.VowelStrings(words, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
