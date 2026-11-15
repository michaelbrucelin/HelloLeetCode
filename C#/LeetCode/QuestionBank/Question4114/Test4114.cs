using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question4114
{
    public class Test4114
    {
        public void Test()
        {
            Interface4114 solution = new Solution4114();
            int[] nums;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [5, 3, 1, 2];
            answer = 6;
            result = solution.CountConsistent(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 1, 1];
            answer = 6;
            result = solution.CountConsistent(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [0];
            answer = 1;
            result = solution.CountConsistent(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "4114", testcase = "04", arg = "nums";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = 5000050000;
            result = solution.CountConsistent(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
