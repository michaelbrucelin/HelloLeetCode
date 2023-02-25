using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2379
{
    public class Solution2379 : Interface2379
    {
        /// <summary>
        /// 滑动窗口
        /// 扫描全部宽度为k的字串（窗口），并记录字串中含有'W'的最小数量
        /// </summary>
        /// <param name="blocks"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumRecolors(string blocks, int k)
        {
            int result = k + 1, min = 0;
            for (int i = 0; i < k; i++)  // 题目保证了k<=n
            {
                if (blocks[i] == 'W') min++;
            }
            result = Math.Min(result, min);

            for (int i = 1; i <= blocks.Length - k; i++)
            {
                if (blocks[i - 1] != blocks[i + k - 1])
                    min += blocks[i - 1] != 'W' ? 1 : -1;
                if (min == 0) return 0;
                result = Math.Min(result, min);
            }

            return result;
        }

        public int MinimumRecolors2(string blocks, int k)
        {
            return Enumerable.Range(0, blocks.Length - k + 1)
                             .Select(i => blocks.Skip(i).Take(k).Count(c => c != 'B'))
                             .Min();
        }
    }
}
