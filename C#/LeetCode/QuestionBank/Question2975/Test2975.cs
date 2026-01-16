using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2975
{
    public class Test2975
    {
        public void Test()
        {
            Interface2975 solution = new Solution2975();
            int m, n; int[] hFences, vFences;
            int result, answer;
            int id = 0;

            // 1. 
            m = 4; n = 3; hFences = [2, 3]; vFences = [2];
            answer = 4;
            result = solution.MaximizeSquareArea(m, n, hFences, vFences);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            m = 6; n = 7; hFences = [2]; vFences = [4];
            answer = -1;
            result = solution.MaximizeSquareArea(m, n, hFences, vFences);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
