using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1819
{
    public class Test1819
    {
        public void Test()
        {
            Interface1819 solution = new Solution1819_3();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 6, 10, 3 }; answer = 5;
            result = solution.CountDifferentSubsequenceGCDs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 5, 15, 40, 5, 6 }; answer = 7;
            result = solution.CountDifferentSubsequenceGCDs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 4296, 4062, 7932, 7534, 6474, 4787, 3090, 2817, 3603, 1211 };
            answer = 15;
            result = solution.CountDifferentSubsequenceGCDs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 5022, 4949, 1327, 6749, 8779, 4978, 727, 6432, 8460, 1420, 7598, 2422, 6213, 5020, 1157, 6601, 4113, 1665, 2002, 8031, 7690, 4182, 6012, 4064, 6937, 7956, 6822, 1085, 3437, 1925, 3748, 995 };
            answer = 58;
            result = solution.CountDifferentSubsequenceGCDs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 915, 446, 247, 416, 113, 788, 324, 375, 748, 185, 585, 660, 664, 247, 229, 57, 84, 841, 108, 222, 480, 791, 771, 848, 213, 178, 272, 719, 404, 837, 235, 201, 311, 74, 265, 326, 393, 829, 507, 272, 440, 533, 550, 123, 686, 644, 605, 662, 342, 658, 83, 422, 643, 503, 653, 467, 236, 713, 339, 631, 470, 442, 365, 231, 865, 604, 855, 688, 181, 893, 826, 39, 972, 302, 982, 564, 503, 474, 18, 45, 542, 771, 326, 207, 950, 656, 510, 679, 978, 41, 100, 789, 934, 410, 810, 663, 524, 216, 439, 550 };
            answer = 148;
            result = solution.CountDifferentSubsequenceGCDs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
