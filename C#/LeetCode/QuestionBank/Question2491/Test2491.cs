using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2491
{
    public class Test2491
    {
        public void Test()
        {
            Interface2491 solution = new Solution2491();
            int[] skill;
            long result, answer;
            int id = 0;

            // 1. 
            skill = [3, 2, 5, 1, 3, 4];
            answer = 22;
            result = solution.DividePlayers(skill);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            skill = [3, 4];
            answer = 12;
            result = solution.DividePlayers(skill);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            skill = [1, 1, 2, 3];
            answer = -1;
            result = solution.DividePlayers(skill);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            skill = [5, 3, 7, 1];
            answer = 22;
            result = solution.DividePlayers(skill);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
