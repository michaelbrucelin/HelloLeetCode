using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1997
{
    public class Test1997
    {
        public void Test()
        {
            Interface1997 solution = new Solution1997_err();
            int[] nextVisit;
            int result, answer;
            int id = 0;

            // 1. 
            nextVisit = new int[] { 0, 0 };
            answer = 2;
            result = solution.FirstDayBeenInAllRooms(nextVisit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nextVisit = new int[] { 0, 0, 2 };
            answer = 6;
            result = solution.FirstDayBeenInAllRooms(nextVisit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nextVisit = new int[] { 0, 1, 2, 0 };
            answer = 6;
            result = solution.FirstDayBeenInAllRooms(nextVisit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nextVisit = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            answer = 320260018;
            result = solution.FirstDayBeenInAllRooms(nextVisit);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
