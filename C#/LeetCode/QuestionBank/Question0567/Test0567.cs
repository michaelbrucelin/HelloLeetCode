using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0567
{
    public class Test0567
    {
        public void Test()
        {
            Interface0567 solution = new Solution0567();
            string s1, s2;
            bool result, answer;
            int id = 0;

            // 1. 
            s1 = "ab"; s2 = "eidbaooo";
            answer = true;
            result = solution.CheckInclusion(s1, s2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s1 = "ab"; s2 = "eidboaoo";
            answer = false;
            result = solution.CheckInclusion(s1, s2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s1 = "ab"; s2 = "ba";
            answer = true;
            result = solution.CheckInclusion(s1, s2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
