﻿using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1619
{
    public class Test1619
    {
        public void Test()
        {
            Interface1619 solution = new Solution1619_2();
            int[][] land;
            int[] result, answer;
            int id = 0;

            // 1. 
            land = new int[][] { new int[] { 0, 2, 1, 0 }, new int[] { 0, 1, 0, 1 }, new int[] { 1, 1, 0, 1 }, new int[] { 0, 1, 0, 1 } };
            answer = new int[] { 1, 2, 4 };
            result = solution.PondSizes(land);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            land = new int[][] {
                new int[] {2,8,8,4,1,7,1,5,4,2,0,8,1,9,2,5,6,9,7,4,8,9,1,7,3,6,9,3,7,1,5,7,3,1,9,9,9,6,5,1,9,9,4,1,6,4,7,6,1,6,1,3,3,9,0,3,0,0,0,1,3,1,2,0,0,0,3,2,7,3,6,7,9},
                new int[] {2,0,9,8,2,0,5,8,4,0,4,5,2,1,5,6,0,6,3,3,6,9,5,4,0,9,4,7,1,4,2,8,9,8,0,6,3,5,7,2,1,6,8,4,8,4,6,5,0,3,7,1,7,6,3,0,2,2,2,3,2,4,7,7,6,8,2,9,2,5,0,3,8},
                new int[] {2,7,0,1,1,3,6,5,6,0,7,0,2,4,5,0,3,7,3,1,5,7,9,8,8,0,9,8,1,9,4,7,5,6,5,4,1,7,7,4,4,3,8,3,5,3,3,8,7,4,5,4,8,0,2,0,4,7,5,4,3,9,1,9,4,9,2,2,2,4,1,2,9},
                new int[] {6,0,4,4,6,7,8,8,9,9,5,4,9,7,0,4,2,7,1,9,2,2,9,2,4,3,0,5,1,7,8,9,0,5,3,3,3,1,1,7,1,2,7,5,6,8,7,2,3,1,5,3,5,7,9,7,7,8,8,7,2,4,4,2,8,2,3,2,1,9,1,2,7},
                new int[] {2,5,1,2,2,5,8,2,8,7,4,5,9,8,9,6,0,9,7,0,5,8,8,3,3,8,1,9,4,8,2,3,4,9,1,2,4,5,1,5,4,4,6,9,2,3,3,1,2,2,4,1,2,7,4,6,9,2,3,5,9,7,7,4,9,9,4,7,1,5,5,7,6},
                new int[] {9,9,9,1,8,3,3,4,6,5,7,7,3,1,1,3,9,2,7,0,6,8,8,0,2,9,6,6,4,4,6,2,6,6,1,7,5,6,4,9,6,9,8,2,1,4,3,4,6,6,8,6,4,7,8,3,7,1,3,7,5,3,2,1,4,7,9,7,3,4,9,0,1},
                new int[] {7,1,4,9,7,2,1,9,0,9,7,4,5,3,5,2,6,5,6,0,5,0,5,3,1,1,7,9,6,2,1,8,3,4,7,4,2,1,3,5,9,7,7,5,6,1,0,3,6,3,7,9,6,5,1,4,5,7,2,3,5,3,5,2,0,9,5,1,8,6,0,0,6},
                new int[] {7,9,9,8,8,3,9,7,5,1,1,8,4,4,6,3,7,2,1,9,5,6,1,2,2,5,6,3,9,6,7,9,2,7,1,4,7,3,5,0,1,2,2,5,4,9,3,1,2,1,1,0,5,1,8,4,2,1,2,4,5,4,5,6,8,7,7,4,8,3,2,7,9},
                new int[] {6,6,6,7,0,8,7,6,2,6,3,1,4,6,6,9,6,2,0,5,4,9,9,9,8,8,6,2,4,3,1,6,6,4,4,4,3,1,8,1,8,3,9,5,2,7,0,0,4,0,6,9,2,0,3,1,6,3,0,7,9,3,9,4,3,6,7,9,8,9,4,2,7},
                new int[] {7,8,1,8,5,3,5,1,2,9,6,2,8,7,9,7,7,8,6,3,4,4,3,2,8,6,5,7,8,5,7,5,8,3,9,6,8,9,6,6,8,7,4,9,4,6,1,1,6,7,5,6,7,0,3,3,9,3,6,1,3,8,1,2,8,3,3,6,7,9,4,4,1},
                new int[] {0,7,6,7,6,4,3,1,7,8,0,0,3,1,1,7,9,2,7,9,4,9,6,2,6,6,4,0,1,8,5,6,8,1,3,8,3,7,7,9,8,4,2,8,2,5,5,9,3,3,1,6,3,1,5,2,0,4,2,2,5,4,3,4,6,7,3,4,5,1,5,7,2},
                new int[] {1,7,7,6,3,4,1,8,4,3,9,8,1,5,5,4,7,7,1,8,5,7,6,4,2,6,7,7,1,3,1,7,4,8,5,2,3,9,1,2,8,2,2,0,4,5,6,1,0,4,4,2,4,9,2,4,8,2,5,5,8,2,4,8,9,3,9,1,4,5,5,5,1},
                new int[] {0,1,1,8,9,1,0,1,3,0,5,9,3,4,1,7,1,2,1,7,3,4,2,7,2,9,9,7,4,8,7,4,2,6,7,8,8,4,9,6,5,9,6,3,0,0,0,6,4,0,9,8,1,7,0,9,9,3,7,5,8,9,4,9,9,1,2,7,5,3,2,2,3},
                new int[] {8,8,1,9,4,8,6,7,4,8,7,7,3,1,6,2,6,3,2,8,4,9,3,5,3,7,1,1,3,7,5,6,6,1,9,3,0,6,1,7,5,1,8,1,6,7,1,8,2,2,0,5,1,0,7,6,7,9,3,2,7,8,5,5,2,1,2,3,0,1,5,0,7},
                new int[] {8,1,9,4,4,5,8,3,8,5,2,3,8,4,5,6,5,0,4,0,6,7,5,5,2,7,8,5,2,1,4,9,5,1,3,4,8,7,7,3,8,5,1,5,5,9,3,9,0,0,0,8,0,4,0,5,3,8,5,1,5,0,1,7,1,3,7,4,2,9,5,5,4},
                new int[] {5,3,5,5,4,4,1,5,6,1,7,4,0,7,5,8,0,3,6,7,0,4,4,8,3,2,6,3,8,0,9,8,9,9,3,2,7,6,9,6,3,1,8,8,6,4,9,4,4,2,7,5,0,1,5,0,8,9,4,1,6,9,8,7,0,1,7,3,4,6,1,1,8},
                new int[] {1,9,5,4,1,7,0,6,3,2,1,5,3,1,8,7,5,7,6,6,8,0,3,8,8,2,5,6,7,2,7,8,2,1,5,3,9,3,5,2,2,9,4,7,8,6,7,7,9,8,6,3,0,6,9,7,3,1,9,1,9,1,5,6,3,7,1,0,8,9,9,8,1},
                new int[] {5,8,5,7,7,8,0,7,9,2,0,4,5,8,8,7,8,6,5,4,6,3,4,1,7,2,8,7,4,7,5,2,5,5,9,3,3,7,1,6,5,1,9,5,5,5,6,2,1,3,6,8,1,0,5,2,8,8,9,9,3,0,5,3,3,8,1,4,5,8,3,2,7}
            };
            answer = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 4, 6, 6, 8 };
            result = solution.PondSizes(land);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}