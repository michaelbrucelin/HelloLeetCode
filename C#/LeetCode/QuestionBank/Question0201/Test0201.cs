using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0201
{
    public class Test0201
    {
        public void Test()
        {
            Interface0201 solution = new Solution0201();
            int left, right;
            int result, answer;
            int id = 0;

            // 1. 
            left = 5; right = 7;
            answer = 4;
            result = solution.RangeBitwiseAnd(left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            left = 0; right = 0;
            answer = 0;
            result = solution.RangeBitwiseAnd(left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            left = 1; right = 2147483647;
            answer = 0;
            result = solution.RangeBitwiseAnd(left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            //4. 
            left = 416; right = 436;
            answer = 416;
            result = solution.RangeBitwiseAnd(left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            left = 1; right = 2;
            answer = 0;
            result = solution.RangeBitwiseAnd(left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");


            // 6. 
            left = 1; right = 1;
            answer = 1;
            result = solution.RangeBitwiseAnd(left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            left = 2147483646; right = 2147483647;
            answer = 2147483646;
            result = solution.RangeBitwiseAnd(left, right);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
