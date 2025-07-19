using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1233
{
    public class Solution1233_3 : Interface1233
    {
        /// <summary>
        /// 字典树
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public IList<string> RemoveSubfolders(string[] folder)
        {
            if (folder.Length == 1) return folder;

            Trie trie = new Trie();
            Trie ptr;
            foreach (string dir in folder)
            {
                ptr = trie;
                foreach (char c in dir)
                {
                    if (ptr.Children.ContainsKey(c))
                    {
                        if (ptr.Children[c].IsEnd) goto CONTINUE;
                    }
                    else
                    {
                        ptr.Children.Add(c, new Trie());
                    }
                    ptr = ptr.Children[c];
                }
                if (!ptr.Children.ContainsKey('/')) ptr.Children.Add('/', new Trie());
                ptr.Children['/'].IsEnd = true;
            CONTINUE:;
            }

            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            dfs(trie.Children['/'], '/', sb);
            return result;

            void dfs(Trie node, char c, StringBuilder sb)
            {
                if (node.IsEnd) { result.Add(sb.ToString()); return; }
                sb.Append(c);
                foreach (char _c in node.Children.Keys)
                {
                    StringBuilder _sb = new StringBuilder(sb.ToString());
                    dfs(node.Children[_c], _c, _sb);
                }
            }
        }

        public class Trie
        {
            public Trie() { IsEnd = false; Children = new(); }
            public bool IsEnd { get; set; }
            public Dictionary<char, Trie> Children { get; set; }
        }
    }
}
