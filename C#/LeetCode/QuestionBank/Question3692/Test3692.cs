using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3692
{
    public class Test3692
    {
        public void Test()
        {
            Interface3692 solution = new Solution3692();
            string s;
            string result, answer;
            int id = 0;

            // 1. 
            s = "aaabbbccdddde";
            answer = "ab";
            result = solution.MajorityFrequencyGroup(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result.ToCharArray(), answer.ToCharArray(), true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            s = "abcd";
            answer = "abcd";
            result = solution.MajorityFrequencyGroup(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result.ToCharArray(), answer.ToCharArray(), true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            s = "pfpfgi";
            answer = "fp";
            result = solution.MajorityFrequencyGroup(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result.ToCharArray(), answer.ToCharArray(), true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
