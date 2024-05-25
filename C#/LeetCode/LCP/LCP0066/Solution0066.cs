using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0066
{
    public class Solution0066 : Interface0066
    {
        public int MinNumBooths(string[] demand)
        {
            int[] result = new int[26], _result = new int[26];
            for (int i = 0; i < demand.Length; i++)
            {
                Array.Fill(_result, 0);
                foreach (char c in demand[i]) _result[c - 'a']++;
                for (int j = 0; j < 26; j++) result[j] = Math.Max(result[j], _result[j]);
            }

            return result.Sum();
        }
    }
}
