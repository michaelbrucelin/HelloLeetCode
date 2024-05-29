using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0039
{
    public class Solution0039 : Interface0039
    {
        /// <summary>
        /// 脑筋急转弯
        /// 只需要比较两边不同“颜色”的频次即可
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinimumSwitchingTimes(int[][] source, int[][] target)
        {
            int rcnt = source.Length, ccnt = source[0].Length;
            Dictionary<int, int> freqs = new Dictionary<int, int>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    freqs.TryAdd(source[r][c], 0); freqs[source[r][c]]++;
                }
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (freqs.ContainsKey(target[r][c]) && freqs[target[r][c]] > 0) freqs[target[r][c]]--;
                }

            int result = 0;
            foreach (int freq in freqs.Values) if (freq > 0) result += freq;

            return result;
        }
    }
}
