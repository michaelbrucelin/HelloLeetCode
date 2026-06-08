using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3645
{
    public class Test3645
    {
        public void Test()
        {
            Interface3645 solution = new Solution3645();
            int[] value, limit;
            long result, answer;
            int id = 0;

            // 1. 
            value = [3, 5, 8]; limit = [2, 1, 3];
            answer = 16;
            result = solution.MaxTotal(value, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            value = [4, 2, 6]; limit = [1, 1, 1];
            answer = 6;
            result = solution.MaxTotal(value, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            value = [4, 1, 5, 2]; limit = [3, 3, 2, 3];
            answer = 12;
            result = solution.MaxTotal(value, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
