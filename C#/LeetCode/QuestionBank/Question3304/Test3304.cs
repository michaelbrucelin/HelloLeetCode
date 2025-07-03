using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3304
{
    public class Test3304
    {
        public void Test()
        {
            Interface3304 solution = new Solution3304_3();
            int k;
            char result, answer;
            int id = 0;

            // 1. 
            k = 5;
            answer = 'b';
            result = solution.KthCharacter(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            k = 10;
            answer = 'c';
            result = solution.KthCharacter(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            k = 12;
            answer = 'd';
            result = solution.KthCharacter(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            k = 13;
            answer = 'c';
            result = solution.KthCharacter(k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
