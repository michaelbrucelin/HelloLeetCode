﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1547
{
    public class Test1547
    {
        public void Test()
        {
            Interface1547 solution = new Solution1547_2();
            int n; int[] cuts;
            int result, answer;
            int id = 0;

            // 1. 
            n = 7; cuts = [1, 3, 4, 5];
            answer = 16;
            result = solution.MinCost(n, cuts);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            n = 9; cuts = [5, 6, 1, 4, 2];
            answer = 22;
            result = solution.MinCost(n, cuts);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            n = 6448;
            cuts = [3309, 5839, 4626, 4670, 5971, 6426, 5561, 2835, 3474, 3539, 1880, 4123, 571, 3128, 4075, 5896, 5020, 207, 3529, 5435, 2440, 3993, 5885, 2145, 2422, 3379, 949, 248,
                    2627, 3392, 1795, 4893, 4415, 3282, 1776, 5520, 2199, 57, 3098, 968, 1310, 4870, 5503, 1336, 636, 4747, 1371, 854, 2882, 5976, 5409, 3173, 5256, 4960, 2662, 508,
                    1625, 304, 5867, 5939, 2499, 2845, 744, 6252, 5320, 3552, 4790, 6112, 3535, 4783, 6194, 4248, 1886, 3264, 3221, 407, 1954, 1731, 3318, 6213, 1299, 5206, 3753];
            answer = 38663;
            result = solution.MinCost(n, cuts);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
