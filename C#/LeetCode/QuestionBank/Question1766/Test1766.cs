﻿using LeetCode.QuestionBank.Question1483;
using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1766
{
    public class Test1766
    {
        public void Test()
        {
            Interface1766 solution = new Solution1766();
            int[] nums; int[][] edges;
            int[] result, answer;
            int id = 0;

            // 1. 
            nums = [2, 3, 3, 2]; edges = [[0, 1], [1, 2], [1, 3]];
            answer = [-1, 0, 0, 1];
            result = solution.GetCoprimes(nums, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            nums = [5, 6, 10, 2, 3, 6, 15]; edges = [[0, 1], [0, 2], [1, 3], [1, 4], [2, 5], [2, 6]];
            answer = [-1, 0, -1, 0, 0, 0, -1];
            result = solution.GetCoprimes(nums, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            nums = [18, 10, 23, 47, 11, 20, 7, 44, 14, 43, 43, 42, 2, 23, 5, 31, 18, 40, 49, 27, 50, 21, 19, 35, 23, 30, 31, 8, 7, 50, 7, 11, 4, 43, 1, 5, 24, 44, 24,
                    25, 24, 19, 48, 5, 37, 13, 50, 6, 20, 38, 43, 45, 34, 15, 42, 41, 5, 44, 16, 21, 26, 31, 12, 35, 13, 36, 2, 21, 29, 36, 7, 24, 1, 37, 40, 6, 19,
                    30, 12, 42, 30, 50, 20, 15, 34, 36, 49, 2, 34, 36, 38, 8, 11, 33, 46, 19, 24, 41, 2, 31, 14, 32, 9, 29, 12, 6, 45, 47, 32, 24, 37, 4, 25, 50, 24,
                    10, 31, 40, 5, 12, 22, 7, 23, 2, 27, 42, 8, 6, 1, 15, 16, 32, 32, 38, 29, 24, 33, 22, 33, 29, 17];
            edges = [[57, 0], [5, 57], [76, 5], [85, 76], [46, 85], [127, 85], [25, 0], [114, 25], [7, 114], [45, 114], [100, 25], [122, 100], [17, 122], [12, 17],
                     [48, 100], [40, 48], [60, 40], [88, 48], [108, 48], [10, 108], [11, 10], [121, 11], [9, 121], [109, 11], [111, 109], [91, 109], [118, 91], [53, 118],
                     [26, 53], [47, 26], [126, 47], [133, 109], [123, 133], [59, 123], [81, 48], [31, 81], [15, 31], [24, 15], [132, 81], [119, 132], [21, 119], [63, 81],
                     [128, 63], [73, 128], [34, 63], [72, 34], [38, 72], [97, 72], [3, 97], [30, 3], [13, 30], [80, 13], [33, 80], [66, 80], [102, 66], [8, 80], [77, 8],
                     [79, 77], [42, 79], [19, 42], [78, 19], [20, 78], [55, 79], [37, 55], [49, 37], [89, 49], [36, 89], [83, 89], [95, 49], [64, 95], [28, 64], [32, 28],
                     [92, 32], [93, 92], [86, 93], [39, 86], [87, 39], [2, 87], [134, 93], [135, 49], [110, 3], [29, 110], [52, 29], [136, 29], [99, 136], [50, 99],
                     [84, 50], [56, 84], [51, 99], [112, 51], [101, 112], [41, 29], [74, 41], [103, 74], [129, 74], [6, 129], [137, 129], [61, 29], [104, 61], [131, 104],
                     [58, 104], [14, 58], [18, 14], [138, 18], [117, 138], [125, 138], [106, 125], [120, 18], [130, 120], [124, 130], [62, 124], [82, 62], [4, 62], [113, 4],
                     [139, 130], [1, 104], [67, 1], [70, 1], [43, 70], [96, 70], [98, 96], [69, 98], [94, 69], [115, 94], [75, 1], [44, 75], [68, 44], [16, 68], [54, 68],
                     [65, 68], [27, 65], [71, 65], [105, 65], [35, 105], [107, 65], [116, 65], [90, 116], [23, 90], [140, 1], [22, 140]];
            answer = [-1, 61, 87, 97, 62, -1, 129, -1, 13, 121, 108, 10, 122, 30, 58, 31, 68, 122, 14, 8, 19, 132, 140, 90, 15, -1, 53, 68, 64, 110, 3, 81, 28, 80, 63,
                      105, 55, 55, 72, 86, -1, 29, 13, 70, 75, 114, 76, 26, -1, 55, 99, 99, 110, 91, 68, 79, 84, -1, 61, 123, -1, 29, 18, 0, 95, 68, 13, 1, 44, 70, 1, 68,
                      34, 128, 41, 61, 5, 13, 13, 13, 13, -1, 124, 49, 50, 76, 93, 39, -1, 55, 116, 10, 32, 32, 70, 37, 70, 72, 70, 136, -1, 112, 66, 74, 61, 68, 18, 65,
                      -1, 10, 3, 10, 99, 4, -1, 70, 65, 138, 91, -1, 18, 10, 100, 10, 130, 14, 26, 76, 63, 41, 18, 61, -1, 10, 93, 55, 29, 129, 18, 130, 1];
            result = solution.GetCoprimes(nums, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            string question = "1766", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            nums = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_nums.txt"));
            edges = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_edges.txt"));
            answer = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.GetCoprimes(nums, edges);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result).Substring(0, 10)} ... ..., answer: {Utils.ToString(answer).Substring(0, 10)} ... ...");
        }
    }
}
