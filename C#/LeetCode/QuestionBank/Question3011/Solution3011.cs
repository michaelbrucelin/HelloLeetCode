using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3011
{
    public class Solution3011 : Interface3011
    {
        /// <summary>
        /// 分组 + 排序
        /// 按照相邻元素1的数量相同分组，再与排序后的数组比较，相同分组内的元素应该相同（忽略顺序）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanSortArray(int[] nums)
        {
            // 排序
            int[] _nums = nums.ToArray();
            Array.Sort(_nums);

            // 分组
            int l = 0, r, _count, len = nums.Length;
            List<(int l, int r)> groups = new List<(int l, int r)>();
            while (l < len)
            {
                r = l;
                _count = BitCount(nums[l]);
                while (r + 1 < len && BitCount(nums[r + 1]) == _count) r++;
                groups.Add((l, r));
                l = r + 1;
            }

            // 结果
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            foreach (var group in groups)
            {
                (l, r) = group;
                if (l == r)
                {
                    if (nums[l] != _nums[l]) return false;
                }
                else
                {
                    buffer.Clear();
                    for (int i = l; i <= r; i++)
                        if (buffer.ContainsKey(nums[i])) buffer[nums[i]]++; else buffer.Add(nums[i], 1);
                    for (int i = l; i <= r; i++)
                        if (!buffer.ContainsKey(_nums[i]) || --buffer[_nums[i]] < 0) return false;
                }
            }

            return true;

            int BitCount(int num)
            {
                int count = 0;
                while (num > 0) { count++; num &= num - 1; }
                return count;
            }
        }
    }
}
