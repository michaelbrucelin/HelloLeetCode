using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2008
{
    public class Test2008
    {
        public void Test()
        {
            Interface2008 solution = new Solution2008();
            int n; int[][] rides;
            long result, answer;
            int id = 0;

            // 1. 
            n = 5; rides = Utils.Str2NumArray_2d<int>("[[2,5,4],[1,5,1]]");
            answer = 7;
            result = solution.MaxTaxiEarnings(n, rides);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 20; rides = Utils.Str2NumArray_2d<int>("[[1,6,1],[3,10,2],[10,12,3],[11,12,2],[12,15,2],[13,18,1]]");
            answer = 20;
            result = solution.MaxTaxiEarnings(n, rides);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 万恶的溢出
            string question = "2008", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            n = 90000; rides = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_rides.txt"));
            answer = 2331223312;
            result = solution.MaxTaxiEarnings(n, rides);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
