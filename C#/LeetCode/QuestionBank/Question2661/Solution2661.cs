using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2661
{
    public class Solution2661 : Interface2661
    {
        /// <summary>
        /// 哈希
        /// 1. 遍历矩阵mat，记录下每个值与坐标的对应关系
        /// 2. 创建两个数组int[rcnt] mask_r, int[ccnt] mask_c，分别记录每一行每一列的涂色情况
        /// 3. 遍历数组arr，假定遍历到第i项，值是val，val在mat中的坐标为r, c
        ///     mask_r[r]++; if(mask_r[r] == ccnt) return i;
        ///     mask_c[c]++; if(mask_c[c] == rcnt) return i;
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int FirstCompleteIndex(int[] arr, int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            if (rcnt == 1 || ccnt == 1) return 0;

            (int r, int c)[] map = new (int r, int c)[rcnt * ccnt + 1];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) map[mat[r][c]] = (r, c);

            int[] mask_r = new int[rcnt], mask_c = new int[ccnt];
            int cnt = arr.Length;
            for (int i = 0, r, c; i < cnt; i++)
            {
                r = map[arr[i]].r; c = map[arr[i]].c;
                mask_r[r]++; if (mask_r[r] == ccnt) return i;
                mask_c[c]++; if (mask_c[c] == rcnt) return i;
            }

            return -1;
        }
    }
}
