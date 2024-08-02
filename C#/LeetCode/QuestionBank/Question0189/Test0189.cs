using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0189
{
    public class Test0189
    {
        public void Test()
        {
            Interface0189 solution = new Solution0189_off_3();
            int[] nums; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3, 4, 5, 6, 7]; k = 3;
            answer = [5, 6, 7, 1, 2, 3, 4];
            solution.Rotate(nums, k);
            result = nums;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [-1, -100, 3, 99]; k = 2;
            answer = [3, 99, -1, -100];
            solution.Rotate(nums, k);
            result = nums;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [1, 2, 3, 4, 5, 6]; k = 4;
            answer = [3, 4, 5, 6, 1, 2];
            solution.Rotate(nums, k);
            result = nums;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            string question = "0189", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            k = 54944;
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            solution.Rotate(nums, k);
            result = nums;
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[0..10])}, answer: {Utils.ToString(answer[0..10])}");
        }
    }
}
