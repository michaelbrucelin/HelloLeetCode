using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0101
{
    public class Solution0101 : Interface0101
    {
        /// <summary>
        /// BFS
        /// 本质上还是组合，看看能不能找到一个组合的和是全部和的一半
        /// 和为奇数或最大值大于和的一半，无解
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            int sum = 0, max = nums[0], len = nums.Length;
            for (int i = 0; i < len; i++)
            {
                sum += nums[i]; max = Math.Max(max, nums[i]);
            }
            if ((sum & 1) == 1 || max > (sum >>= 1)) return false;

            HashSet<int> set = new HashSet<int>() { 0 }, _set = new HashSet<int>();
            int _item;
            foreach (int num in nums)
            {
                _set.Clear();
                foreach (int item in set)
                {
                    _item = item + num;
                    if (_item == sum) return true;
                    if (_item < sum) _set.Add(_item);
                }
                set.UnionWith(_set);
            }

            return false;
        }
    }
}
