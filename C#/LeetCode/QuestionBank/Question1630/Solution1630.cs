using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1630
{
    public class Solution1630 : Interface1630
    {
        /// <summary>
        /// 暴力
        /// 排序，检查是否是等差数列
        /// 提交竟然没有超时。。。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            bool[] result = new bool[l.Length];
            for (int i = 0, _len; i < l.Length; i++)
            {
                _len = r[i] - l[i] + 1;
                int[] arr = new int[_len];
                Array.Copy(nums, l[i], arr, 0, _len); Array.Sort(arr);
                for (int j = 2, diff = arr[1] - arr[0]; j < _len; j++)
                    if (arr[j] - arr[j - 1] != diff) goto False;
                result[i] = true; continue;
                False:;
            }

            return result;
        }
    }
}
