using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0239
{
    public class Solution0239_2 : Interface0239
    {
        /// <summary>
        /// 双端队列，单调队列
        /// 原理同Solution0239_off中的解法2与Solution0239_oth，这里就不描述了
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 1) return nums;
            if (k == nums.Length) return [nums.Max()];

            int len = nums.Length;
            int[] result = new int[len - k + 1];
            LinkedList<(int val, int idx)> list = new LinkedList<(int val, int idx)>();
            for (int i = 0, num; i < k - 1; i++)
            {
                num = nums[i];
                while (list.Count > 0 && list.Last.Value.val < num) list.RemoveLast();
                list.AddLast((num, i));
            }
            for (int i = k - 1, num; i < len; i++)
            {
                num = nums[i];
                while (list.Count > 0 && list.Last.Value.val < num) list.RemoveLast();
                list.AddLast((num, i));
                while (list.First.Value.idx < i - k + 1) list.RemoveFirst();
                result[i - k + 1] = list.First.Value.val;
            }

            return result;
        }
    }
}
