using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0039
{
    public class Solution0039_err : Interface0039
    {
        /// <summary>
        /// 状态压缩
        /// 题目限定 candidates.Length <= 30，所以可以用一个 int 进行状态压缩
        /// 
        /// 元素可重复选择，所以简单的状态压缩是不正确的，尝试修正也没有成功
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            List<int> _value = new List<int>();
            for (int i = 0, key = 0, candidate = 0; i < candidates.Length; i++)
            {
                key = 0; candidate = candidates[i]; _value.Clear();
                while ((key += candidate) <= target)
                {
                    _value.Add(candidate);
                    if (!map.ContainsKey(key)) map.Add(key, new List<int>(_value));
                }
            }

            List<IList<int>> result = new List<IList<int>>();
            List<int> _result = new List<int>();
            int[] nums = map.Keys.ToArray();
            long all = 1L << nums.Length;
            for (long mask = 1, i = 0, sum = 0; mask < all; mask++)
            {
                i = 0; sum = 0; _result.Clear();
                while (mask > 0)
                {
                    if ((mask & 1) != 0) { sum += nums[i]; _result.AddRange(map[nums[i]]); }
                    if (sum >= target) break;
                    mask >>= 1; i++;
                }
                if (sum == target) result.Add(new List<int>(_result));
            }

            return result;
        }
    }
}
