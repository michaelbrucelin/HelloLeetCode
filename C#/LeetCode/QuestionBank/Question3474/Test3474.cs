using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3474
{
    public class Test3474
    {
        public void Test()
        {
            Interface3474 soluton = new Solution3474();
            string str1, str2;
            string result, answer;
            int id = 0;

            // 1. 
            str1 = "TFTF"; str2 = "ab";
            answer = "ababa";
            result = soluton.GenerateString(str1, str2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            str1 = "TFTF"; str2 = "abc";
            answer = "";
            result = soluton.GenerateString(str1, str2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            str1 = "F"; str2 = "d";
            answer = "a";
            result = soluton.GenerateString(str1, str2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            str1 = "TTFFT"; str2 = "fff";
            answer = "";
            result = soluton.GenerateString(str1, str2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "3474", testcase = "05", arg = "str1";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            str1 = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            str2 = "bab";
            answer = File.ReadAllText($"{path}_{testcase}_answer.txt")[1..^1];
            result = soluton.GenerateString(str1, str2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result[0..Math.Min(result.Length, 8)]}, answer: {answer[0..Math.Min(answer.Length, 8)]}");
        }
    }
}
