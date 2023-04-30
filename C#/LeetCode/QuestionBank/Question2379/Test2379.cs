using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2379
{
    public class Test2379
    {
        public void Test()
        {
            Interface2379 solution = new Solution2379();
            string blocks; int k;
            int result, answer;
            int id = 0;

            // 1. 
            blocks = "WBBWWBBWBW"; k = 7; answer = 3;
            result = solution.MinimumRecolors(blocks, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            blocks = "WBWBBBW"; k = 2; answer = 0;
            result = solution.MinimumRecolors(blocks, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            blocks = "WWBBBWBBBBBWWBWWWB"; k = 16; answer = 6;
            result = solution.MinimumRecolors(blocks, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
