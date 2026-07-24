using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0306
{
    public class Test0306
    {
        public void Test()
        {
            Interface0306 solution = new Solution0306();
            string num;
            bool result, answer;
            int id = 0;

            // 1. 
            num = "112358";
            answer = true;
            result = solution.IsAdditiveNumber(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num = "199100199";
            answer = true;
            result = solution.IsAdditiveNumber(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num = "1023";
            answer = false;
            result = solution.IsAdditiveNumber(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            num = "12122436";
            answer = true;
            result = solution.IsAdditiveNumber(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            num = "0000";
            answer = true;
            result = solution.IsAdditiveNumber(num);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
