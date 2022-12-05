using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1774
{
    public class Test1774
    {
        public void Test()
        {
            Interface1774 solution = new Solution1774_2();
            int[] baseCosts; int[] toppingCosts; int target;
            int result, answer;
            int id = 0;

            // 1.
            baseCosts = new int[] { 1, 7 }; toppingCosts = new int[] { 3, 4 }; target = 10;
            answer = 10; result = solution.ClosestCost(baseCosts, toppingCosts, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            baseCosts = new int[] { 2, 3 }; toppingCosts = new int[] { 4, 5, 100 }; target = 18;
            answer = 17; result = solution.ClosestCost(baseCosts, toppingCosts, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            baseCosts = new int[] { 3, 10 }; toppingCosts = new int[] { 2, 5 }; target = 9;
            answer = 8; result = solution.ClosestCost(baseCosts, toppingCosts, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            baseCosts = new int[] { 10 }; toppingCosts = new int[] { 1 }; target = 1;
            answer = 10; result = solution.ClosestCost(baseCosts, toppingCosts, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
