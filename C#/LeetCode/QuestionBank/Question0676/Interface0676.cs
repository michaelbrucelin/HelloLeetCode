using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0676
{
    /// <summary>
    /// Your MagicDictionary object will be instantiated and called as such:
    /// MagicDictionary obj = new MagicDictionary();
    /// obj.BuildDict(dictionary);
    /// bool param_2 = obj.Search(searchWord);
    /// </summary>
    public interface Interface0676
    {
        // public MagicDictionary()
        // {
        // }

        public void BuildDict(string[] dictionary);

        public bool Search(string searchWord);
    }
}
