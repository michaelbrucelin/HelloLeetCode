using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0062
{
    /// <summary>
    /// Your Trie object will be instantiated and called as such:
    /// Trie obj = new Trie();
    /// obj.Insert(word);
    /// bool param_2 = obj.Search(word);
    /// bool param_3 = obj.StartsWith(prefix);
    /// </summary>
    public interface Interface0062
    {
        // Initialize your data structure here.
        // public Trie(){}

        /// <summary>
        /// Inserts a word into the trie.
        /// </summary>
        /// <param name="word"></param>
        public void Insert(string word);

        /// <summary>
        /// Returns if the word is in the trie.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Search(string word);

        /// <summary>
        /// Returns if there is any word in the trie that starts with the given prefix.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public bool StartsWith(string prefix);
    }
}
