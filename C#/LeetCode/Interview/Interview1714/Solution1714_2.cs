using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1714
{
    public class Solution1714_2 : Interface1714
    {
        /// <summary>
        /// 快速选择
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] SmallestK(int[] arr, int k)
        {
            if (k == arr.Length) return arr;

            int p, lo = 0, hi = arr.Length - 1;
            while ((p = partition(lo, hi)) != k) if (p < k) lo = p + 1; else hi = p - 1;

            return arr[0..k];

            int partition(int lo, int hi)
            {
                int v = arr[lo], t, i = lo, j = hi + 1;
                while (true)
                {
                    while (arr[++i] < v) if (i == hi) break;
                    while (arr[--j] > v) ;                    // if (j == lo) break;
                    if (i >= j) break;
                    t = arr[i]; arr[i] = arr[j]; arr[j] = t;
                }
                arr[lo] = arr[j]; arr[j] = v;

                return j;
            }
        }
    }
}
