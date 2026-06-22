using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1434
{
    public class Test1434
    {
        public void Test()
        {
            Interface1434 solution = new Solution1434();
            IList<IList<int>> hats;
            int result, answer;
            int id = 0;

            // 1. 
            hats = [[3, 4], [4, 5], [5]];
            answer = 1;
            result = solution.NumberWays(hats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            hats = [[3, 5, 1], [3, 5]];
            answer = 4;
            result = solution.NumberWays(hats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            hats = [[1, 2, 3, 4], [1, 2, 3, 4], [1, 2, 3, 4], [1, 2, 3, 4]];
            answer = 24;
            result = solution.NumberWays(hats);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
