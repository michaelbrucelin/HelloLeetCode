using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2099
{
    public class Solution2099_3 : Interface2099
    {
        /// <summary>
        /// topk
        /// 使用快排的方式实现topk
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSubsequence(int[] nums, int k)
        {
            (int val, int id)[] _nums = nums.Select((val, id) => (val, id)).ToArray();
            int div = partition(_nums, 0, _nums.Length - 1);
            while (div != k - 1)
                div = div > k - 1 ? partition(_nums, 0, div - 1) : partition(_nums, div + 1, _nums.Length - 1);
            bool[] mask = new bool[nums.Length];
            for (int i = 0; i < k; i++) mask[_nums[i].id] = true;

            int[] result = new int[k];
            for (int i = 0, j = 0; j < k; i++) if (mask[i]) result[j++] = nums[i];

            return result;
        }

        private int partition((int val, int id)[] nums, int left, int right)
        {
            int pl = left, pr = right; var pivot = nums[left];
            while (pl < pr)
            {
                while (pr > pl && nums[pr].val <= pivot.val) pr--;
                nums[pl] = nums[pr];
                while (pl < pr && nums[pl].val >= pivot.val) pl++;
                nums[pr] = nums[pl];
            }
            nums[pl] = pivot;

            return pl;
        }
    }
}
