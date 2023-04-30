using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1626
{
    public class Test1626
    {
        public void Test()
        {
            Interface1626 solution = new Solution1626();
            int[] scores, ages;
            int result, answer;
            int id = 0;

            // 1. 
            scores = new int[] { 1, 3, 5, 10, 15 }; ages = new int[] { 1, 2, 3, 4, 5 }; answer = 34;
            result = solution.BestTeamScore(scores, ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            scores = new int[] { 4, 5, 6, 5 }; ages = new int[] { 2, 1, 2, 1 }; answer = 16;
            result = solution.BestTeamScore(scores, ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            scores = new int[] { 1, 2, 3, 5 }; ages = new int[] { 8, 9, 10, 1 }; answer = 6;
            result = solution.BestTeamScore(scores, ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            scores = new int[] { 4, 5, 3, 5 }; ages = new int[] { 2, 1, 3, 1 }; answer = 10;
            result = solution.BestTeamScore(scores, ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            scores = new int[] { 4, 5, 3, 2 }; ages = new int[] { 2, 1, 3, 1 }; answer = 7;
            result = solution.BestTeamScore(scores, ages);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
