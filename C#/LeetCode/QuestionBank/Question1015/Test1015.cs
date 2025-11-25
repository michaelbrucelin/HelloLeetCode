using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1015
{
    public class Test1015
    {
        public void Test()
        {
            Interface1015 solution = new Solution1015();
            int k;
            int result, answer;
            int id = 0;

            // 1. 
            k = 1;
            answer = 1;
            result = solution.SmallestRepunitDivByK(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            k = 2;
            answer = -1;
            result = solution.SmallestRepunitDivByK(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            k = 3;
            answer = 3;
            result = solution.SmallestRepunitDivByK(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            k = 7;
            answer = 6;
            result = solution.SmallestRepunitDivByK(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            k = 17;
            answer = 16;
            result = solution.SmallestRepunitDivByK(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            k = 49;
            answer = 42;
            result = solution.SmallestRepunitDivByK(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            k = 9671;
            answer = 4572;
            result = solution.SmallestRepunitDivByK(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
