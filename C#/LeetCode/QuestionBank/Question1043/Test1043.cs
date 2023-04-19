using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1043
{
    public class Test1043
    {
        public void Test()
        {
            Interface1043 solution = new Solution1043_2();
            int[] arr; int k;
            int result, answer;
            int id = 0;

            // 1. 
            arr = new int[] { 1, 15, 7, 9, 2, 5, 10 }; k = 3;
            answer = 84;
            result = solution.MaxSumAfterPartitioning(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            arr = new int[] { 1, 4, 1, 5, 7, 3, 6, 1, 9, 9, 3 }; k = 4;
            answer = 83;
            result = solution.MaxSumAfterPartitioning(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            arr = new int[] { 1 }; k = 1;
            answer = 1;
            result = solution.MaxSumAfterPartitioning(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            arr = new int[] { 581920, 200100, 526972, 677934, 989025, 294832, 581857, 663919, 961334, 1881, 859626, 251114, 361905, 867006, 86001, 836946, 894279, 859796, 750025, 898166, 674980, 939280, 458563, 117387, 403337, 961067, 589597, 73584, 178968, 955900, 755634, 609754, 97612, 19699, 843950, 907919, 883083, 522938, 670930, 671679, 390248, 704834, 188158, 226340, 80496, 701795, 867627, 280988, 465918, 748627, 321025, 564279, 79716, 786173 };
            k = 23;
            answer = 52072023;
            result = solution.MaxSumAfterPartitioning(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            arr = new int[] { 1, 5, 1, 5, 7, 3, 6, 1, 9, 9, 3 }; k = 4;
            answer = 85;
            result = solution.MaxSumAfterPartitioning(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            arr = new int[] { 1, 1, 1, 5, 1, 7, 3, 6, 1, 9, 9, 3 }; k = 4;
            answer = 88;
            result = solution.MaxSumAfterPartitioning(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            arr = new int[] { 1, 1, 1, 5, 1, 7, 1, 5, 1, 1, 1 }; k = 4;
            answer = 61;
            result = solution.MaxSumAfterPartitioning(arr, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
