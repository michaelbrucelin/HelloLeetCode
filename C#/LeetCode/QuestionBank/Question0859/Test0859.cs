using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0859
{
    public class Test0859
    {
        public void Test()
        {
            Interface0859 solution = new Solution0859();
            string s, goal;
            bool result, answer;
            int id = 0;

            // 1. 
            s = "ab"; goal = "ba"; answer = true;
            result = solution.BuddyStrings(s, goal);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "ab"; goal = "ab"; answer = false;
            result = solution.BuddyStrings(s, goal);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "aa"; goal = "aa"; answer = true;
            result = solution.BuddyStrings(s, goal);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
