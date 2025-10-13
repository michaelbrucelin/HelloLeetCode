using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3186
{
    public class Test3186
    {
        public void Test()
        {
            Interface3186 solution = new Solution3186();
            int[] power;
            long result, answer;
            int id = 0;

            // 1. 
            power = [1, 1, 3, 4];
            answer = 6;
            result = solution.MaximumTotalDamage(power);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            power = [7, 1, 6, 6];
            answer = 13;
            result = solution.MaximumTotalDamage(power);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            power = [7, 1, 6, 3];
            answer = 10;
            result = solution.MaximumTotalDamage(power);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
