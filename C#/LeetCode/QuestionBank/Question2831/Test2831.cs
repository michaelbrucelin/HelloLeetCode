using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2831
{
    public class Test2831
    {
        public void Test()
        {
            Interface2831 solution = new Solution2831();
            IList<int> nums; int k;
            int result, answer;
            int id = 0;

            // 1. 
            nums = [1, 3, 2, 3, 1, 3]; k = 3;
            answer = 3;
            result = solution.LongestEqualSubarray(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [1, 1, 2, 2, 1, 1]; k = 2;
            answer = 4;
            result = solution.LongestEqualSubarray(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = [1, 2, 1]; k = 0;
            answer = 1;
            result = solution.LongestEqualSubarray(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            string question = "2831", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            k = 19219;
            answer = 6;
            result = solution.LongestEqualSubarray(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
