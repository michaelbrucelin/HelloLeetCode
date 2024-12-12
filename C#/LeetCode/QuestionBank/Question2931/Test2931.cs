using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2931
{
    public class Test2931
    {
        public void Test()
        {
            Interface2931 solution = new Solution2931_4();
            int[][] values;
            long result, answer;
            int id = 0;

            // 1. 
            values = [[8, 5, 2], [6, 4, 1], [9, 7, 3]];
            answer = 285;
            result = solution.MaxSpending(values);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            values = [[10, 8, 6, 4, 2], [9, 7, 5, 3, 2]];
            answer = 386;
            result = solution.MaxSpending(values);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2931", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            values = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_values.txt"));
            answer = 9513923186942;
            result = solution.MaxSpending(values);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
