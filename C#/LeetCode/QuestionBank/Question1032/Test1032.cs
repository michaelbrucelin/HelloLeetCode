using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1032
{
    public class Test1032
    {
        public void Test()
        {
            Interface1032 solution;
            string[] words; char[] letters;
            bool result, answer; bool[] answers;
            int id = 0;

            // 1. 
            words = new string[] { "cd", "f", "kl" };
            letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l' };
            answers = new bool[] { false, false, false, true, false, true, false, false, false, false, false, true };
            solution = new StreamChecker(words);
            for (int i = 0; i < letters.Length; i++)
            {
                answer = answers[i];
                result = solution.Query(letters[i]);
                Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            }
        }
    }
}
