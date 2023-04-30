using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2309
{
    public class Test2309
    {
        public void Test()
        {
            Interface2309 solution = new Solution2309_3();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "lEeTcOdE"; answer = "E";
            result = solution.GreatestLetter(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "arRAzFif"; answer = "R";
            result = solution.GreatestLetter(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "AbCdEfGhIjK"; answer = "";
            result = solution.GreatestLetter(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
