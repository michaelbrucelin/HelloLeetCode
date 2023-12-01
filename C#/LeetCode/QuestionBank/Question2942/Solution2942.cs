using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2942
{
    public class Solution2942 : Interface2942
    {
        public IList<int> FindWordsContaining(string[] words, char x)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < words.Length; i++) for (int j = 0; j < words[i].Length; j++)
                {
                    if (words[i][j] == x)
                    {
                        result.Add(i); break;
                    }
                }

            return result;
        }
    }
}
