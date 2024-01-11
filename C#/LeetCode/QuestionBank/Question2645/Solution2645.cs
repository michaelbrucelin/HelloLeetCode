using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2645
{
    public class Solution2645 : Interface2645
    {
        private static readonly int[] map = new int[] { 3, 2, 2, 1, 2, 1, 1, 0 };
        /// <summary>
        /// 遍历
        /// 每一组可以通过插入 a b c 构成abc的部分一定满足
        ///     1. 长度至少为1
        ///     2. a b c每个字符至多1个
        ///     3. 是abc的子序列，即不会出现ba，ca这样的反序
        /// 找出word中所有的满足上面要求的子单元即可
        ///     检查过程可以完美的用掩码（二进制）完成
        ///     a -> 1, b -> 2, c -> 4, mask表示abc的情况
        ///     如果新的char为a，如果mask >= 1不行，因为a必须是第一个字符
        ///     如果新的char为b，如果mask >= 2不行，因为只能至多包含一个字符a
        ///     如果新的char为c，如果mask >= 4不行，因为只能至多包含一个字符a与一个字符b
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int AddMinimum(string word)
        {
            int result = 0, len = word.Length, ptr = -1, mask = 0;
            while (++ptr < len)
            {
                if (mask >= (1 << (word[ptr] - 'a')))
                {
                    result += map[mask]; mask = 0;
                }
                mask |= 1 << (word[ptr] - 'a');
            }
            result += map[mask];

            return result;
        }
    }
}
