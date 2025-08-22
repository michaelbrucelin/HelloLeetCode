using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0991
{
    public class Test0991
    {
        public void Test()
        {
            Interface0991 solution = new Solution0991();
            int startValue, target;
            int result, answer;
            int id = 0;

            // 1. 
            startValue = 2; target = 3;
            answer = 2;
            result = solution.BrokenCalc(startValue, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            startValue = 5; target = 8;
            answer = 2;
            result = solution.BrokenCalc(startValue, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            startValue = 3; target = 10;
            answer = 3;
            result = solution.BrokenCalc(startValue, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
