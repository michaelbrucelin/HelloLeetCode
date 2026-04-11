using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1297
{
    public class Test1297
    {
        public void Test()
        {
            Interface1297 solution = new Solution1297_3();
            string s; int maxLetters, minSize, maxSize;
            int result, answer;
            int id = 0;

            // 1. 
            s = "aababcaab"; maxLetters = 2; minSize = 3; maxSize = 4;
            answer = 2;
            result = solution.MaxFreq(s, maxLetters, minSize, maxSize);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "aaaa"; maxLetters = 1; minSize = 3; maxSize = 3;
            answer = 2;
            result = solution.MaxFreq(s, maxLetters, minSize, maxSize);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "aabcabcab"; maxLetters = 2; minSize = 2; maxSize = 3;
            answer = 3;
            result = solution.MaxFreq(s, maxLetters, minSize, maxSize);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "abcde"; maxLetters = 2; minSize = 3; maxSize = 3;
            answer = 0;
            result = solution.MaxFreq(s, maxLetters, minSize, maxSize);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "bbacbadadc"; maxLetters = 2; minSize = 1; maxSize = 1;
            answer = 3;
            result = solution.MaxFreq(s, maxLetters, minSize, maxSize);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
