using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3042
{
    public class Solution3042_2 : Interface3042
    {
        /// <summary>
        /// 字典树
        /// 数据量级完全没必要上字典树，这里只是练习一下字典树
        /// 需要两个字典树，一个记录word的字典树，一个记录word.Reverse()的字典树
        /// 需要从后向前遍历
        /// 
        /// 未完成，有时间再弄
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int CountPrefixSuffixPairs(string[] words)
        {
            int result = 0, len = words.Length;
            Trie trie = new Trie(), trie_r = new Trie();
            string word, word_r;
            for (int i = len - 1; i >= 0; i--)
            {
                word = words[i]; word_r = new string(word.Reverse().ToArray());
                
                trie.Insert(word); trie_r.Insert(word_r);
            }

            return result;
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
                Root = new TrieNode('\0');
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
                if (string.IsNullOrEmpty(prefix)) return true;

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
