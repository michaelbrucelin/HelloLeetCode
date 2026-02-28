using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0068
{
    public class Test0068
    {
        public void Test()
        {
            Interface0068 solution = new Solution0068();
            int[] flowers; int cnt;
            int result, answer;
            int id = 0;

            // 1. 
            flowers = [1, 2, 3, 2]; cnt = 1;
            answer = 8;
            result = solution.BeautifulBouquet(flowers, cnt);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            flowers = [5, 3, 3, 3]; cnt = 2;
            answer = 8;
            result = solution.BeautifulBouquet(flowers, cnt);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
