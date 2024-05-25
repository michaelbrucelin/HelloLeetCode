using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1673
{
    public class Test1673
    {
        public void Test()
        {
            Interface1673 solution = new Solution1673();
            int[] nums; int k;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [3, 5, 2, 6]; k = 2;
            answer = [2, 6];
            result = solution.MostCompetitive(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [2, 4, 3, 3, 5, 4, 9, 6]; k = 4;
            answer = [2, 3, 3, 4];
            result = solution.MostCompetitive(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [71, 18, 52, 29, 55, 73, 24, 42, 66, 8, 80, 2]; k = 3;
            answer = [8, 80, 2];
            result = solution.MostCompetitive(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            string question = "1673", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            k = 50000;
            answer = [];
            result = solution.MostCompetitive(nums, k);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: ... ..., answer: ... ...");
        }
    }
}
