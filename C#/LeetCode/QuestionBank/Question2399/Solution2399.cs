using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2399
{
    public class Solution2399 : Interface2399
    {
        public bool CheckDistances(string s, int[] distance)
        {
            int[] buffer = new int[26]; for (int i = 0; i < 26; i++) buffer[i] = -1;
            for (int i = 0; i < s.Length; i++)
            {
                int id = s[i] - 'a';
                if (buffer[id] == -1) buffer[id] = i;
                else
                {
                    if (i - buffer[id] - 1 != distance[id]) return false;
                }
            }

            return true;
        }
    }
}
