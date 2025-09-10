using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1733
{
    public class Test1733
    {
        public void Test()
        {
            Interface1733 solution = new Solution1733_2();
            int n; int[][] languages, friendships;
            int result, answer;
            int id = 0;

            // 1. 
            n = 2; languages = [[1], [2], [1, 2]]; friendships = [[1, 2], [1, 3], [2, 3]];
            answer = 1;
            result = solution.MinimumTeachings(n, languages, friendships);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 3; languages = [[2], [1, 3], [1, 2], [3]]; friendships = [[1, 4], [1, 2], [3, 4], [2, 3]];
            answer = 2;
            result = solution.MinimumTeachings(n, languages, friendships);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
