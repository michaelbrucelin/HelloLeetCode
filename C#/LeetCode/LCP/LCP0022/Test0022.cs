using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0022
{
    public class Test0022
    {
        public void Test()
        {
            Interface0022 solution = new Solution0022();
            int n, k;
            int result, answer;
            int id = 0;

            // 1. 
            n = 2; k = 2;
            answer = 4;
            result = solution.PaintingPlan(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 2; k = 1;
            answer = 0;
            result = solution.PaintingPlan(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 2; k = 4;
            answer = 1;
            result = solution.PaintingPlan(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 3; k = 8;
            answer = 9;
            result = solution.PaintingPlan(n, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
