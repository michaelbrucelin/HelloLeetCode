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
        /// 线段树
        /// 基于数组实现
        /// </summary>
        /// <param name="nums"></param>
        public NumArray_2(int[] nums)
        {
            ori = nums;
            build();
        }

        private int[] tree;
        private int[] ori;
        private int n;

        public void Update(int index, int val)
        {
            add(0, n - 1, 1, val - ori[index], index);
            ori[index] = val;
        }

        public int SumRange(int left, int right)
        {
            return query(0, n - 1, 1, left, right);
        }

        private void build()
        {
            n = ori.Length;
            tree = new int[n << 2];
            build(0, n - 1, 1);
        }

        private int build(int left, int right, int idx)
        {
            if (left == right) { tree[idx] = ori[left]; return tree[idx]; }

            int sum = 0, mid = left + ((right - left) >> 1);
            sum += build(left, mid, idx << 1);
            sum += build(mid + 1, right, (idx << 1) + 1);

            return tree[idx] = sum;
        }

        private void add(int left, int right, int idx, int val, int orid)
        {
            if (left == right) { tree[idx] += val; return; }

            int mid = left + ((right - left) >> 1);
            if (orid <= mid) add(left, mid, idx << 1, val, orid); else add(mid + 1, right, (idx << 1) + 1, val, orid);
        }

        private int query(int left, int right, int idx, int orileft, int oriright)
        {
            if (orileft == left && oriright == right) return tree[idx];

            int mid = left + ((right - left) >> 1);
            if (mid >= oriright) return query(left, mid, idx << 1, orileft, oriright);
            if (mid < orileft) return query(mid + 1, right, (idx << 1) + 1, orileft, oriright);
            return query(left, mid, idx << 1, orileft, mid) + query(mid + 1, right, (idx << 1) + 1, mid + 1, oriright);
        }
    }
}
