using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1830
{
    public class Test1830
    {
        public void Test()
        {
            Interface1830 solution = new Solution1830();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "cba";
            answer = 5;
            result = solution.MakeStringSorted(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "aabaa";
            answer = 2;
            result = solution.MakeStringSorted(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "cdbea";
            answer = 63;
            result = solution.MakeStringSorted(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "leetcodeleetcodeleetcode";
            answer = 982157772;
            result = solution.MakeStringSorted(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "haqppzbvuupv";
            answer = 3390293;
            result = solution.MakeStringSorted(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            string question = "1830", testcase = "06", arg = "s";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            answer = 448894755;
            result = solution.MakeStringSorted(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            testcase = "07";
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            answer = 664220111;
            result = solution.MakeStringSorted(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            testcase = "08";
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            answer = 574025719;
            result = solution.MakeStringSorted(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
