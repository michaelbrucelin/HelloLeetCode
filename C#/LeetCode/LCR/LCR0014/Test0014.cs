using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0014
{
    public class Test0014
    {
        public void Test()
        {
            Interface0014 solution = new Solution0014();
            string s1, s2;
            bool result, answer;
            int id = 0;

            // 1 .
            s1 = "ab"; s2 = "eidbaooo";
            answer = true;
            result = solution.CheckInclusion(s1, s2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s1 = "ab"; s2 = "eidboaoo";
            answer = false;
            result = solution.CheckInclusion(s1, s2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
