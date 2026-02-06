using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0080
{
    public class Solution0080_3 : Interface0080
    {
        /// <summary>
        /// 二进制枚举
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> result = [];

            int kset = (1 << k) - 1, limit = 1 << n, c, r, mask, offset, idx;
            while (kset < limit)
            {
                result.Add(new int[k]);
                mask = kset; offset = 1; idx = 0;
                while (mask > 0)
                {
                    if ((mask & 1) != 0) result[^1][idx++] = offset;
                    mask >>= 1; offset++;
                }

                c = kset & -kset;
                r = kset + c;
                kset = (((r ^ kset) >> 2) / c) | r;
            }

            return result;
        }
    }
}
