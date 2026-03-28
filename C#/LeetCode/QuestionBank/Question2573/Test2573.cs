using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2573
{
    public class Test2573
    {
        public void Test()
        {
            Interface2573 solution = new Solution2573();
            int[][] lcp;
            string result, answer;
            int id = 0;

            // 1. 
            lcp = [[4, 0, 2, 0], [0, 3, 0, 1], [2, 0, 2, 0], [0, 1, 0, 1]];
            answer = "abab";
            result = solution.FindTheString(lcp);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            lcp = [[4, 3, 2, 1], [3, 3, 2, 1], [2, 2, 2, 1], [1, 1, 1, 1]];
            answer = "aaaa";
            result = solution.FindTheString(lcp);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            lcp = [[4, 3, 2, 1], [3, 3, 2, 1], [2, 2, 2, 1], [1, 1, 1, 3]];
            answer = "";
            result = solution.FindTheString(lcp);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            lcp = [[4, 1, 1, 1], [1, 3, 1, 1], [1, 1, 2, 1], [1, 1, 1, 1]];
            answer = "";
            result = solution.FindTheString(lcp);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            lcp = [[8, 0, 0, 0, 0, 1, 2, 0], [0, 7, 0, 1, 1, 0, 0, 1], [0, 0, 6, 0, 0, 0, 0, 0], [0, 1, 0, 5, 1, 0, 0, 1],
                   [0, 1, 0, 1, 4, 0, 0, 1], [1, 0, 0, 0, 0, 3, 1, 0], [2, 0, 0, 0, 0, 1, 2, 0], [0, 1, 0, 1, 1, 0, 0, 1]];
            answer = "abcbbaab";
            result = solution.FindTheString(lcp);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
