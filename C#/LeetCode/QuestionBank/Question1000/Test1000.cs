using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1000
{
    public class Test1000
    {
        public void Test()
        {
            Interface1000 solution = new Solution1000_2();
            int[] stones; int k;
            int result, answer;
            int id = 0;

            // 1. 
            stones = new int[] { 3, 2, 4, 1 }; k = 2; answer = 20;
            result = solution.MergeStones(stones, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            stones = new int[] { 3, 2, 4, 1 }; k = 3; answer = -1;
            result = solution.MergeStones(stones, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            stones = new int[] { 3, 5, 1, 2, 6 }; k = 3; answer = 25;
            result = solution.MergeStones(stones, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            stones = new int[] { 1 }; k = 2; answer = 0;
            result = solution.MergeStones(stones, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            stones = new int[] { 69, 39, 79, 78, 16, 6, 36, 97, 79, 27, 14, 31, 4 }; k = 2; answer = 1957;
            result = solution.MergeStones(stones, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            stones = new int[] { 16, 43, 87, 30, 4, 98, 12, 30, 47, 45, 32, 4, 64, 14, 24, 84, 86, 51, 11, 22, 4 }; k = 2; answer = 3334;
            result = solution.MergeStones(stones, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
