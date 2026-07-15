using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0229
{
    public class Test0229
    {
        public void Test()
        {
            Interface0229 solution = new Solution0229();
            int[] nums;
            IList<int> result, answer;
            int id = 0;

            // 1. 
            nums = [3, 2, 3];
            answer = [3];
            result = solution.MajorityElement(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [1];
            answer = [1];
            result = solution.MajorityElement(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [1, 2];
            answer = [1, 2];
            result = solution.MajorityElement(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            nums = [1, 2, 3, 4];
            answer = [];
            result = solution.MajorityElement(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
