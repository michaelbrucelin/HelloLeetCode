using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3129
{
    public class Test3129
    {
        public void Test()
        {
            Interface3129 solution = new Solution3129_3();
            int zero, one, limit;
            int result, answer;
            int id = 0;

            // 1. 
            zero = 1; one = 1; limit = 2;
            answer = 2;
            result = solution.NumberOfStableArrays(zero, one, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            zero = 1; one = 2; limit = 1;
            answer = 1;
            result = solution.NumberOfStableArrays(zero, one, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            zero = 3; one = 3; limit = 2;
            answer = 14;
            result = solution.NumberOfStableArrays(zero, one, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            zero = 13; one = 20; limit = 93;
            answer = 573166440;
            result = solution.NumberOfStableArrays(zero, one, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            zero =72; one =74; limit =53;
            answer = 396816249;
            result = solution.NumberOfStableArrays(zero, one, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6.
            zero =200; one =200; limit =25;
            answer = 292126791;
            result = solution.NumberOfStableArrays(zero, one, limit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
