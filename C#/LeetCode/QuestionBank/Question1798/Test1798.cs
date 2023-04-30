using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1798
{
    public class Test1798
    {
        public void Test()
        {
            Interface1798 solution = new Solution1798();
            int[] coins;
            int result, answer;
            int id = 0;

            // 1. 
            coins = new int[] { 1, 3 }; answer = 2;
            result = solution.GetMaximumConsecutive(coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            coins = new int[] { 1, 1, 1, 4 }; answer = 8;
            result = solution.GetMaximumConsecutive(coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            coins = new int[] { 1, 4, 10, 3, 1 }; answer = 20;
            result = solution.GetMaximumConsecutive(coins);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
