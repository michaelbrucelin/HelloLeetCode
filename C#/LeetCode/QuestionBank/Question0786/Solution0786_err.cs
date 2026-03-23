using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0786
{
    public class Solution0786_err : Interface0786
    {
        /// <summary>
        /// 暴力
        /// 逻辑同Solution0786，略加优化，观察下面规律
        /// 1. 最小的   arr0/arr{n-1}
        /// 2. 后面两个 arr0/arr{n-2}, arr1/arr{n-1}                 注意，这2个值的顺序未定
        /// 3. 后面两个 arr0/arr{n-3}, arr1/arr{n-2}, arr2/arr{n-1}  注意，这3个值的顺序未定
        /// ... ...
        /// 这样可以O(1)的计算出第 k 小的值论在上面的哪一层，即第 Math.Ceiling(Math.Sqrt(2k + 0.25) - 0.5) 层
        /// 
        /// 还可以继续优化，类似于“小驱动大”的思想，如果 k 是总数后半部分，查询第 n-k 大即可，这里就不写了
        /// 
        /// 思路完全是错的，见测试用例04
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] KthSmallestPrimeFraction(int[] arr, int k)
        {
            Comparer<int[]> comparer = Comparer<int[]>.Create((x, y) => x[0] * y[1] - y[0] * x[1]);
            PriorityQueue<int[], int[]> minpq = new PriorityQueue<int[], int[]>(comparer);

            int K = (int)Math.Ceiling(Math.Sqrt((k << 1) + 0.25) - 0.5);
            for (int i = 0, j = arr.Length - K; i < K; i++, j++) minpq.Enqueue([arr[i], arr[j]], [arr[i], arr[j]]);

            k -= K * (K - 1) >> 1;
            while (--k > 0) minpq.Dequeue();
            return minpq.Dequeue();
        }
    }
}
