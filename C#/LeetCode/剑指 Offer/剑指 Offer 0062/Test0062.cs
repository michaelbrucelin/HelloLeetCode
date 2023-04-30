using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0062
{
    public class Test0062
    {
        public void Test()
        {
            Interface0062 solution = new Solution0062_2();
            int n, m;
            int result, answer;
            int id = 0;

            // 1. 
            n = 5; m = 3; answer = 3;
            result = solution.LastRemaining(n, m);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 10; m = 17; answer = 2;
            result = solution.LastRemaining(n, m);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 10000; m = 100000; answer = 8009;
            result = solution.LastRemaining(n, m);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 100000; m = 100000; answer = 66028;
            result = solution.LastRemaining(n, m);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 100000; m = 1000000; answer = 4337;
            result = solution.LastRemaining(n, m);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
