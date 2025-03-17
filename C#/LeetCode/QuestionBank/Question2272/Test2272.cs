using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2272
{
    public class Test2272
    {
        public void Test()
        {
            Interface2272 solution = new Solution2272();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "aababbb";
            answer = 3;
            result = solution.LargestVariance(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "abcde";
            answer = 0;
            result = solution.LargestVariance(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2272", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_s.txt")[1..^1];
            answer = 77;
            result = solution.LargestVariance(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
