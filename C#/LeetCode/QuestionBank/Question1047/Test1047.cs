using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1047
{
    public class Test1047
    {
        public void Test()
        {
            Interface1047 solution = new Solution1047();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "abbaca";
            answer = "ca";
            result = solution.RemoveDuplicates(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "azxxzy";
            answer = "ay";
            result = solution.RemoveDuplicates(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "aaaaaaaa";
            answer = "";
            result = solution.RemoveDuplicates(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "1047", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            s = File.ReadAllText(path);
            answer = "";
            result = solution.RemoveDuplicates(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
