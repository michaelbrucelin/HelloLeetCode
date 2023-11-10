using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2300
{
    public class Test2300
    {
        public void Test()
        {
            Interface2300 solution = new Solution2300();
            int[] spells, potions; long success;
            int[] result, answer;
            int id = 0;

            // 1. 
            spells = Utils.Str2NumArray<int>("[5,1,3]");
            potions = Utils.Str2NumArray<int>("[1,2,3,4,5]");
            success = 7;
            answer = Utils.Str2NumArray<int>("[4,0,3]");
            result = solution.SuccessfulPairs(spells, potions, success);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            spells = Utils.Str2NumArray<int>("[3,1,2]");
            potions = Utils.Str2NumArray<int>("[8,5,8]");
            success = 16;
            answer = Utils.Str2NumArray<int>("[2,0,2]");
            result = solution.SuccessfulPairs(spells, potions, success);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "2300", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            spells = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_spells.txt"));
            potions = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_potions.txt"));
            success = 9505642132;
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.SuccessfulPairs(spells, potions, success);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            testcase = "04";
            spells = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_spells.txt"));
            potions = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_potions.txt"));
            success = 2966799365;
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.SuccessfulPairs(spells, potions, success);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
