using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1144
{
    public class Test1144
    {
        public void Test()
        {
            Interface1144 solution = new Solution1144_2();
            Func<int[], int> func = ((Solution1144_2)solution).MovesToMakeZigzag;
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1, 2, 3 };
            answer = 2;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 9, 6, 1, 6, 2 };
            answer = 4;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 10, 4, 4, 10, 10, 6, 2, 3 };
            answer = 13;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 2, 7, 10, 9, 8, 9 };
            answer = 4;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
