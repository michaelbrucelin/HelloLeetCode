using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0238
{
    public class Test0238
    {
        public void Test()
        {
            Interface0238 solution = new Solution0238();
            int[] nums;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 3, 4];
            answer = [24, 12, 8, 6];
            result = solution.ProductExceptSelf(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [-1, 1, 0, -3, 3];
            answer = [0, 0, 9, 0, 0];
            result = solution.ProductExceptSelf(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
