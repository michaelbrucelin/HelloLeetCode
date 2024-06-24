using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0503
{
    public class Test0503
    {
        public void Test()
        {
            Interface0503 solution = new Solution0503_2();
            int[] nums;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [1, 2, 1];
            answer = [2, -1, 2];
            result = solution.NextGreaterElements(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [1, 2, 3, 4, 3];
            answer = [2, 3, 4, -1, 4];
            result = solution.NextGreaterElements(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [1, 2, 3, 2, 1];
            answer = [2, 3, -1, 3, 2];
            result = solution.NextGreaterElements(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
