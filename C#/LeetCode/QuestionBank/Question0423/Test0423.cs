using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0423
{
    public class Test0423
    {
        public void Test()
        {
            Interface0423 solution = new Solution0423();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "owoztneoer";
            answer = "012";
            result = solution.OriginalDigits(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "fviefuro";
            answer = "45";
            result = solution.OriginalDigits(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "nnei";
            answer = "9";
            result = solution.OriginalDigits(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
