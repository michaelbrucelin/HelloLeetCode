using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0017
{
    public class Solution0017 : Interface0017
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            int x = 1, y = 0;
            foreach (char c in s) switch (c)
                {
                    case 'A': x = (x << 1) + y; break;
                    case 'B': y = (y << 1) + x; break;
                    default: break;
                }

            return x + y;
        }
    }
}
