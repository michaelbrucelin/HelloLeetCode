using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0677
{
    public class Solution0677_2
    {
    }

    /// <summary>
    /// Trie，逻辑同Solution0677，Trie中添加列表来优化内部的遍历
    /// </summary>
    public class MapSum_2
    {
        public MapSum_2()
        {
            map = new Trie();
        }

        public Trie map;

        public void Insert(string key, int val)
        {
            Trie ptr = map;
            int idx;
            foreach (char c in key)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) { ptr.Children[idx] = new Trie(); ptr.ChildrenIds.Add(idx); }
                ptr = ptr.Children[idx];
            }
            ptr.Value = val;
        }

        public int Sum(string prefix)
        {
            Trie ptr = map;
            int idx;
            foreach (char c in prefix)
            {
                idx = c - 'a';
                if (ptr.Children[idx] == null) return 0;
                ptr = ptr.Children[idx];
            }

            int result = ptr.Value;
            dfs(ptr, ref result);
            return result;
        }

        private void dfs(Trie node, ref int sum)
        {
            foreach (int i in node.ChildrenIds)
            {
                sum += node.Children[i].Value;
                dfs(node.Children[i], ref sum);
            }
        }

        public class Trie
        {
            public Trie() { Children = new Trie[26]; ChildrenIds = []; Value = 0; }
            public Trie[] Children;
            public List<int> ChildrenIds;
            public int Value;
        }
    }
}
