﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1252
{
    public class Solution1252_2 : Interface1252
    {
        /// <summary>
        /// 本质上只要记录每一行与每一列的操作次数即可
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public int OddCells(int m, int n, int[][] indices)
        {
            int[] rows = new int[m], cols = new int[n];
            for (int i = 0; i < indices.Length; i++)
            {
                rows[indices[i][0]]++; cols[indices[i][1]]++;
            }

            int result = 0;
            for (int r = 0; r < m; r++) for (int c = 0; c < n; c++)
                {
                    result += (rows[r] + cols[c]) & 1;
                }

            return result;
        }
    }
}
