using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3597
{
    public class Test3597
    {
        public void Test()
        {
            Interface3597 solution = new Solution3597_2();
            string s;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            s = "abbccccd";
            answer = ["a", "b", "bc", "c", "cc", "d"];
            result = solution.PartitionString(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            s = "aaaa";
            answer = ["a", "aa"];
            result = solution.PartitionString(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
