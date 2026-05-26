using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0131
{
    public class Solution0131 : Interface0131
    {
        /// <summary>
        /// 数学
        /// 可以使用快速幂优化，考虑到这里的数据范围，直接循环了
        /// </summary>
        /// <param name="bamboo_len"></param>
        /// <returns></returns>
        public int CuttingBamboo(int bamboo_len)
        {
            if (bamboo_len < 4) return bamboo_len - 1;  // 至少砍一刀

            int result = -1, x = bamboo_len / 3, y = bamboo_len % 3;
            switch (y)
            {
                case 0:
                    result = 1;
                    for (int i = 0; i < x; i++) result *= 3;
                    break;
                case 1:
                    result = 4;
                    for (int i = 1; i < x; i++) result *= 3;
                    break;
                case 2:
                    result = 2;
                    for (int i = 0; i < x; i++) result *= 3;
                    break;
                default: break;
            }

            return result;
        }
    }
}
