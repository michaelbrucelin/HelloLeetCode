using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0676
{
    public class Solution0676
    {
    }

    /// <summary>
    /// 暴力Hash，将每一种可能放入Hash表中，共25*100*100 = 25W种可能
    /// </summary>
    public class MagicDictionary : Interface0676
    {
        public MagicDictionary()
        {
            set = new HashSet<string>();
        }

        private HashSet<string> set;
        private char[] chars = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',];

        public void BuildDict(string[] dictionary)
        {
            foreach (string str in dictionary)
            {
                for (int i = 0; i < str.Length; i++) foreach (char c in chars) if (c != str[i])
                        {
                            set.Add($"{str[0..i]}{c}{str[(i + 1)..]}");
                        }
            }
        }

        public bool Search(string searchWord)
        {
            return set.Contains(searchWord);
        }
    }
}
