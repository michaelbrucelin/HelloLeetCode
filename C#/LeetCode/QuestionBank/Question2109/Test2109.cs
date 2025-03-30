using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2109
{
    public class Test2109
    {
        public void Test()
        {
            Interface2109 solution = new Solution2109();
            string s; int[] spaces;
            string result, answer;
            int id = 0;

            // 1. 
            s = "LeetcodeHelpsMeLearn"; spaces = [8, 13, 15];
            answer = "Leetcode Helps Me Learn";
            result = solution.AddSpaces(s, spaces);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "icodeinpython"; spaces = [1, 5, 7, 9];
            answer = "i code in py thon";
            result = solution.AddSpaces(s, spaces);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "spacing"; spaces = [0, 1, 2, 3, 4, 5, 6];
            answer = " s p a c i n g";
            result = solution.AddSpaces(s, spaces);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
