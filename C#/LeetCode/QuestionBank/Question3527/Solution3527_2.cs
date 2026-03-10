using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3527
{
    public class Solution3527_2 : Interface3527
    {
        /// <summary>
        /// Trie
        /// 逻辑完全同Solution3527，用Trie来try 1 try
        /// </summary>
        /// <param name="responses"></param>
        /// <returns></returns>
        public string FindCommonResponse(IList<IList<string>> responses)
        {
            string result = "";
            Trie trie = new Trie();
            int max = 0;
            List<char> buffer = [];
            foreach (IList<string> response in responses)
            {
                Trie _trie = new Trie();
                foreach (string s in response) _trie.Insert(s);
                BackTrackMerge(trie, _trie);
            }

            return result;

            void BackTrackMerge(Trie trie, Trie _trie)
            {
                for (int i = 0; i < 26; i++) if (_trie.Children[i] != null)
                    {
                        buffer.Add((char)('a' + i));
                        if (trie.Children[i] == null) trie.Children[i] = new Trie();
                        if (_trie.Children[i].IsEnd)
                        {
                            // trie.Children[i].IsEnd = true;
                            trie.Children[i].Cnt++;
                            if (trie.Children[i].Cnt > max)
                            {
                                max = trie.Children[i].Cnt;
                                result = new string([.. buffer]);
                            }
                            else if (trie.Children[i].Cnt == max)
                            {
                                string _result = new string([.. buffer]);
                                if (string.CompareOrdinal(_result, result) < 0) result = _result;
                            }
                        }
                        BackTrackMerge(trie.Children[i], _trie.Children[i]);
                        buffer.RemoveAt(buffer.Count - 1);
                    }
            }
        }

        public class Trie
        {
            public Trie() { Children = new Trie[26]; IsEnd = false; Cnt = 0; }
            public Trie[] Children;
            public bool IsEnd;
            public int Cnt;

            public void Insert(string s)
            {
                Trie ptr = this;
                int idx;
                foreach (char c in s)
                {
                    if (ptr.Children[idx = c - 'a'] == null) ptr.Children[idx] = new Trie();
                    ptr = ptr.Children[idx];
                }
                ptr.IsEnd = true;
            }
        }
    }
}
