using LeetCode.Utilses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0524
{
    public class Test0524
    {
        public void Test()
        {
            Interface0524 solution = new Solution0524_3();
            string s; IList<string> dictionary;
            string result, answer;
            int id = 0;

            // 1. 
            s = "abpcplea"; dictionary = ["ale", "apple", "monkey", "plea"];
            answer = "apple";
            result = solution.FindLongestWord(s, dictionary);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "abpcplea"; dictionary = ["a", "b", "c"];
            answer = "a";
            result = solution.FindLongestWord(s, dictionary);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "aaa"; dictionary = ["aaa", "aa", "a"];
            answer = "aaa";
            result = solution.FindLongestWord(s, dictionary);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "0524", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            dictionary = Utils.Str2StrList(File.ReadAllText($"{path}_{testcase}_dictionary.txt"));
            s = File.ReadAllText($"{path}_{testcase}_s.txt")[1..^1];
            answer = "ntgcykxhdfescxxypyew";
            result = solution.FindLongestWord(s, dictionary);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
