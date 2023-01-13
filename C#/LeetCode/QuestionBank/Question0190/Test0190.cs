using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0190
{
    public class Test0190
    {
        public void Test()
        {
            Interface0190 solution = new Solution0190_3();
            uint n;
            uint result, answer;
            int id = 0;

            // 1. 
            n = 43261596; answer = 964176192;
            result = solution.reverseBits(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 4294967293; answer = 3221225471;
            result = solution.reverseBits(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
