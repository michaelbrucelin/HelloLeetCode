using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0392
{
    public class Test0392
    {
        public void Test()
        {
            Interface0392 solution = new Solution0392_4();
            string s, t;
            bool result, answer;
            int id = 0;

            // 1. 
            s = "abc"; t = "ahbgdc"; answer = true;
            result = solution.IsSubsequence(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "axc"; t = "ahbgdc"; answer = false;
            result = solution.IsSubsequence(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "acb"; t = "ahbgdc"; answer = false;
            result = solution.IsSubsequence(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "aaaaaa"; t = "bbaaaa"; answer = false;
            result = solution.IsSubsequence(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
