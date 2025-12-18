using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0763
{
    public class Test0763
    {
        public void Test()
        {
            Interface0763 solution = new Solution0763_2();
            string s;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            s = "ababcbacadefegdehijhklij";
            answer = [9, 7, 8];
            result = solution.PartitionLabels(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            s = "eccbbbbdec";
            answer = [10];
            result = solution.PartitionLabels(s);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
