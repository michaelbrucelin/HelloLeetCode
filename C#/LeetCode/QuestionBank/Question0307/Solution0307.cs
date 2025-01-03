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
        /// 线段树
        /// </summary>
        /// <param name="nums"></param>
        public NumArray(int[] nums)
        {
            len = nums.Length;
            this.nums = nums;
            tree = new int[len * 4];
            build(0, len - 1, 1);
        }

        private int len;
        private int[] nums;
        private int[] tree;

        public int SumRange(int left, int right)
        {
            if (left == right) return nums[left];
            if (left + 1 == right) return nums[left] + nums[right];

            return SumRange(left, right, 0, len - 1, 1);
        }

        public void Update(int index, int val)
        {
            Update(index, val, 0, len - 1, 1);
            nums[index] = val;
        }

        private void build(int left, int right, int id)
        {
            if (left == right)
            {
                tree[id] = nums[left]; return;
            }

            int mid = left + (right - left) / 2;
            build(left, mid, id * 2);
            build(mid + 1, right, id * 2 + 1);
            tree[id] = tree[id * 2] + tree[id * 2 + 1];
        }

        private int SumRange(int l, int r, int left, int right, int id)
        {
            if (l <= left && r >= right) return tree[id];

            int mid = left + (right - left) / 2;
            if (r <= mid) return SumRange(l, r, left, mid, id * 2);
            if (l > mid) return SumRange(l, r, mid + 1, right, id * 2 + 1);

            return SumRange(l, mid, left, mid, id * 2) + SumRange(mid + 1, r, mid + 1, right, id * 2 + 1);
        }

        private void Update(int idx, int val, int left, int right, int id)
        {
            if (left == right)
            {
                tree[id] = val; return;
            }

            int mid = left + (right - left) / 2;
            if (idx <= mid) Update(idx, val, left, mid, id * 2); else Update(idx, val, mid + 1, right, id * 2 + 1);
            tree[id] = tree[id * 2] + tree[id * 2 + 1];
        }
    }
}
