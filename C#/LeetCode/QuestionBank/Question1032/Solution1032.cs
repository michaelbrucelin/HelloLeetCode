using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1032
{
    public class Solution1032
    {
    }

    /// <summary>
    /// 后缀字典
    /// 具体见Solution1032.md
    /// </summary>
    public class StreamChecker : Interface1032
    {
        public StreamChecker(string[] words)
        {
            Chars = new List<char>();
            BuildTailTree(words);
        }

        private Dictionary<char, object> TailTree;
        private const char nul = '\0';
        private List<char> Chars;

        private void BuildTailTree(string[] words)
        {
            TailTree = new Dictionary<char, object>();
            Dictionary<char, object> ptr; char c;
            foreach (string word in words)  // 可以将words换成words.Distinct()试试
            {
                ptr = TailTree;
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    c = word[i];
                    if (ptr.ContainsKey(c))
                    {
                        ptr = (Dictionary<char, object>)ptr[c];
                        if (i == 0 && !ptr.ContainsKey(nul)) ptr.Add(nul, null);
                    }
                    else
                    {
                        if (i == 0)
                        {
                            ptr.Add(c, new Dictionary<char, object>() { { nul, null } });
                        }
                        else
                        {
                            Dictionary<char, object> obj = new Dictionary<char, object>();
                            ptr.Add(c, obj);
                            ptr = obj;
                        }
                    }
                }
            }
        }

        public bool Query(char letter)
        {
            Chars.Add(letter);
            Dictionary<char, object> ptr = TailTree;
            for (int i = Chars.Count - 1; i >= 0; i--)
            {
                char c = Chars[i];
                if (ptr.ContainsKey(c))
                {
                    ptr = (Dictionary<char, object>)ptr[c];
                    if (ptr.ContainsKey(nul)) return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
