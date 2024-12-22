using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1387
{
    public class Test1387
    {
        public void Test()
        {
            Interface1387 solution = new Solution1387_dial();
            int lo, hi, k;
            int result, answer;
            int id = 0;

            // 1. 
            lo = 12; hi = 15; k = 2;
            answer = 13;
            result = solution.GetKth(lo, hi, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            lo = 7; hi = 11; k = 4;
            answer = 7;
            result = solution.GetKth(lo, hi, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
