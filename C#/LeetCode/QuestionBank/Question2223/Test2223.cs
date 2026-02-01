using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2223
{
    public class Test2223
    {
        public void Test()
        {
            Interface2223 solution = new Solution2223_2();
            string s;
            long result, answer;
            int id = 0;

            // 1. 
            s = "babab";
            answer = 9;
            result = solution.SumScores(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "azbazbzaz";
            answer = 14;
            result = solution.SumScores(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2223", testcase = "03", arg = "s";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            s = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            answer = 1329805622;
            result = solution.SumScores(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
