using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0051
{
    public class Solution0051_2 : Interface0051
    {
        /// <summary>
        /// 二进制枚举
        /// 题目的数据量很小，可以直接二进制枚举暴力解
        /// </summary>
        /// <param name="materials"></param>
        /// <param name="cookbooks"></param>
        /// <param name="attribute"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int PerfectMenu(int[] materials, int[][] cookbooks, int[][] attribute, int limit)
        {
            int result = -1, delicious, filling, mask = (1 << cookbooks.Length), len = cookbooks.Length;
            int[] _materials = new int[5];
            for (int i = 1; i <= mask; i++)
            {
                delicious = 0; filling = 0;
                Array.Fill(_materials, 0);
                for (int j = 0; j < len; j++) if (((i >> j) & 1) == 1)
                    {
                        for (int k = 0; k < 5; k++) if ((_materials[k] += cookbooks[j][k]) > materials[k]) goto Continue;
                        delicious += attribute[j][0]; filling += attribute[j][1];
                    }
                if (filling >= limit) result = Math.Max(result, delicious);
                Continue:;
            }

            return result;
        }
    }
}
