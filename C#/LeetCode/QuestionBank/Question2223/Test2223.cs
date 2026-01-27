using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2223
{
    public class Test2223
    {
        public void Test()
        {
            Interface2223 solution = new Solution2223_err();
            string s;
            long result, answer;
            int id = 0;

            // 1. 
            s = "babab";
            answer = 9;
            result = solution.SumScores(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "azbazbzaz";
            answer = 14;
            result = solution.SumScores(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
