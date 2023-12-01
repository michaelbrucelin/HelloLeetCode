using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2942
{
    public class Solution2942_api : Interface2942
    {
        public IList<int> FindWordsContaining(string[] words, char x)
        {
            return words.Select((s, i) => (s, i)).Where(t => t.s.Contains(x)).Select(t => t.i).ToArray();
        }
    }
}
