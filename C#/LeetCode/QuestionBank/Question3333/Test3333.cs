using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3333
{
    public class Test3333
    {
        public void Test()
        {
            Interface3333 solution = new Solution3333_2();
            string word; int k;
            int result, answer;
            int id = 0;

            // 1. 
            word = "aabbccdd"; k = 7;
            answer = 5;
            result = solution.PossibleStringCount(word, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word = "aabbccdd"; k = 8;
            answer = 1;
            result = solution.PossibleStringCount(word, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word = "aaabbb"; k = 3;
            answer = 8;
            result = solution.PossibleStringCount(word, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "3333", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            word = File.ReadAllText($"{path}_{testcase}_word.txt")[1..^1];
            k = 1365;
            answer = 676224483;
            result = solution.PossibleStringCount(word, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            testcase = "05";
            word = File.ReadAllText($"{path}_{testcase}_word.txt")[1..^1];
            k = 1924;
            answer = 756148912;
            result = solution.PossibleStringCount(word, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
