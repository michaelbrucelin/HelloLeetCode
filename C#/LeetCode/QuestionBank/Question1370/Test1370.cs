using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1370
{
    public class Test1370
    {
        public void Test()
        {
            Interface1370 solution = new Solution1370();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "aaaabbbbcccc"; answer = "abccbaabccba";
            result = solution.SortString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "rat"; answer = "art";
            result = solution.SortString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "leetcode"; answer = "cdelotee";
            result = solution.SortString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "ggggggg"; answer = "ggggggg";
            result = solution.SortString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "spo"; answer = "ops";
            result = solution.SortString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
