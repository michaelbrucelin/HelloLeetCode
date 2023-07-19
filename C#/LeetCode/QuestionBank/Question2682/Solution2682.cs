using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2682
{
    public class Solution2682 : Interface2682
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] CircularGameLosers(int n, int k)
        {
            bool[] mask = new bool[n]; mask[0] = true;
            int pos = 0, time = 1;
            while (true)
            {
                pos = (pos + k * time++) % n;
                if (mask[pos]) break; else mask[pos] = true;
            }

            List<int> result = new List<int>();
            for (int i = 0; i < n; i++) if (!mask[i]) result.Add(i + 1);
            return result.ToArray();
        }

        /// <summary>
        /// 模拟
        /// 与CircularGameLosers()一样，由于n<=50，故这里将mask数组改为long
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] CircularGameLosers2(int n, int k)
        {
            long mask = 1; mask |= 1L << n;
            int pos = 0, time = 1;
            while (true)
            {
                pos = (pos + k * time++) % n;
                if (((mask >> pos) & 1) == 1) break; else mask |= 1L << pos;
            }

            List<int> result = new List<int>();
            int i = 1; while (mask > 1)
            {
                if ((mask & 1) != 1) result.Add(i);
                mask >>= 1;
                i++;
            }
            return result.ToArray();
        }
    }
}
