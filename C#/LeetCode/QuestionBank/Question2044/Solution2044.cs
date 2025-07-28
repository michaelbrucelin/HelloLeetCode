using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2044
{
    public class Solution2044 : Interface2044
    {
        /// <summary>
        /// 二进制枚举
        /// 可以去重复优化，这里的数量级感觉不值得这样优化，就不做了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountMaxOrSubsets(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int limit = 1 << nums.Length;
            for (int mask = 1, _mask, value, id; mask < limit; mask++)
            {
                _mask = mask; value = id = 0;
                while (_mask > 0)
                {
                    if ((_mask & 1) != 0) value |= nums[id];
                    _mask >>= 1; id++;
                }
                if (map.ContainsKey(value)) map[value]++; else map.Add(value, 1);
            }

            int max = 0, cnt = 0;
            foreach (int key in map.Keys) if (key > max) { max = key; cnt = map[key]; }
            return cnt;
        }

        /// <summary>
        /// 使用.net core内置的位运算来简化代码
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountMaxOrSubsets2(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int limit = 1 << nums.Length;
            for (int mask = 1, value; mask < limit; mask++)
            {
                uint _mask = (uint)mask; value = 0;
                while (_mask > 0)
                {
                    value |= nums[BitOperations.Log2(_mask - (_mask & (_mask - 1)))];
                    _mask &= _mask - 1;
                }
                if (map.ContainsKey(value)) map[value]++; else map.Add(value, 1);
            }

            int max = 0, cnt = 0;
            foreach (int key in map.Keys) if (key > max) { max = key; cnt = map[key]; }
            return cnt;
        }
    }
}
