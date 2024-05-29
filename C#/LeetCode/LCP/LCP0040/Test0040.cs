using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0040
{
    public class Test0040
    {
        public void Test()
        {
            Interface0040 solution = new Solution0040();
            int[] cards; int cnt;
            int result, answer;
            int id = 0;

            // 1. 
            cards = [1, 2, 8, 9]; cnt = 3;
            answer = 18;
            result = solution.MaxmiumScore(cards, cnt);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            cards = [3, 3, 1]; cnt = 1;
            answer = 0;
            result = solution.MaxmiumScore(cards, cnt);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
