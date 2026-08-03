using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1406
{
    public class Test1406
    {
        public void Test()
        {
            Interface1406 solution = new Solution1406_2();
            int[] stoneValue;
            string result, answer;
            int id = 0;

            // 1. 
            stoneValue = [1, 2, 3, 7];
            answer = "Bob";
            result = solution.StoneGameIII(stoneValue);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            stoneValue = [1, 2, 3, -9];
            answer = "Alice";
            result = solution.StoneGameIII(stoneValue);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            stoneValue = [1, 2, 3, 6];
            answer = "Tie";
            result = solution.StoneGameIII(stoneValue);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            stoneValue = [-1, -2, -3];
            answer = "Tie";
            result = solution.StoneGameIII(stoneValue);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
