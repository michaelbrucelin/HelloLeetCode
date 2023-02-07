using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0367
{
    public class Test0367
    {
        public void Test()
        {
            Interface0367 solution = new Solution0367();
            int num;
            bool result, answer;
            int id = 0;

            // 1. 
            num = 16; answer = true;
            result = solution.IsPerfectSquare(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = 14; answer = false;
            result = solution.IsPerfectSquare(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = (1 << 30) - 1; answer = false;
            result = solution.IsPerfectSquare(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            num = 1 << 30; answer = true;
            result = solution.IsPerfectSquare(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
