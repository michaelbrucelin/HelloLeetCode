using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3040
{
    public class Test3040
    {
        public void Test()
        {
            Interface3040 solution = new Solution3040_3();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [3, 2, 1, 2, 3, 4];
            answer = 3;
            result = solution.MaxOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [3, 2, 6, 1, 4];
            answer = 2;
            result = solution.MaxOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "3040", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            answer = 1000;
            result = solution.MaxOperations(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
