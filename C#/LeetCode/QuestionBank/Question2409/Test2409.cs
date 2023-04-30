using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2409
{
    public class Test2409
    {
        public void Test()
        {
            Interface2409 solution = new Solution2409_2();
            string arriveAlice, leaveAlice, arriveBob, leaveBob;
            int result, answer;
            int id = 0;

            // 1. 
            arriveAlice = "08-15"; leaveAlice = "08-18"; arriveBob = "08-16"; leaveBob = "08-19";
            answer = 3;
            result = solution.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arriveAlice = "10-01"; leaveAlice = "10-31"; arriveBob = "11-01"; leaveBob = "12-31";
            answer = 0;
            result = solution.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arriveAlice = "09-01"; leaveAlice = "10-19"; arriveBob = "06-19"; leaveBob = "10-20";
            answer = 49;
            result = solution.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arriveAlice = "01-20"; leaveAlice = "04-18"; arriveBob = "01-01"; leaveBob = "08-30";
            answer = 89;
            result = solution.CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
