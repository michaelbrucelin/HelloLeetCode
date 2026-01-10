using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0712
{
    public class Test0712
    {
        public void Test()
        {
            Interface0712 solution = new Solution0712();
            string s1, s2;
            int result, answer;
            int id = 0;

            // 1. 
            s1 = "sea"; s2 = "eat";
            answer = 231;
            result = solution.MinimumDeleteSum(s1, s2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s1 = "delete"; s2 = "leet";
            answer = 403;
            result = solution.MinimumDeleteSum(s1, s2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
