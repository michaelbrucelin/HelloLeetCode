using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0018
{
    public class Test0018
    {
        public void Test()
        {
            Interface0018 solution = new Solution0018();
            int[] staple, drinks; int x;
            int result, answer;
            int id = 0;

            // 1. 
            staple = [10, 20, 5]; drinks = [5, 5, 2]; x = 15;
            answer = 6;
            result = solution.BreakfastNumber(staple, drinks, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            staple = [2, 1, 1]; drinks = [8, 9, 5, 1]; x = 9;
            answer = 8;
            result = solution.BreakfastNumber(staple, drinks, x);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
