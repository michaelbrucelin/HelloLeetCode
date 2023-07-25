using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2208
{
    public class Test2208
    {
        public void Test()
        {
            Interface2208 solution = new Solution2208_oth();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 5, 19, 8, 1 };
            answer = 3;
            result = solution.HalveArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 3, 8, 20 };
            answer = 3;
            result = solution.HalveArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2208", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            nums = UtilsLeetCode.Str2NumArray<int>(File.ReadAllText(path));
            answer = 1435;
            result = solution.HalveArray(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
