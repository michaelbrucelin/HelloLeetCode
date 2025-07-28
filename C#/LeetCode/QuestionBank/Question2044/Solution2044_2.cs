using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2044
{
    public class Solution2044_2 : Interface2044
    {
        private static readonly int[] DeBruijnIdx = [0, 1, 28, 2, 29, 14, 24, 3, 30, 22, 20, 15, 25, 17, 4, 8,
                                                     31, 27, 13, 23, 21, 19, 16, 7, 26, 12, 18, 6, 11, 5, 10, 9];

        /// <summary>
        /// 逻辑完全同Solution2044，使用 De Bruijn 位运算技巧快速查找二进制中 1 的位置
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountMaxOrSubsets(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int limit = 1 << nums.Length;
            for (int mask = 1, _mask, value; mask < limit; mask++)
            {
                _mask = mask; value = 0;
                while (_mask > 0)
                {
                    value |= nums[log2(_mask - (_mask & (_mask - 1)))];
                    _mask &= _mask - 1;
                }
                if (map.ContainsKey(value)) map[value]++; else map.Add(value, 1);
            }

            int max = 0, cnt = 0;
            foreach (int key in map.Keys) if (key > max) { max = key; cnt = map[key]; }
            return cnt;

            int log2(int n)
            {
                return DeBruijnIdx[(((uint)n) * 0x077CB531U) >> 27];
            }
        }
    }
}
