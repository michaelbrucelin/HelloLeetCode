﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3219
{
    public class Test3219
    {
        public void Test()
        {
            Interface3219 solution = new Solution3219_2();
            int m, n; int[] horizontalCut, verticalCut;
            long result, answer;
            int id = 0;

            // 1. 
            m = 3; n = 2; horizontalCut = [1, 3]; verticalCut = [5];
            answer = 13;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            m = 2; n = 2; horizontalCut = [7]; verticalCut = [4];
            answer = 15;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            m = 9; n = 8; horizontalCut = [7, 7, 4, 3, 1, 2, 3, 5]; verticalCut = [2, 3, 1, 1, 2, 2, 1];
            answer = 134;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            m = 1; n = 7; horizontalCut = []; verticalCut = [2, 1, 2, 1, 2, 1];
            answer = 9;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            m = 6; n = 3; horizontalCut = [2, 3, 2, 3, 1]; verticalCut = [1, 2];
            answer = 28;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            m = 3; n = 6; horizontalCut = [1, 2]; verticalCut = [2, 3, 2, 3, 1];
            answer = 28;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            m = 29;
            n = 650;
            horizontalCut = [175, 2, 12, 135, 140, 270, 222, 110, 93, 15, 30, 198, 243, 163, 103, 143, 157, 136, 50, 249, 96, 105, 232, 131, 1, 77, 187, 86];
            verticalCut = [47, 178, 27, 28, 202, 98, 210, 76, 118, 226, 226, 202, 70, 265, 189, 179, 27, 248, 251, 161, 176, 29, 225, 41, 143, 166, 97, 216, 135, 145, 215, 12, 119, 34, 183, 244, 118, 60, 178, 58, 78, 88, 257, 111,
                243, 246, 235, 153, 267, 64, 185, 104, 143, 250, 265, 179, 101, 226, 25, 199, 184, 146, 167, 9, 238, 227, 13, 17, 148, 227, 245, 164, 212, 109, 217, 263, 141, 211, 192, 55, 21, 202, 7, 37, 268, 158, 29, 266, 156, 260,
                159, 249, 168, 159, 11, 120, 211, 65, 121, 232, 122, 85, 219, 116, 178, 257, 152, 116, 170, 181, 4, 3, 162, 131, 187, 203, 27, 196, 247, 4, 204, 87, 259, 232, 191, 133, 129, 217, 72, 48, 134, 104, 121, 76, 234, 139,
                257, 28, 27, 262, 18, 64, 114, 45, 170, 59, 99, 128, 62, 145, 237, 80, 149, 225, 268, 152, 270, 116, 96, 69, 270, 220, 264, 128, 254, 195, 210, 215, 208, 257, 167, 254, 113, 232, 4, 233, 134, 69, 217, 130, 247, 197,
                204, 86, 57, 217, 42, 31, 84, 234, 93, 27, 251, 75, 199, 18, 80, 41, 229, 37, 85, 210, 126, 7, 240, 161, 100, 4, 162, 190, 169, 122, 99, 242, 94, 251, 202, 185, 131, 62, 44, 115, 105, 147, 179, 14, 147, 270, 50, 41,
                118, 59, 257, 136, 16, 110, 194, 93, 9, 265, 235, 90, 78, 136, 239, 16, 91, 186, 25, 176, 187, 158, 71, 120, 137, 80, 172, 228, 121, 78, 216, 14, 20, 247, 125, 218, 208, 116, 43, 71, 48, 36, 164, 197, 211, 16, 93, 247,
                178, 202, 77, 83, 91, 6, 178, 71, 162, 260, 229, 80, 195, 136, 144, 126, 98, 105, 180, 196, 161, 81, 213, 144, 32, 188, 78, 144, 189, 131, 146, 185, 172, 216, 112, 195, 126, 206, 259, 52, 35, 83, 258, 31, 110, 48, 243,
                208, 120, 109, 156, 88, 159, 89, 137, 55, 56, 178, 108, 260, 197, 136, 91, 22, 108, 117, 195, 208, 191, 80, 66, 78, 243, 155, 55, 71, 93, 6, 243, 270, 192, 93, 53, 215, 17, 173, 71, 3, 248, 125, 209, 160, 147, 231, 33,
                186, 157, 69, 28, 182, 24, 77, 181, 94, 113, 46, 76, 14, 166, 144, 264, 213, 262, 68, 216, 239, 192, 122, 171, 247, 74, 252, 141, 185, 242, 107, 236, 211, 57, 158, 53, 187, 33, 131, 77, 227, 180, 75, 117, 114, 254, 13,
                233, 86, 127, 187, 196, 147, 239, 188, 196, 48, 27, 148, 186, 72, 52, 165, 194, 10, 219, 27, 5, 19, 80, 50, 77, 153, 50, 40, 7, 154, 231, 70, 14, 210, 203, 3, 49, 116, 20, 242, 131, 61, 128, 51, 184, 185, 132, 84, 197,
                146, 261, 5, 95, 260, 72, 120, 101, 235, 223, 68, 138, 126, 139, 164, 133, 27, 152, 232, 184, 166, 5, 157, 241, 176, 9, 26, 158, 63, 88, 174, 67, 7, 37, 216, 210, 7, 80, 4, 246, 176, 115, 16, 4, 244, 92, 150, 93, 262,
                82, 47, 231, 251, 116, 102, 205, 102, 109, 252, 76, 102, 1, 197, 138, 130, 157, 231, 270, 234, 85, 263, 12, 126, 115, 82, 188, 218, 214, 3, 233, 81, 91, 252, 78, 255, 70, 243, 261, 231, 233, 57, 86, 99, 232, 146, 220,
                167, 72, 224, 126, 182, 70, 135, 34, 183, 156, 191, 48, 17, 171, 232, 4, 58, 136, 109, 73, 264, 28, 242, 102, 213, 194, 208, 143, 191, 58, 40, 204, 239, 137, 250, 25, 253, 158, 175, 18, 136, 223, 64, 67, 131, 19, 206,
                206, 83, 208, 75, 114, 122, 74, 1, 101, 144, 17, 218, 195, 225, 126, 60, 218, 69, 46, 20, 197, 147, 7, 72, 268, 250, 243, 58, 47, 1, 17, 251, 270, 197, 87, 39, 34];
            answer = 1684958;
            result = solution.MinimumCost(m, n, horizontalCut, verticalCut);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}