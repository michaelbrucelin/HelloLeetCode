using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0650
{
    public class Test0650
    {
        public void Test()
        {
            Interface0650 solution = new Solution0650();
            int n;
            int result, answer;
            int id = 0;

            int[] inputs = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 1000];
            int[] answers = [0, 2, 3, 4, 5, 5, 7, 6, 6, 7, 11, 7, 13, 9, 8, 8, 21];

            for (int i = 0, len = inputs.Length; i < len; i++)
            {
                n = inputs[i];
                answer = answers[i];
                result = solution.MinSteps(n);
                Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            }
        }
    }
}
