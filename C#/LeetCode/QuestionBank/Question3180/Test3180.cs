using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3180
{
    public class Test3180
    {
        public void Test()
        {
            Interface3180 solution3180 = new Solution3180();
            int[] rewardValues;
            int result, answer;
            int id = 0;

            // 1. 
            string question = "3180", testcase = "01";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            rewardValues = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_rewardValues.txt"));
            answer = 3999;
            result = solution3180.MaxTotalReward(rewardValues);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
