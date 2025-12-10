using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0063
{
    public class Test0063
    {
        public void Test()
        {
            Interface0063 solution = new Solution0063();
            IList<string> dictionary; string sentence;
            string result, answer;
            int id = 0;

            // 1. 
            dictionary = ["cat", "bat", "rat"]; sentence = "the cattle was rattled by the battery";
            answer = "the cat was rat by the bat";
            result = solution.ReplaceWords(dictionary, sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            dictionary = ["a", "b", "c"]; sentence = "aadsfasf absbs bbab cadsfafs";
            answer = "a a b c";
            result = solution.ReplaceWords(dictionary, sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            dictionary = ["a", "aa", "aaa", "aaaa"]; sentence = "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa";
            answer = "a a a a a a a a bbb baba a";
            result = solution.ReplaceWords(dictionary, sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            dictionary = ["catt", "cat", "bat", "rat"]; sentence = "the cattle was rattled by the battery";
            answer = "the cat was rat by the bat";
            result = solution.ReplaceWords(dictionary, sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            dictionary = ["ac", "ab"]; sentence = "it is abnormal that this solution is accepted";
            answer = "it is ab that this solution is ac";
            result = solution.ReplaceWords(dictionary, sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
