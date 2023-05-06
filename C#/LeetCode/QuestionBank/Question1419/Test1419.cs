using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1419
{
    public class Test1419
    {
        public void Test()
        {
            Interface1419 solution = new Solution1419();
            string croakOfFrogs;
            int result, answer;
            int id = 0;

            // 1. 
            croakOfFrogs = "croakcroak"; answer = 1;
            result = solution.MinNumberOfFrogs(croakOfFrogs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            croakOfFrogs = "crcoakroak"; answer = 2;
            result = solution.MinNumberOfFrogs(croakOfFrogs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            croakOfFrogs = "croakcrook"; answer = -1;
            result = solution.MinNumberOfFrogs(croakOfFrogs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            croakOfFrogs = "crocakcroraoakk"; answer = 2;
            result = solution.MinNumberOfFrogs(croakOfFrogs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "1419", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            croakOfFrogs = File.ReadAllText(path)[1..^1]; answer = 16388;
            result = solution.MinNumberOfFrogs(croakOfFrogs);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
