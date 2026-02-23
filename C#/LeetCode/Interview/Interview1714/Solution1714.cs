using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1714
{
    public class Solution1714 : Interface1714
    {
        /// <summary>
        /// 大顶堆
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] SmallestK(int[] arr, int k)
        {
            if (k == arr.Length) return arr;

            int len = arr.Length;
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            for (int i = 0; i < k; i++) maxpq.Enqueue(arr[i], -arr[i]);
            for (int i = k; i < len; i++)
            {
                maxpq.Enqueue(arr[i], -arr[i]);
                if (maxpq.Count > k) maxpq.Dequeue();
            }

            int[] result = new int[k];
            for (int i = 0; i < k; i++) result[i] = maxpq.Dequeue();

            return result;
        }
    }
}
