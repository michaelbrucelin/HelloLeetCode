using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2269
{
    public class Test2269
    {
        public void Test()
        {
            Interface2269 solution = new Solution2269();
            int num, k;
            int result, answer;
            int id = 0;

            // 1. 
            num = 240; k = 2; answer = 2;
            result = solution.DivisorSubstrings(num, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = 430043; k = 2; answer = 2;
            result = solution.DivisorSubstrings(num, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = 10240; k = 2; answer = 3;
            result = solution.DivisorSubstrings(num, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
