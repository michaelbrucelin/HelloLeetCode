using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1957
{
    public class Test1957
    {
        public void Test()
        {
            Interface1957 solution = new Solution1957();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "leeetcode";
            answer = "leetcode";
            result = solution.MakeFancyString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "aaabaaaa";
            answer = "aabaa";
            result = solution.MakeFancyString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "aab";
            answer = "aab";
            result = solution.MakeFancyString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "1957", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_s.txt");
            answer = File.ReadAllText($"{path}_{testcase}_answer.txt");
            result = solution.MakeFancyString(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result[0..10]}... ..., answer: {answer[0..10]}... ...");
        }
    }
}
