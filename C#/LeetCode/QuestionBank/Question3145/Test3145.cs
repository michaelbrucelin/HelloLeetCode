using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3145
{
    public class Test3145
    {
        public void Test()
        {
            Interface3145 solution = new Solution3145();
            long[][] queries;
            int[] result, answer;
            int id = 0;

            // 1. 
            queries = [[1, 3, 7]];
            answer = [4];
            result = solution.FindProductsOfElements(queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            queries = [[2, 5, 3], [7, 7, 4]];
            answer = [2, 2];
            result = solution.FindProductsOfElements(queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            queries = [[0, 0, 14]];
            answer = [1];
            result = solution.FindProductsOfElements(queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            queries = [[5, 5, 2]];
            answer = [1];
            result = solution.FindProductsOfElements(queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            string question = "3145", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            queries = Utils.Str2NumArray_2d<long>(File.ReadAllText($"{path}_{testcase}_queries.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.FindProductsOfElements(queries);
            // Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[..10])} ..., answer: {Utils.ToString(answer[..10])} ...");
        }
    }
}
