using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1657
{
    public class Test1657
    {
        public void Test()
        {
            Interface1657 solution = new Solution1657_api();
            string word1, word2;
            bool result, answer;
            int id = 0;

            // 1. 
            word1 = "abc"; word2 = "bca";
            answer = true;
            result = solution.CloseStrings(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word1 = "a"; word2 = "aa";
            answer = false;
            result = solution.CloseStrings(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word1 = "cabbba"; word2 = "abbccc";
            answer = true;
            result = solution.CloseStrings(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            word1 = "cabbba"; word2 = "aabbss";
            answer = false;
            result = solution.CloseStrings(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            word1 = "uau"; word2 = "ssx";
            answer = false;
            result = solution.CloseStrings(word1, word2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
