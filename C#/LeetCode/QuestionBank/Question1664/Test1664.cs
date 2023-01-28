using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1664
{
    public class Test1664
    {
        public void Test()
        {
            Interface1664 solution = new Solution1664_3_1();
            Func<int[], int> func = solution.WaysToMakeFair;
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 2, 1, 6, 4 }; answer = 1;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 1, 1 }; answer = 3;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 1, 2, 3 }; answer = 0;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 1, 1 }; answer = 0;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 1 }; answer = 1;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            nums = new int[] { 543, 191, 316, 402, 999, 912, 896, 51, 620, 555, 955, 632, 56, 705, 970, 397, 883, 888, 878, 786, 139, 281, 496, 310, 741, 631, 312, 148, 828, 224, 539, 933, 571, 964, 967, 679, 895, 735, 502, 478, 380, 631, 922, 170, 913, 207, 360, 540, 833, 685, 125, 394, 457, 525, 932, 248, 353, 958, 939, 957, 514, 665, 477, 289, 775, 451, 481, 977, 168, 67, 139, 211, 938, 539, 85, 272, 301, 505, 724, 834, 337, 958, 592, 215, 959, 914, 655, 177, 103, 176, 886, 114, 140, 697, 437, 328, 93, 710, 435, 378 };
            answer = 0;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            nums = new int[] { 2, 7, 10, 10, 4, 10, 10, 10, 4, 10, 6, 5, 8, 4, 8, 2, 1, 8, 1, 8, 8, 1, 1, 8, 3, 9, 10, 4, 3, 1, 6, 4, 2, 1, 2, 5, 6, 3, 8, 9, 3, 10, 3, 1, 4, 4, 2, 4, 4, 10, 10, 3, 8, 10, 8, 3, 7, 7, 1, 5, 6, 4, 5, 1, 5, 6, 7, 5, 9, 2, 2, 2, 1, 2, 3, 5, 1, 6, 7, 3, 4, 6, 5, 8, 5, 8, 6, 10, 3, 2, 6, 5, 5, 9, 5, 6, 6, 9, 6, 10 };
            answer = 2;
            result = func(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
