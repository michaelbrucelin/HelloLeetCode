using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1392
{
    public class Test1392
    {
        public void Test()
        {
            Interface1392 solution = new Solution1392_2();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "level";
            answer = "l";
            result = solution.LongestPrefix(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "ababab";
            answer = "abab";
            result = solution.LongestPrefix(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "leetcodeleet";
            answer = "leet";
            result = solution.LongestPrefix(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "1392", testcase = "04", arg = "s";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            arg = "answer";
            answer = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            result = solution.LongestPrefix(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result[..8]}, answer: {answer[..8]}");

            // 5. 
            testcase = "05"; arg = "s";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            arg = "answer";
            answer = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            result = solution.LongestPrefix(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result[..8]}, answer: {answer[..8]}");

            // 6. 
            testcase = "06"; arg = "s";
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            arg = "answer";
            answer = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            result = solution.LongestPrefix(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result[..8]}, answer: {answer[..8]}");
        }
    }
}
