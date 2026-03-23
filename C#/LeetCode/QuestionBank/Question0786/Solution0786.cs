using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0786
{
    public class Solution0786 : Interface0786
    {
        /// <summary>
        /// 暴力
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] KthSmallestPrimeFraction(int[] arr, int k)
        {
            Comparer<int[]> comparer = Comparer<int[]>.Create((x, y) => x[0] * y[1] - y[0] * x[1]);
            PriorityQueue<int[], int[]> minpq = new PriorityQueue<int[], int[]>(comparer);

            int len = arr.Length;
            for (int i = 0; i < len; i++) for (int j = i + 1; j < len; j++) minpq.Enqueue([arr[i], arr[j]], [arr[i], arr[j]]);

            while (--k > 0) minpq.Dequeue();
            return minpq.Dequeue();
        }
    }
}
