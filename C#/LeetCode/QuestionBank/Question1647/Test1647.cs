using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1647
{
    public class Test1647
    {
        public void Test()
        {
            Interface1647 solution = new Solution1647();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "aab";
            answer = 0;
            result = solution.MinDeletions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "aaabbbcc";
            answer = 2;
            result = solution.MinDeletions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "ceabaacb";
            answer = 2;
            result = solution.MinDeletions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "bbcebab";
            answer = 2;
            result = solution.MinDeletions(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
