using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2106
{
    public class Test2106
    {
        public void Test()
        {
            Interface2106 solution = new Solution2106_4();
            int[][] fruits; int startPos, k;
            int result, answer;
            int id = 0;

            // 1. 
            fruits = new int[][] { new int[] { 2, 8 }, new int[] { 6, 3 }, new int[] { 8, 6 } }; startPos = 5; k = 4;
            answer = 9;
            result = solution.MaxTotalFruits(fruits, startPos, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            fruits = new int[][] { new int[] { 0, 9 }, new int[] { 4, 1 }, new int[] { 5, 7 }, new int[] { 6, 2 }, new int[] { 7, 4 }, new int[] { 10, 9 } }; startPos = 5; k = 4;
            answer = 14;
            result = solution.MaxTotalFruits(fruits, startPos, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            fruits = new int[][] { new int[] { 0, 3 }, new int[] { 6, 4 }, new int[] { 8, 5 } }; startPos = 3; k = 2;
            answer = 0;
            result = solution.MaxTotalFruits(fruits, startPos, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            fruits = new int[][] { new int[] { 1060, 577 }, new int[] { 1155, 4703 }, new int[] { 1243, 590 }, new int[] { 1366, 4535 }, new int[] { 1483, 4010 }, new int[] { 1612, 6288 }, new int[] { 1617, 5807 }, new int[] { 1654, 7620 }, new int[] { 1738, 9269 }, new int[] { 1753, 674 }, new int[] { 1774, 8056 }, new int[] { 1864, 1266 }, new int[] { 1930, 8493 }, new int[] { 1975, 136 }, new int[] { 2031, 9733 }, new int[] { 2040, 2290 }, new int[] { 2060, 971 }, new int[] { 2075, 2168 }, new int[] { 2271, 8605 }, new int[] { 2356, 3652 }, new int[] { 2389, 372 }, new int[] { 2395, 5399 }, new int[] { 2441, 5821 }, new int[] { 2443, 9224 }, new int[] { 2494, 4962 }, new int[] { 2507, 7073 }, new int[] { 2684, 507 }, new int[] { 2765, 6223 }, new int[] { 2876, 3602 }, new int[] { 2905, 1351 }, new int[] { 3262, 3093 }, new int[] { 3474, 1224 }, new int[] { 3535, 8688 }, new int[] { 3543, 8930 }, new int[] { 3584, 9449 }, new int[] { 3608, 9841 }, new int[] { 3654, 3752 }, new int[] { 3689, 4732 }, new int[] { 3710, 3422 }, new int[] { 3816, 4946 }, new int[] { 3993, 3160 }, new int[] { 4031, 8656 }, new int[] { 4086, 2920 }, new int[] { 4163, 3618 }, new int[] { 4204, 8008 }, new int[] { 4205, 3857 }, new int[] { 4374, 5203 }, new int[] { 4423, 9151 }, new int[] { 4428, 6870 }, new int[] { 4482, 4646 }, new int[] { 4648, 5974 }, new int[] { 4692, 3845 }, new int[] { 4702, 40 }, new int[] { 4855, 5000 }, new int[] { 4873, 8112 }, new int[] { 5072, 1096 }, new int[] { 5243, 857 }, new int[] { 5433, 4260 }, new int[] { 5471, 1722 }, new int[] { 5479, 7220 }, new int[] { 5485, 8352 }, new int[] { 5501, 17 }, new int[] { 5509, 5546 }, new int[] { 5530, 5146 }, new int[] { 5554, 6626 }, new int[] { 5680, 5466 }, new int[] { 5722, 2083 }, new int[] { 5739, 7025 }, new int[] { 6161, 239 }, new int[] { 6210, 9177 }, new int[] { 6267, 8749 }, new int[] { 6288, 2860 }, new int[] { 6372, 4124 }, new int[] { 6381, 4651 }, new int[] { 6416, 4200 }, new int[] { 6481, 7002 }, new int[] { 6534, 7615 }, new int[] { 6572, 7503 }, new int[] { 6674, 1234 }, new int[] { 6732, 1627 }, new int[] { 6765, 8245 }, new int[] { 6774, 7526 }, new int[] { 6776, 4034 }, new int[] { 6868, 3198 }, new int[] { 6928, 7160 }, new int[] { 6960, 1604 }, new int[] { 7101, 7070 }, new int[] { 7144, 8126 }, new int[] { 7228, 6550 }, new int[] { 7291, 867 }, new int[] { 7389, 5365 }, new int[] { 7468, 3143 }, new int[] { 7482, 5700 }, new int[] { 7729, 1000 }, new int[] { 7803, 762 }, new int[] { 7807, 9658 }, new int[] { 7813, 477 }, new int[] { 7825, 5914 }, new int[] { 8135, 1619 }, new int[] { 8201, 2661 }, new int[] { 8231, 4020 }, new int[] { 8295, 5096 }, new int[] { 8614, 9731 }, new int[] { 8616, 1461 }, new int[] { 8619, 7263 }, new int[] { 8675, 1334 }, new int[] { 8695, 5425 }, new int[] { 8840, 9366 }, new int[] { 8904, 2341 }, new int[] { 9005, 531 }, new int[] { 9248, 2857 }, new int[] { 9349, 6923 }, new int[] { 9361, 6035 }, new int[] { 9426, 1309 }, new int[] { 9546, 2222 }, new int[] { 9570, 7522 }, new int[] { 9589, 3642 }, new int[] { 9612, 7496 }, new int[] { 9797, 7743 }, new int[] { 9813, 6949 }, new int[] { 9877, 1872 }, new int[] { 9905, 6133 } };
            startPos = 5500; k = 8785;
            answer = 466040;
            result = solution.MaxTotalFruits(fruits, startPos, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            fruits = new int[][] { new int[] { 200000, 10000 } }; startPos = 0; k = 0;
            answer = 0;
            result = solution.MaxTotalFruits(fruits, startPos, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            fruits = new int[][] { new int[] { 1, 2 }, new int[] { 3, 5 }, new int[] { 6, 10 }, new int[] { 7, 3 }, new int[] { 8, 6 }, new int[] { 9, 3 }, new int[] { 10, 8 }, new int[] { 12, 9 }, new int[] { 16, 2 }, new int[] { 18, 3 }, new int[] { 20, 2 }, new int[] { 26, 5 }, new int[] { 27, 7 }, new int[] { 29, 10 }, new int[] { 30, 4 }, new int[] { 31, 7 }, new int[] { 33, 3 }, new int[] { 34, 2 }, new int[] { 35, 10 }, new int[] { 39, 5 } };
            startPos = 39; k = 10;
            answer = 41;
            result = solution.MaxTotalFruits(fruits, startPos, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            fruits = new int[][] { new int[] { 0, 96 }, new int[] { 1, 72 }, new int[] { 4, 80 }, new int[] { 5, 30 }, new int[] { 6, 40 }, new int[] { 7, 35 }, new int[] { 8, 9 }, new int[] { 10, 47 }, new int[] { 11, 47 }, new int[] { 16, 90 }, new int[] { 17, 14 }, new int[] { 18, 49 }, new int[] { 19, 71 }, new int[] { 20, 35 }, new int[] { 21, 98 }, new int[] { 23, 22 }, new int[] { 24, 84 }, new int[] { 25, 78 }, new int[] { 26, 29 }, new int[] { 27, 36 }, new int[] { 28, 84 }, new int[] { 29, 68 }, new int[] { 30, 60 }, new int[] { 36, 3 }, new int[] { 37, 14 }, new int[] { 38, 38 }, new int[] { 40, 80 }, new int[] { 41, 78 }, new int[] { 44, 12 }, new int[] { 47, 30 }, new int[] { 49, 8 }, new int[] { 50, 82 }, new int[] { 52, 78 }, new int[] { 53, 1 }, new int[] { 54, 9 }, new int[] { 56, 4 }, new int[] { 57, 92 }, new int[] { 58, 78 }, new int[] { 59, 75 }, new int[] { 60, 43 }, new int[] { 61, 100 }, new int[] { 63, 3 }, new int[] { 64, 64 }, new int[] { 66, 44 }, new int[] { 67, 61 }, new int[] { 68, 88 }, new int[] { 69, 14 }, new int[] { 73, 89 }, new int[] { 75, 21 }, new int[] { 77, 93 }, new int[] { 78, 91 }, new int[] { 80, 18 }, new int[] { 84, 7 }, new int[] { 85, 56 }, new int[] { 86, 100 }, new int[] { 87, 69 }, new int[] { 88, 89 }, new int[] { 90, 31 }, new int[] { 92, 66 }, new int[] { 94, 80 }, new int[] { 96, 94 }, new int[] { 98, 91 }, new int[] { 99, 33 }, new int[] { 100, 14 } };
            startPos = 0; k = 1;
            answer = 168;
            result = solution.MaxTotalFruits(fruits, startPos, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
