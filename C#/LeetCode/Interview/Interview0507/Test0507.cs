using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0507
{
    public class Test0507
    {
        public void Test()
        {
            Interface0507 solution = new Solution0507();
            int num;
            int result, answer;
            int id = 0;

            // 1. 
            num = 2;
            answer = 1;
            result = solution.ExchangeBits(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = 3;
            answer = 3;
            result = solution.ExchangeBits(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = 5;
            answer = 10;
            result = solution.ExchangeBits(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 题目限定了不会出现负数，所以这个测试用例是没有意义的
            num = -10;
            answer = 2147483641;
            result = solution.ExchangeBits(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
