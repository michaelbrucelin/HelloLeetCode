using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0064
{
    /// <summary>
    /// Your MagicDictionary object will be instantiated and called as such:
    /// MagicDictionary obj = new MagicDictionary();
    /// obj.BuildDict(dictionary);
    /// bool param_2 = obj.Search(searchWord);
    /// </summary>
    public interface Interface0064
    {
        /** Initialize your data structure here. */
        // public MagicDictionary() { }

        public void BuildDict(string[] dictionary);

        public bool Search(string searchWord);
    }
}
