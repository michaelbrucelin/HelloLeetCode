using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0067
{
    public class Solution0067_2 : Interface0067
    {
        /// <summary>
        /// Trie，二叉树
        /// 逻辑与Solution0067相同，做了如下几点优化
        /// 1. 剪枝，针对数组只有1个值或2个值的特殊情况剪枝
        /// 2. 先遍历一次nums，找出最大值，可以压缩Trie的深度，而不是固定的31层
        /// 3. 合并Insert与Query，两轮循环改为一轮循环
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            if (nums.Length == 0) return nums[0];
            if (nums.Length == 2) return nums[0] ^ nums[1];

            int max = nums[0], len = nums.Length;
            for (int i = 1; i < len; i++) max = Math.Max(max, nums[i]);
            int level = 0;
            while (max > 0) { level++; max >>= 1; }

            int result = 0;
            trie = new Trie();
            int[] stack = new int[level];
            for (int i = 0, idx, num, _result; i < len; i++)
            {
                idx = 0; num = nums[i]; _result = 0;
                while (num > 0) { stack[idx++] = num & 1; num >>= 1; }
                while (idx < level) stack[idx++] = 0;

                _result = trie.Qusert(stack);
                result = Math.Max(result, _result);
            }

            return result;
        }

        private Trie trie;

        public class Trie
        {
            public Trie() { Children = new Trie[2]; }
            public Trie[] Children;

            public int Qusert(int[] arr)
            {
                int xor = 0;
                Trie pi = this, pq = this;
                for (int i = arr.Length - 1, idx; i >= 0; i--)
                {
                    idx = arr[i];

                    if (pi.Children[idx] == null) pi.Children[idx] = new Trie();
                    pi = pi.Children[idx];

                    if (pq.Children[1 - idx] != null)
                    {
                        xor |= 1 << i;
                        pq = pq.Children[1 - idx];
                    }
                    else
                    {
                        pq = pq.Children[idx];
                    }
                }

                return xor;
            }
        }
    }
}
