using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1886
{
    public class Solution1886 : Interface1886
    {
        /// <summary>
        /// 模拟
        /// 最多旋转3次即可
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool FindRotation(int[][] mat, int[][] target)
        {
            if (Compare(mat, target)) return true;
            for (int i = 0; i < 3; i++)
                if (Compare(mat = Rotation(mat), target)) return true;

            return false;
        }

        private int[][] Rotation(int[][] mat)
        {
            int n = mat.Length;
            int[][] result = new int[n][];
            for (int r = 0; r < n; r++)
            {
                result[r] = new int[n];
                for (int c = 0; c < n; c++)
                    result[r][c] = mat[n - c - 1][r];
            }

            return result;
        }

        private bool Compare(int[][] arr1, int[][] arr2)
        {
            int n = arr1.Length;
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++)
                    if (arr1[r][c] != arr2[r][c]) return false;

            return true;
        }
    }
}
