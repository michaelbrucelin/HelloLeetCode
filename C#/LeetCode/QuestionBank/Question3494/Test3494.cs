using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3494
{
    public class Test3494
    {
        public void Test()
        {
            Interface3494 solution = new Solution3494();
            int[] skill, mana;
            long result, answer;
            int id = 0;

            // 1. 
            skill = [1, 5, 2, 4]; mana = [5, 1, 4, 2];
            answer = 110;
            result = solution.MinTime(skill, mana);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            skill = [1, 1, 1]; mana = [1, 1, 1];
            answer = 5;
            result = solution.MinTime(skill, mana);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            skill = [1, 2, 3, 4]; mana = [1, 2];
            answer = 21;
            result = solution.MinTime(skill, mana);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
