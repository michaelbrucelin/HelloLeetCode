using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3834
{
    public class Test3834
    {
        public void Test()
        {
            Interface3834 solution = new Solution3834();
            int[] nums;
            IList<long> result, answer;
            int id = 0;

            // 1. 
            nums = [3, 1, 1, 2];
            answer = [3, 4];
            result = solution.MergeAdjacent(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [2, 2, 4];
            answer = [8];
            result = solution.MergeAdjacent(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [3, 7, 5];
            answer = [3, 7, 5];
            result = solution.MergeAdjacent(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            string question = "3834", testcase = "04", arg = "nums";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            answer = [1638400000, 819200000, 409600000, 102400000, 25600000, 3200000, 1600000];
            result = solution.MergeAdjacent(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
