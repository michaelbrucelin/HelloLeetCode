using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2024
{
    public class Test2024
    {
        public void Test()
        {
            Interface2024 solution = new Solution2024_2();
            string answerKey; int k;
            int result, answer;
            int id = 0;

            // 1. 
            answerKey = "TTFF"; k = 2;
            answer = 4;
            result = solution.MaxConsecutiveAnswers(answerKey, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            answerKey = "TFFT"; k = 1;
            answer = 3;
            result = solution.MaxConsecutiveAnswers(answerKey, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            answerKey = "TTFTTFTT"; k = 1;
            answer = 5;
            result = solution.MaxConsecutiveAnswers(answerKey, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            answerKey = "FFTFTTTFFF"; k = 1;
            answer = 5;
            result = solution.MaxConsecutiveAnswers(answerKey, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
