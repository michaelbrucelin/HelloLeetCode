using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0128
{
    public class Solution0128_2 : Interface0128
    {
        /// <summary>
        /// 字典
        /// 遍历数组中的每一个元素，并用字典记录着当前的连续子区间
        ///     字典：key左端点，value是区间
        ///           key右端点，value是区间
        /// 每遍历一个新元素，该元素
        ///     1. 独立区间
        ///     2. 一个当前区间的新的左端点
        ///     3. 一个当前区间的新的右端点
        ///     4. 连接两个当前区间
        /// 有压力才有动力，题目提示使用O(n)的时间复杂度才想这么做的，否则字节排序了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            HashSet<int> set = new HashSet<int>(nums);
            Dictionary<int, (int l, int r)> map = new Dictionary<int, (int l, int r)>();
            int _l, _r;
            foreach (int num in set) switch ((map.ContainsKey(num - 1), map.ContainsKey(num + 1)))
                {
                    case (false, false):
                        map.Add(num, (num, num));
                        break;
                    case (true, false):
                        (_l, _r) = map[num - 1]; map.Remove(num - 1); map[_l] = (_l, num); map.Add(num, (_l, num));
                        break;
                    case (false, true):
                        (_l, _r) = map[num + 1]; map.Remove(num + 1); map[_r] = (num, _r); map.Add(num, (num, _r));
                        break;
                    case (true, true):
                        (_l, _r) = (map[num - 1].l, map[num + 1].r);
                        map.Remove(num - 1); map[_l] = (_l, _r);
                        map.Remove(num + 1); map[_r] = (_l, _r);
                        break;
                }

            int result = 0;
            foreach (var rng in map.Values) result = Math.Max(result, rng.r - rng.l + 1);

            return result;
        }
    }
}
