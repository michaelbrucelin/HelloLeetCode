using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0208
{
    /// <summary>
    /// Your Trie object will be instantiated and called as such:
    /// Trie obj = new Trie();
    /// obj.Insert(word);
    /// bool param_2 = obj.Search(word);
    /// bool param_3 = obj.StartsWith(prefix);
    /// </summary>
    public interface Interface0208
    {
        // public Trie() { }

        public void Insert(string word);

        public bool Search(string word);

        public bool StartsWith(string prefix);
    }
}
