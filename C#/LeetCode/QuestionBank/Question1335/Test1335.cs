using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1335
{
    public class Test1335
    {
        public void Test()
        {
            Interface1335 solution = new Solution1335();
            int[] jobDifficulty; int d;
            int result, answer;
            int id = 0;

            // 1. 
            jobDifficulty = new int[] { 6, 5, 4, 3, 2, 1 }; d = 2; answer = 7;
            result = solution.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            jobDifficulty = new int[] { 9, 9, 9 }; d = 4; answer = -1;
            result = solution.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            jobDifficulty = new int[] { 1, 1, 1 }; d = 3; answer = 3;
            result = solution.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            jobDifficulty = new int[] { 7, 1, 7, 1, 7, 1 }; d = 3; answer = 15;
            result = solution.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            jobDifficulty = new int[] { 11, 111, 22, 222, 33, 333, 44, 444 }; d = 6; answer = 843;
            result = solution.MinDifficulty(jobDifficulty, d);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
