using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3266
{
    public class Solution3266 : Interface3266
    {
        /// <summary>
        /// 小顶堆
        /// 本质上就是在防止溢出的过程
        /// 
        /// 未完成，TLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public int[] GetFinalState(int[] nums, int k, int multiplier)
        {
            const int MOD = (int)1e9 + 7;
            Comparer<(long val, int idx)> comparer = Comparer<(long val, int idx)>.Create((t1, t2) => t1.val != t2.val ? (int)((t1.val - t2.val) % MOD) : t1.idx - t2.idx);
            PriorityQueue<(long val, int idx), (long val, int idx)> minpq = new PriorityQueue<(long val, int idx), (long val, int idx)>(comparer);
            for (int i = 0; i < nums.Length; i++) minpq.Enqueue((nums[i], i), (nums[i], i));

            (long val, int idx) item; long val;
            while (k-- > 0)
            {
                item = minpq.Dequeue();
                val = item.val * multiplier;
                minpq.Enqueue((val, item.idx), (val, item.idx));
            }

            int[] result = new int[nums.Length];
            while (minpq.Count > 0)
            {
                item = minpq.Dequeue(); result[item.idx] = (int)(item.val % MOD);
            }
            return result;
        }
    }
}
