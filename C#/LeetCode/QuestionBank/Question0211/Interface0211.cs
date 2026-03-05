using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0211
{
    /// <summary>
    /// Your WordDictionary object will be instantiated and called as such:
    /// WordDictionary obj = new WordDictionary();
    /// obj.AddWord(word);
    /// bool param_2 = obj.Search(word);
    /// </summary>
    public interface Interface0211
    {
        // public WordDictionary() { }

        public void AddWord(string word);

        public bool Search(string word);
    }
}
