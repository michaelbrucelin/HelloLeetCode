using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2070
{
    public class Test2070
    {
        public void Test()
        {
            Interface2070 solution = new Solution2070_2();
            int[][] items; int[] queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            items = [[1, 2], [3, 2], [2, 4], [5, 6], [3, 5]]; queries = [1, 2, 3, 4, 5, 6];
            answer = [2, 4, 5, 5, 6, 6];
            result = solution.MaximumBeauty(items, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            items = [[1, 2], [1, 2], [1, 3], [1, 4]]; queries = [1];
            answer = [4];
            result = solution.MaximumBeauty(items, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            items = [[10, 1000]]; queries = [5];
            answer = [0];
            result = solution.MaximumBeauty(items, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            string question = "2070", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            items = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_items.txt"));
            queries = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.MaximumBeauty(items, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
