using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0307
{
    public class Solution0307
    {
    }

    public class NumArray : Interface0307
    {
        /// <summary>
        /// 树状数组
        /// </summary>
        /// <param name="nums"></param>
        public NumArray(int[] nums)
        {
            len = nums.Length;
            bit = new int[len + 1];
            ori = new int[len];
            for (int i = 0; i < len; i++)
            {
                ori[i] = nums[i];
                add(i + 1, nums[i]);
            }
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

        private void add(int id, int x)
        {
            while (id <= len)
            {
                bit[id] += x;
                id += id & -id;
            }
        }

        private int sum(int id)
        {
            int sum = 0;
            while (id > 0)
            {
                sum += bit[id];
                id -= id & -id;
            }

            return sum;
        }
    }
}
