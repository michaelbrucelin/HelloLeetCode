using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1329
{
    public class Solution1329_2 : Interface1329
    {
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[][] DiagonalSort(int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            if (rcnt == 1 || ccnt == 1) return mat;

            int len = Math.Min(rcnt, ccnt); const int max = 101;  // 哨兵
            int[] buffer = new int[len];
            for (int c = 0, _i; c < ccnt; c++)
            {
                _i = 0;
                for (int _r = 0, _c = c; _r < rcnt && _c < ccnt; _r++, _c++, _i++) buffer[_i] = mat[_r][_c];
                for (; _i < len; _i++) buffer[_i] = max;
                CountSort(buffer, max);
                _i = 0;
                for (int _r = 0, _c = c; _r < rcnt && _c < ccnt; _r++, _c++, _i++) mat[_r][_c] = buffer[_i];
            }
            for (int r = 1, _i; r < rcnt; r++)
            {
                _i = 0;
                for (int _r = r, _c = 0; _r < rcnt && _c < ccnt; _r++, _c++, _i++) buffer[_i] = mat[_r][_c];
                for (; _i < len; _i++) buffer[_i] = max;
                CountSort(buffer, max);
                _i = 0;
                for (int _r = r, _c = 0; _r < rcnt && _c < ccnt; _r++, _c++, _i++) mat[_r][_c] = buffer[_i];
            }

            return mat;
        }

        private void CountSort(int[] array, int max)
        {
            int[] freq = new int[max + 1];
            for (int i = 0; i < array.Length; i++) freq[array[i]]++;
            for (int i = 0, p = 0; i <= max; i++) if (freq[i] > 0)
                {
                    for (int j = 0; j < freq[i]; j++) array[p++] = i;
                }
        }
    }
}
