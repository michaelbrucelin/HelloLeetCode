using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2197
{
    public class Test2197
    {
        public void Test()
        {
            Interface2197 solution = new Solution2197_2();
            int[] nums;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            nums = [6, 4, 3, 2, 7, 6, 2];
            answer = [12, 7, 6];
            result = solution.ReplaceNonCoprimes(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [2, 2, 1, 1, 3, 3, 3];
            answer = [2, 1, 1, 3];
            result = solution.ReplaceNonCoprimes(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [48757];
            answer = [48757];
            result = solution.ReplaceNonCoprimes(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            nums = [517, 11, 121, 517, 3, 51, 3, 1887, 5];
            answer = [5687, 1887, 5];
            result = solution.ReplaceNonCoprimes(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            nums = [19, 19, 19, 19, 19, 851, 9361, 2783, 407, 11];
            answer = [19, 102971];
            result = solution.ReplaceNonCoprimes(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 6. 
            nums = [31, 97561, 97561, 97561, 97561, 97561, 97561, 97561, 97561];
            answer = [31, 97561];
            result = solution.ReplaceNonCoprimes(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 7. 
            nums = [13, 13, 13, 13, 13, 13, 13];
            answer = [13];
            result = solution.ReplaceNonCoprimes(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 8. 
            string question = "2197", testcase = "08";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            answer = [6];
            result = solution.ReplaceNonCoprimes(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
