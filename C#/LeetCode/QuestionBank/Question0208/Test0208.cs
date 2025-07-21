using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0208
{
    public class Test0208
    {
        public void Test()
        {
            Interface0208 solution;
            bool result, answer;
            int id = 0;

            // ["Trie", "insert",  "search",  "search", "startsWith", "insert", "search"]
            // [[],     ["apple"], ["apple"], ["app"], ["app"],       ["app"],  ["app"]]
            solution = new Trie_3();
            solution.Insert("apple");
            result = solution.Search("apple");
            answer = true;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.Search("app");
            answer = false;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            result = solution.StartsWith("app");
            answer = true;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.Insert("app");
            result = solution.Search("app");
            answer = true;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

        }
    }
}
