using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3561
{
    public class Test3561
    {
        public void Test()
        {
            Interface3561 solution = new Solution3561();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "abc";
            answer = "c";
            result = solution.ResultingString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "adcb";
            answer = "";
            result = solution.ResultingString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "zadb";
            answer = "db";
            result = solution.ResultingString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "3561", testcase = "04", arg = "s";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            answer = File.ReadAllText($"{path}_{testcase}_answer.txt")[1..^1];
            result = solution.ResultingString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result[..8]}..., answer: {answer[..9]}...");
        }
    }
}
