using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1255
{
    public class Test1255
    {
        public void Test()
        {
            Interface1255 solution = new Solution1255_4();
            string[] words; char[] letters; int[] score;
            int result, answer;
            int id = 0;

            // 1. 
            words = new string[] { "dog", "cat", "dad", "good" };
            letters = new char[] { 'a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o' };
            score = new int[] { 1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            answer = 23;
            result = solution.MaxScoreWords(words, letters, score);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            words = new string[] { "xxxz", "ax", "bx", "cx" };
            letters = new char[] { 'z', 'a', 'b', 'c', 'x', 'x', 'x' };
            score = new int[] { 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 10 };
            answer = 27;
            result = solution.MaxScoreWords(words, letters, score);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            words = new string[] { "leetcode" };
            letters = new char[] { 'l', 'e', 't', 'c', 'o', 'd' };
            score = new int[] { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
            answer = 0;
            result = solution.MaxScoreWords(words, letters, score);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
