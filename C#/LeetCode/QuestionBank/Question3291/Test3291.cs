using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3291
{
    public class Test3291
    {
        public void Test()
        {
            Interface3291 solution = new Solution3291_3();
            string[] words; string target;
            int result, answer;
            int id = 0;

            // 1. 
            words = ["abc", "aaaaa", "bcdef"]; target = "aabcdabc";
            answer = 3;
            result = solution.MinValidStrings(words, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            words = ["abababab", "ab"]; target = "ababaababa";
            answer = 2;
            result = solution.MinValidStrings(words, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            words = ["abcdef"]; target = "xyz";
            answer = -1;
            result = solution.MinValidStrings(words, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            words = ["c", "a", "bcaa"]; target = "cccabccaca";
            answer = 9;
            result = solution.MinValidStrings(words, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "3291", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            words = File.ReadAllText($"{path}_{testcase}_words.txt")[2..^2].Split("\",\"");
            target = File.ReadAllText($"{path}_{testcase}_target.txt")[1..^1];
            answer = 5;
            result = solution.MinValidStrings(words, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            testcase = "06";
            words = File.ReadAllText($"{path}_{testcase}_words.txt")[2..^2].Split("\",\"");
            target = File.ReadAllText($"{path}_{testcase}_target.txt")[1..^1];
            answer = 100;
            result = solution.MinValidStrings(words, target);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
