using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1365
{
    public class Solution1365 : Interface1365
    {
        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            for (int i = 0, _num, _cnt; i < len; i++)
            {
                _num = nums[i]; _cnt = 0;
                for (int j = 0; j < len; j++) if (nums[j] < _num) _cnt++;
                result[i] = _cnt;
            }

            return result;
        }
    }
}
