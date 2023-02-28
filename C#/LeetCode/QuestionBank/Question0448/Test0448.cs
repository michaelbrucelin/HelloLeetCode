using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0448
{
    public class Test0448
    {
        public void Test()
        {
            Interface0448 solution = new Solution0448();
            int[] nums;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }; answer = new int[] { 5, 6 };
            result = solution.FindDisappearedNumbers(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            nums = new int[] { 1, 1 }; answer = new int[] { 2 };
            result = solution.FindDisappearedNumbers(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            string question = "0448", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            nums = File.ReadAllText(path)[1..^1].Split(',').Select(str => int.Parse(str)).ToArray();
        }
    }
}
