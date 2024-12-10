using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0935
{
    public class Test0935
    {
        public void Test()
        {
            Interface0935 solution = new Solution0935_2();
            int n;
            int result, answer;
            int id = 0;

            // 1. 
            n = 1;
            answer = 10;
            result = solution.KnightDialer(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 2;
            answer = 20;
            result = solution.KnightDialer(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 3;
            answer = 46;
            result = solution.KnightDialer(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            n = 4;
            answer = 104;
            result = solution.KnightDialer(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            n = 5;
            answer = 240;
            result = solution.KnightDialer(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6.
            n = 3131;
            answer = 136006598;
            result = solution.KnightDialer(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            n = 5000;
            answer = 406880451;
            result = solution.KnightDialer(n);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
