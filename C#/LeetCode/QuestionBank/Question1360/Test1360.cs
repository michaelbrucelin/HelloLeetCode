using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1360
{
    public class Test1360
    {
        public void Test()
        {
            Interface1360 solution = new Solution1360_2();
            string date1, date2;
            int result, answer;
            int id = 0;

            // 1. 
            date1 = "2019-06-29"; date2 = "2019-06-30"; answer = 1;
            result = solution.DaysBetweenDates(date1, date2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            date1 = "2020-01-15"; date2 = "2019-12-31"; answer = 15;
            result = solution.DaysBetweenDates(date1, date2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            date1 = "2099-10-20"; date2 = "2082-02-21"; answer = 6450;
            result = solution.DaysBetweenDates(date1, date2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            date1 = "2009-08-18"; date2 = "2080-08-08"; answer = 25923;
            result = solution.DaysBetweenDates(date1, date2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
