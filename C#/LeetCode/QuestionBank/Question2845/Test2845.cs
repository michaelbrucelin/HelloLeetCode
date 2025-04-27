using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2845
{
    public class Test2845
    {
        public void Test()
        {
            Interface2845 solution = new Solution2845();
            IList<int> nums; int modulo, k;
            long result, answer;
            int id = 0;

            // 1. 
            nums = [3, 2, 4]; modulo = 2; k = 1;
            answer = 3;
            result = solution.CountInterestingSubarrays(nums, modulo, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = [3, 1, 9, 6]; modulo = 3; k = 0;
            answer = 2;
            result = solution.CountInterestingSubarrays(nums, modulo, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            string question = "2845", testcase = "03";
            modulo = 1; k = 0;
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            answer = 5000050000;
            result = solution.CountInterestingSubarrays(nums, modulo, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
