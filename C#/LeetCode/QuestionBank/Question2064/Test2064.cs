using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2064
{
    public class Test2064
    {
        public void Test()
        {
            Interface2064 solution = new Solution2064();
            int n; int[] quantities;
            int result, answer;
            int id = 0;

            // 1. 
            n = 6; quantities = [11, 6];
            answer = 3;
            result = solution.MinimizedMaximum(n, quantities);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 7; quantities = [15, 10, 10];
            answer = 5;
            result = solution.MinimizedMaximum(n, quantities);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 1; quantities = [100000];
            answer = 100000;
            result = solution.MinimizedMaximum(n, quantities);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "2064", testcase = "04", arg = "quantities";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            quantities = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            n = 76197;
            answer = 98212;
            result = solution.MinimizedMaximum(n, quantities);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
