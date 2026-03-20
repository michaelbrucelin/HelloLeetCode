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
            ori = nums;
            build();
        }

        private int[] tree;
        private int[] ori;
        private int n;

        public void Update(int index, int val)
        {
            add(index + 1, val - ori[index]);
            ori[index] = val;
        }

        public int SumRange(int left, int right)
        {
            return sum(right + 1) - sum(left);
        }

        private void build()
        {
            n = ori.Length + 1;
            tree = new int[n];
            for (int i = 1, j; i < n; i++)
            {
                tree[i] += ori[i - 1];
                if ((j = i + (i & -i)) < n) tree[j] += tree[i];
            }
        }

        private void add(int idx, int val)
        {
            while (idx < n)
            {
                tree[idx] += val;
                idx += idx & -idx;
            }
        }

        private int sum(int idx)
        {
            int sum = 0;
            while (idx > 0)
            {
                sum += tree[idx];
                idx -= idx & -idx;
            }
            return sum;
        }
    }
}
