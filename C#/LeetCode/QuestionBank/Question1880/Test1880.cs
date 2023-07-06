using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1880
{
    public class Test1880
    {
        public void Test()
        {
            Interface1880 solution = new Solution1880_2();
            string firstWord, secondWord, targetWord;
            bool result, answer;
            int id = 0;

            // 1. 
            firstWord = "acb"; secondWord = "cba"; targetWord = "cdb";
            answer = true;
            result = solution.IsSumEqual(firstWord, secondWord, targetWord);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            firstWord = "aaa"; secondWord = "a"; targetWord = "aab";
            answer = false;
            result = solution.IsSumEqual(firstWord, secondWord, targetWord);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            firstWord = "aaa"; secondWord = "a"; targetWord = "aaaa";
            answer = true;
            result = solution.IsSumEqual(firstWord, secondWord, targetWord);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            firstWord = "abjfedid"; secondWord = "c"; targetWord = "bjfedif";
            answer = true;
            result = solution.IsSumEqual(firstWord, secondWord, targetWord);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
