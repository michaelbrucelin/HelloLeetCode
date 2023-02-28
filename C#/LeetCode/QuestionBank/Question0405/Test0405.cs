using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0405
{
    public class Test0405
    {
        public void Test()
        {
            Interface0405 solution = new Solution0405();
            int num;
            string result, answer;
            int id = 0;

            // 1. 
            num = 26; answer = "1a";
            result = solution.ToHex(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = -1; answer = "ffffffff";
            result = solution.ToHex(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = 655165491; answer = "270d0833";
            result = solution.ToHex(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
