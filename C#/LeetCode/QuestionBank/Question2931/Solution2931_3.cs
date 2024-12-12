using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2931
{
    public class Solution2931_3 : Interface2931
    {
        /// <summary>
        /// 贪心 + 分治
        /// 逻辑同Solution2931，采用分治+归并排序来实现
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public long MaxSpending(int[][] values)
        {
            int[] sort = DivideAndConquer(0, values.Length - 1);
            long result = 0, len = values.Length * values[0].Length;
            long day = len - 1;
            while (day >= 0) result += sort[day] * (len - day--);

            return result;

            int[] DivideAndConquer(int i, int j)
            {
                if (i == j) return values[i];
                int mid = i + (j - i) / 2;
                int[] arr1 = DivideAndConquer(i, mid);
                int[] arr2 = DivideAndConquer(mid + 1, j);

                int len1 = arr1.Length, len2 = arr2.Length, p1 = 0, p2 = 0, p = 0;
                int[] merge = new int[len1 + len2];
                while (p1 < len1 && p2 < len2)
                {
                    if (arr1[p1] >= arr2[p2]) merge[p++] = arr1[p1++]; else merge[p++] = arr2[p2++];
                }
                while (p1 < len1) merge[p++] = arr1[p1++];
                while (p2 < len2) merge[p++] = arr2[p2++];

                return merge;
            }
        }
    }
}
