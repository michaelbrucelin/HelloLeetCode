using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0307
{
    public class Solution0307_2
    {
    }

    public class NumArray_2 : Interface0307
    {
        /// <summary>
        /// 树状数组
        /// 逻辑与Solution0307一样，优化了树状数组的初始化过程
        /// </summary>
        /// <param name="nums"></param>
        public NumArray_2(int[] nums)
        {
            len = nums.Length;
            bit = new int[len + 1];
            ori = new int[len];
            build(nums);
        }

        private int[] bit;
        private int[] ori;
        private int len;

        public void Update(int index, int val)
        {
            add(index + 1, val - ori[index]);
            ori[index] = val;
        }

        public int SumRange(int left, int right)
        {
            return sum(right + 1) - sum(left);
        }

        private void build(int[] nums)
        {
            for (int i = 0, j; i < len; i++)
            {
                ori[i] = nums[i];
                bit[i + 1] += nums[i];
                if ((j = i + 1 + ((i + 1) & (-i - 1))) <= len) bit[j] += bit[i + 1];
            }
        }

        private void add(int idx, int val)
        {
            while (idx <= len)
            {
                bit[idx] += val;
                idx += idx & -idx;
            }
        }

        private int sum(int idx)
        {
            int sum = 0;
            while (idx > 0)
            {
                sum += bit[idx];
                idx -= idx & -idx;
            }
            return sum;
        }
    }
}
