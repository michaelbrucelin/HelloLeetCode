using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3769
{
    public class Test3769
    {
        public void Test()
        {
            Interface3769 solution = new Solution3769();
            int[] nums;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [4, 5, 4];
            answer = [4, 4, 5];
            result = solution.SortByReflection(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [3, 6, 5, 8];
            answer = [8, 3, 6, 5];
            result = solution.SortByReflection(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [93, 87];
            answer = [93, 87];
            result = solution.SortByReflection(nums);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
