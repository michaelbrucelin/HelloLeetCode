using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0067
{
    public class Solution0067 : Interface0067
    {
        /// <summary>
        /// Trie，二叉树
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindMaximumXOR(int[] nums)
        {
            int result = 0;
            trie = new Trie();
            int[] stack = new int[31];  // 题目限定nums[i] >= 0
            int p, _num, _result;
            foreach (int num in nums)
            {
                p = 0; _num = num; _result = 0;
                while (_num > 0) { stack[p++] = _num & 1; _num >>= 1; }
                while (p < 31) stack[p++] = 0;
                trie.Insert(stack);
                _result = trie.QueryMaxXOR(stack);

                result = Math.Max(result, _result);
            }

            return result;
        }

        private Trie trie;

        public class Trie
        {
            public Trie() { Children = new Trie[2]; }
            public Trie[] Children;

            public void Insert(int[] arr)
            {
                Trie ptr = this;
                for (int i = 30, idx; i >= 0; i--)
                {
                    if (ptr.Children[idx = arr[i]] == null) ptr.Children[idx] = new Trie();
                    ptr = ptr.Children[idx];
                }
            }

            public int QueryMaxXOR(int[] arr)
            {
                int xor = 0;
                Trie ptr = this;
                for (int i = 30, idx; i >= 0; i--)
                {
                    if (ptr.Children[idx = 1 - arr[i]] != null)
                    {
                        xor |= 1 << i;
                        ptr = ptr.Children[idx];
                    }
                    else
                    {
                        ptr = ptr.Children[1 - idx];
                    }
                }
                return xor;
            }
        }
    }
}
