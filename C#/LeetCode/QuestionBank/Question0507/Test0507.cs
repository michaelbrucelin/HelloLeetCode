using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0507
{
    public class Test0507
    {
        public void Test()
        {
            Interface0507 solution = new Solution0507();
            int num;
            bool result, answer;
            int id = 0;

            // 1. 
            num = 28; answer = true;
            result = solution.CheckPerfectNumber(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = 7; answer = false;
            result = solution.CheckPerfectNumber(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = 6; answer = true;
            result = solution.CheckPerfectNumber(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
