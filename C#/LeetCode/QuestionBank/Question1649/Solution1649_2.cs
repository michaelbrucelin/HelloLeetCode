using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1649
{
    public class Solution1649_2 : Interface1649
    {
        /// <summary>
        /// 树状数组
        /// 核心思路同Solution1649，Solution1649之所以会TLE，很大一部分原因在于插入排序移动元素的时间消耗，所以用计数排序来优化
        /// 但是计数排序怎样统计左侧及右侧的数目呢？想到了前缀和，由于有单点更新，进一步想到了使用树状数组
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public int CreateSortedArray(int[] instructions)
        {
            if (instructions.Length < 3) return 0;

            const int MOD = (int)1e9 + 7;
            int result = 0, max = 0, len = instructions.Length;
            for (int i = 0; i < len; i++) max = Math.Max(max, instructions[i]);
            int[] tree = new int[max += 2];
            for (int i = 0, num; i < len; i++)
            {
                num = instructions[i];
                update(num + 1, 1);
                result += Math.Min(query(num), query(max - 1) - query(num + 1));
                result %= MOD;
            }

            return result;

            void update(int idx, int inc)
            {
                do { tree[idx] += inc; } while ((idx += idx & -idx) < max);
            }

            int query(int idx)
            {
                int r = tree[idx];
                while ((idx -= idx & -idx) > 0) r += tree[idx];
                return r;
            }
        }
    }
}
