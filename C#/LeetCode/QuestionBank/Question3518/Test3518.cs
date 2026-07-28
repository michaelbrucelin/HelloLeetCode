using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3518
{
    public class Test3518
    {
        public void Test()
        {
            Interface3518 solution = new Solution3518();
            string s; int k;
            string result, answer;
            int id = 0;

            // 1. 
            s = "abba"; k = 2;
            answer = "baab";
            result = solution.SmallestPalindrome(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "aa"; k = 2;
            answer = "";
            result = solution.SmallestPalindrome(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "bacab"; k = 1;
            answer = "abcba";
            result = solution.SmallestPalindrome(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "3518", testcase = "04", arg = "s";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            k = 72507;
            answer = File.ReadAllText($"{path}_{testcase}_answer.txt")[1..^1];
            result = solution.SmallestPalindrome(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result[..8]}, answer: {answer[..8]}");
        }
    }
}
