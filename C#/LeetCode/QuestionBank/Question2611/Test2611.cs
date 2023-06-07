using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2611
{
    public class Test2611
    {
        public void Test()
        {
            Interface2611 solution = new Solution2611_2();
            int[] reward1, reward2; int k;
            int result, answer;
            int id = 0;

            // 1. 
            reward1 = new int[] { 1, 1, 3, 4 }; reward2 = new int[] { 4, 4, 1, 1 }; k = 2;
            answer = 15;
            result = solution.MiceAndCheese(reward1, reward2, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            reward1 = new int[] { 1, 1 }; reward2 = new int[] { 1, 1 }; k = 2;
            answer = 2;
            result = solution.MiceAndCheese(reward1, reward2, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
