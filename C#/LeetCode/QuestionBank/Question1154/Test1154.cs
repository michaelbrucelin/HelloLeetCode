using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1154
{
    public class Test1154
    {
        public void Test()
        {
            Interface1154 solution = new Solution1154_api();
            string date;
            int result, answer;
            int id = 0;

            // 1. 
            date = "2019-01-09";
            answer = 9;
            result = solution.DayOfYear(date);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            date = "2019-02-10";
            answer = 41;
            result = solution.DayOfYear(date);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            date = "2012-01-02";
            answer = 2;
            result = solution.DayOfYear(date);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
