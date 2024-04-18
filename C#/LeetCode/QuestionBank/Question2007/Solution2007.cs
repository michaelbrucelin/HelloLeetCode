using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2007
{
    public class Solution2007 : Interface2007
    {
        /// <summary>
        /// 排序哈希
        /// </summary>
        /// <param name="changed"></param>
        /// <returns></returns>
        public int[] FindOriginalArray(int[] changed)
        {
            if ((changed.Length & 1) != 0) return [];

            int[] result = new int[changed.Length >> 1];
            int id = 0, origin, change;

            SortedDictionary<int, int> freq = new SortedDictionary<int, int>();
            for (int i = 0, num; i < changed.Length; i++)
            {
                num = changed[i];
                if (freq.ContainsKey(num)) freq[num]++; else freq.Add(num, 1);
            }
            if (freq.ContainsKey(0))
            {
                if ((freq[0] & 1) != 0) return [];
                id = freq[0] >> 1; freq.Remove(0);
            }

            while (freq.Count > 0)
            {
                origin = freq.First().Key; change = origin << 1;
                if (!freq.ContainsKey(change) || freq[change] < freq[origin]) return [];
                for (int i = 0; i < freq[origin]; i++) result[id++] = origin;
                if (freq[change] != freq[origin]) freq[change] -= freq[origin]; else freq.Remove(change);
                freq.Remove(origin);
            }

            return result;
        }
    }
}
