using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0357
{
    public class Test0357
    {
        public void Test()
        {
            Interface0357 solution = new Solution0357();
            int n;
            int result, answer;
            int id = 0;

            int[] answers = [1, 10, 91, 739, 5275, 32491, 168571, 712891, 2345851];
            for (int i = 0; i < 9; i++)
            {
                n = i;
                answer = answers[i];
                result = solution.CountNumbersWithUniqueDigits(n);
                Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            }
        }
    }
}
