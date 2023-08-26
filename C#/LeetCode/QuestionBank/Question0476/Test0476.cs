using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0476
{
    public class Test0476
    {
        public void Test()
        {
            Interface0476 solution = new Solution0476_2();
            int num;
            int result, answer;
            int id = 0;

            // 1. 
            num = 5; answer = 2;
            result = solution.FindComplement(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = 1; answer = 0;
            result = solution.FindComplement(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = 2147483647; answer = 0;
            result = solution.FindComplement(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
