using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0078
{
    public class Solution0078 : Interface0078
    {
        /// <summary>
        /// 贪心 + 二分
        /// </summary>
        /// <param name="rampart"></param>
        /// <returns></returns>
        public int RampartDefensiveLine(int[][] rampart)
        {
            int result = 0, low = 0, high = (int)1e8, mid, left, len = rampart.Length;
            bool flag;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                left = rampart[1][0] - rampart[0][1];
                flag = true;
                for (int i = 1; i < len - 1; i++)
                {
                    if (left >= mid)
                    {
                        left = rampart[i + 1][0] - rampart[i][1];
                    }
                    else if (left + rampart[i + 1][0] - rampart[i][1] >= mid)
                    {
                        left = left + rampart[i + 1][0] - rampart[i][1] - mid;
                    }
                    else
                    {
                        flag = false; break;
                    }
                }
                if (flag) { result = mid; low = mid + 1; } else high = mid - 1;
            }

            return result;
        }
    }
}
