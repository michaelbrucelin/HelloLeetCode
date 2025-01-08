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
            for (int i = 0; i < k; i++) if (blocks[i] == 'W') min++;  // 题目保证了k<=n
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

        /// <summary>
        /// 与MinimumRecolors()逻辑一样，将if-else优化为映射
        /// </summary>
        /// <param name="blocks"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumRecolors2(string blocks, int k)
        {
            int result = k + 1, min = 0;
            for (int i = 0; i < k; i++) min += blocks[i] & 1;  // 题目保证了k<=n
            result = Math.Min(result, min);

            for (int i = 1; i <= blocks.Length - k; i++)
            {
                min = min - (blocks[i - 1] & 1) + (blocks[i + k - 1] & 1);
                if (min == 0) return 0;
                result = Math.Min(result, min);
            }

            return result;
        }
    }
}
