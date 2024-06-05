using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3072
{
    public class Test3072
    {
        public void Test()
        {
            Interface3072 solution = new Solution3072();
            int[] nums;
            int[] result, answer;
            int id = 0;

            // 1.
            nums = [2, 1, 3, 3];
            answer = [2, 3, 1, 3];
            result = solution.ResultArray(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [5, 14, 3, 1, 2];
            answer = [5, 3, 1, 2, 14];
            result = solution.ResultArray(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [3, 3, 3, 3];
            answer = [3, 3, 3, 3];
            result = solution.ResultArray(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            nums = [47, 104, 11, 37];
            answer = [47, 11, 104, 37];
            result = solution.ResultArray(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
