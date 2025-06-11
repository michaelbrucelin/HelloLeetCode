using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3445
{
    public class Test3445
    {
        public void Test()
        {
            Interface3445 solution = new Solution3445();
            string s; int k;
            int result, answer;
            int id = 0;

            // 1. 
            s = "12233"; k = 4;
            answer = -1;
            result = solution.MaxDifference(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "1122211"; k = 3;
            answer = 1;
            result = solution.MaxDifference(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "110"; k = 3;
            answer = -1;
            result = solution.MaxDifference(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "2222130"; k = 2;
            answer = -1;
            result = solution.MaxDifference(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "3445", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_s.txt")[1..^1];
            k = 3083;
            answer = 187;
            result = solution.MaxDifference(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
