using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1962
{
    public class Test1962
    {
        public void Test()
        {
            Interface1962 solution = new Solution1962();
            int[] piles; int k;
            int result, answer;
            int id = 0;

            // 1. 
            piles = new int[] { 5, 4, 9 }; k = 2;
            answer = 12;
            result = solution.MinStoneSum(piles, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            piles = new int[] { 4, 3, 6, 7 }; k = 3;
            answer = 12;
            result = solution.MinStoneSum(piles, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            piles = new int[] { 1 }; k = 100000;
            answer = 1;
            result = solution.MinStoneSum(piles, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
