using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0648
{
    public class Test0648
    {
        public void Test()
        {
            Interface0648 solution = new Solution0648_2();
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
        }
    }
}
