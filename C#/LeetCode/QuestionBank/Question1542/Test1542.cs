using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1542
{
    public class Test1542
    {
        public void Test()
        {
            Interface1542 solution = new Solution1542_3();
            string s;
            int result, answer;
            int id = 0;

            // 1. 
            s = "3242415";
            answer = 5;
            result = solution.LongestAwesome(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "12345678";
            answer = 1;
            result = solution.LongestAwesome(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "213123";
            answer = 6;
            result = solution.LongestAwesome(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "00";
            answer = 2;
            result = solution.LongestAwesome(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "1542", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_s.txt");
            answer = 29995;
            result = solution.LongestAwesome(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
