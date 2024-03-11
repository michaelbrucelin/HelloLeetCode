using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1001
{
    public class Solution1001 : Interface1001
    {
        /// <summary>
        /// 三指针
        /// </summary>
        /// <param name="A"></param>
        /// <param name="m"></param>
        /// <param name="B"></param>
        /// <param name="n"></param>
        public void Merge(int[] A, int m, int[] B, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (i >= 0 && j >= 0) A[k--] = A[i] > B[j] ? A[i--] : B[j--];
            for (; i >= 0; i--, k--) A[k] = A[i];
            for (; j >= 0; j--, k--) A[k] = B[j];
        }
    }
}
