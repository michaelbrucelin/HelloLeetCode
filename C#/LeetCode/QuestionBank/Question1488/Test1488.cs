using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1488
{
    public class Test1488
    {
        public void Test()
        {
            Interface1488 solution = new Solution1488_oth_2();
            int[] rains;
            int[] result, answer;
            int id = 0;

            // 1. 
            rains = [1, 2, 3, 4];
            answer = [-1, -1, -1, -1];
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            rains = [1, 2, 0, 0, 2, 1];
            answer = [-1, -1, 2, 1, -1, -1];
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            rains = [1, 2, 0, 1, 2];
            answer = [];
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            rains = [0, 1, 1];
            answer = [];
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 5. 
            rains = [1, 0, 2, 0, 3, 0, 2, 0, 0, 0, 1, 2, 3];
            answer = [-1, 1, -1, 2, -1, 3, -1, 2, 1, 1, -1, -1, -1];
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 6. 
            string question = "1488", testcase = "06";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            rains = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_rains.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[0..8])}, answer: {Utils.ToString(answer[0..8])}");

            // 7. 
            testcase = "07";
            rains = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_rains.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.AvoidFlood(rains);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result[0..8])}, answer: {Utils.ToString(answer[0..8])}");
        }
    }
}
