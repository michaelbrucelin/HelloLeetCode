using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2904
{
    public class Test2904
    {
        public void Test()
        {
            Interface2904 solution = new Solution2904();
            string s; int k;
            string result, answer;
            int id = 0;

            // 1. 
            s = "100011001"; k = 3;
            answer = "11001";
            result = solution.ShortestBeautifulSubstring(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "1011"; k = 2;
            answer = "11";
            result = solution.ShortestBeautifulSubstring(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "000"; k = 1;
            answer = "";
            result = solution.ShortestBeautifulSubstring(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "100011000000000"; k = 9;
            answer = "";
            result = solution.ShortestBeautifulSubstring(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "00"; k = 2;
            answer = "";
            result = solution.ShortestBeautifulSubstring(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
