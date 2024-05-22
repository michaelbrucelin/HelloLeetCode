using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0014
{
    public class Solution0014_2 : Interface0014
    {
        /// <summary>
        /// 字典树
        /// 不用字典树也可以，这里这么写是想练练字典树
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1) return strs[0];  // 题目限定strs.Length > 0

            Trie trie = new Trie();
            foreach (string str in strs) trie.Insert(str);
            if (trie.Root.IsEndOfWord || trie.Root.Children.Count != 1) return "";

            StringBuilder result = new StringBuilder();
            TrieNode ptr = trie.Root.Children.First().Value;
            result.Append(ptr.Value);
            while (!ptr.IsEndOfWord)
            {
                if (ptr.Children.Count != 1) break;
                ptr = ptr.Children.First().Value;
                result.Append(ptr.Value);
            }

            return result.ToString();
        }

        public class TrieNode
        {
            public char Value { get; }
            public Dictionary<char, TrieNode> Children { get; }
            public bool IsEndOfWord { get; set; }

            public TrieNode(char value)
            {
                Value = value;
                Children = new Dictionary<char, TrieNode>();
                IsEndOfWord = false;
            }
        }

        public class Trie
        {
            public Trie()
            {
                Root = new TrieNode('\0');  // 根节点值可以是任意字符，这里使用 '\0' 表示
            }

            public readonly TrieNode Root;

            public void Insert(string word)
            {
                if (string.IsNullOrEmpty(word))
                {
                    Root.IsEndOfWord = true;
                    return;
                }

                TrieNode ptr = Root;
                foreach (char c in word)
                {
                    if (!ptr.Children.ContainsKey(c)) ptr.Children[c] = new TrieNode(c);
                    ptr = ptr.Children[c];
                }
                ptr.IsEndOfWord = true;
            }

            public bool Search(string word)
            {
                if (string.IsNullOrEmpty(word)) return Root.IsEndOfWord;

                TrieNode node = FindNode(word);

                return node != null && node.IsEndOfWord;
            }

            public bool StartsWith(string prefix)
            {
                if (string.IsNullOrEmpty(prefix)) return true;  // 所有字符串都以空字符串作为前缀

                return FindNode(prefix) != null;
            }

            private TrieNode FindNode(string word)
            {
                TrieNode ptr = Root;
                foreach (char c in word)
                {
                    if (!ptr.Children.ContainsKey(c)) return null;
                    ptr = ptr.Children[c];
                }

                return ptr;
            }
        }

    }
}
