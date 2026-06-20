using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1840
{
    public class Test1840
    {
        public void Test()
        {
            Interface1840 solution = new Solution1840();
            int n; int[][] restrictions;
            int result, answer;
            int id = 0;

            // 1. 
            n = 5; restrictions = [[2, 1], [4, 1]];
            answer = 2;
            result = solution.MaxBuilding(n, restrictions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 6; restrictions = [];
            answer = 5;
            result = solution.MaxBuilding(n, restrictions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 10; restrictions = [[5, 3], [2, 5], [7, 4], [10, 3]];
            answer = 5;
            result = solution.MaxBuilding(n, restrictions);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
