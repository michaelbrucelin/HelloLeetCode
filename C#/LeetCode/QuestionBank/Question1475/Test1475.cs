using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1475
{
    public class Test1475
    {
        public void Test()
        {
            Interface1475 solution = new Solution1475_3();
            int[] prices;
            int[] result, answer;
            int id = 0;

            // 1. 
            prices = new int[] { 8, 4, 6, 2, 3 }; answer = new int[] { 4, 2, 4, 2, 3 };
            result = solution.FinalPrices(prices);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            prices = new int[] { 1, 2, 3, 4, 5 }; answer = new int[] { 1, 2, 3, 4, 5 };
            result = solution.FinalPrices(prices);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            prices = new int[] { 10, 1, 1, 6 }; answer = new int[] { 9, 0, 1, 6 };
            result = solution.FinalPrices(prices);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            prices = new int[] { 8, 9, 10, 9, 8, 4, 6, 2, 3 }; answer = new int[] { 0, 0, 1, 1, 4, 2, 4, 2, 3 };
            result = solution.FinalPrices(prices);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
