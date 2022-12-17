using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1764
{
    public class Solution1764_2 : Interface1764
    {
        /// <summary>
        /// 暴力解
        /// 理论上就是查找字符串的字串问题，所以字符串查找的算法都可以拿到这里来用
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanChoose(int[][] groups, int[] nums)
        {
            int start = 0, len = nums.Length;
            foreach (int[] arr in groups)
            {
                bool not_found = true;
                int _len = arr.Length;
                while (start <= len - _len)
                {
                    int reach = 0;
                    for (; reach < _len && arr[reach] == nums[start + reach]; reach++) ;
                    if (reach == _len)
                    {
                        start += _len; not_found = false;
                        break;
                    }
                    else start++;
                }
                if (not_found) return false;
            }

            return true;
        }

        /// <summary>
        /// RK解
        /// 理论上就是查找字符串的字串问题，所以字符串查找的算法都可以拿到这里来用
        /// 这里直接使用Sum作为Hash来模拟
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanChoose2(int[][] groups, int[] nums)
        {
            int start = 0, len = nums.Length;
            foreach (int[] arr in groups)
            {
                bool not_found = true;
                int _len = arr.Length;
                if (start > len - _len) return false;
                int _sum = arr.Sum(), sum = nums.Skip(start).Take(_len).Sum();
                while (sum != _sum && ++start <= len - _len) sum = sum - nums[start - 1] + nums[start + _len - 1];
                while (start <= len - _len)
                {
                    int reach = 0;
                    for (; reach < _len && arr[reach] == nums[start + reach]; reach++) ;
                    if (reach == _len)
                    {
                        start += _len; not_found = false;
                        break;
                    }
                    else
                    {
                        start++;
                        sum = sum - nums[start - 1] + nums[start + _len - 1];
                        while (sum != _sum && ++start <= len - _len) sum = sum - nums[start - 1] + nums[start + _len - 1];
                    }
                }
                if (not_found) return false;
            }

            return true;
        }
    }
}
