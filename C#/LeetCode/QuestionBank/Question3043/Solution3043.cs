using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3043
{
    public class Solution3043 : Interface3043
    {
        /// <summary>
        /// Trie
        /// 小驱动大，小的数组生成Trie，这样做与大的数组生成Trie相比时间复杂度一样，但是这样内存占用更小
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int LongestCommonPrefix(int[] arr1, int[] arr2)
        {
            int result = 0, len1 = arr1.Length, len2 = arr2.Length;
            if (len2 > len1) { (arr1, arr2) = (arr2, arr1); (len1, len2) = (len2, len1); }
            Trie trie = new Trie();
            for (int i = 0; i < len2; i++) trie.Add(arr2[i]);

            for (int i = 0; i < len1; i++) result = Math.Max(result, trie.CommonPrefixLength(arr1[i]));

            return result;
        }

        public class Trie
        {
            public Trie()
            {
                Children = new Trie[10];
                // IsEnd = false;
                stack = new Stack<int>();
            }

            public Trie[] Children;
            // public bool IsEnd;
            private Stack<int> stack;

            public void Add(int x)
            {
                while (x > 0) { stack.Push(x % 10); x /= 10; }
                Trie ptr = this; int idx;
                while (stack.Count > 0)
                {
                    idx = stack.Pop();
                    if (ptr.Children[idx] == null) ptr.Children[idx] = new Trie();
                    ptr = ptr.Children[idx];
                }
                // ptr.IsEnd = true;
            }

            public int CommonPrefixLength(int x)
            {
                while (x > 0) { stack.Push(x % 10); x /= 10; }
                Trie ptr = this; int result = 0, idx;
                while (stack.Count > 0)
                {
                    idx = stack.Pop();
                    if (ptr.Children[idx] == null)
                    {
                        stack.Clear(); return result;
                    }
                    else
                    {
                        result++; ptr = ptr.Children[idx];
                    }
                }
                return result;
            }
        }
    }
}
