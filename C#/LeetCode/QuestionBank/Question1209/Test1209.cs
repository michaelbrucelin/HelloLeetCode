using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1209
{
    public class Test1209
    {
        public void Test()
        {
            Interface1209 solution = new Solution1209_2();
            string s; int k;
            string result, answer;
            int id = 0;

            // 1. 
            s = "abcd"; k = 2;
            answer = "abcd";
            result = solution.RemoveDuplicates(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "deeedbbcccbdaa"; k = 3;
            answer = "aa";
            result = solution.RemoveDuplicates(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "pbbcggttciiippooaais"; k = 2;
            answer = "ps";
            result = solution.RemoveDuplicates(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "1209", testcase = "04", arg = "s";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            k = 2;
            answer = "";
            result = solution.RemoveDuplicates(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
