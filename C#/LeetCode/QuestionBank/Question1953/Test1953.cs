using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1953
{
    public class Test1953
    {
        public void Test()
        {
            Interface1953 solution = new Solution1953();
            int[] milestones;
            long result, answer;
            int id = 0;

            // 1. 
            milestones = [1, 2, 3];
            answer = 6;
            result = solution.NumberOfWeeks(milestones);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            milestones = [5, 2, 1];
            answer = 7;
            result = solution.NumberOfWeeks(milestones);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            milestones = [5, 7, 5, 7, 9, 7];
            answer = 40;
            result = solution.NumberOfWeeks(milestones);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            milestones = [4, 5, 5, 2];
            answer = 16;
            result = solution.NumberOfWeeks(milestones);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
