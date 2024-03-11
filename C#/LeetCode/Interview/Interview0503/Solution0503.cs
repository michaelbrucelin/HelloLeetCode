using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0503
{
    public class Solution0503 : Interface0503
    {
        /// <summary>
        /// 遍历
        /// 以0为分隔字符将二进制字符串拆分为数组，找相邻元素长度和的最大值，再加1
        /// 注意，负数的话需要取反，然后以1为分隔字符统计字符0的长度
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int ReverseBits(int num)
        {
            int result = 1, _num = num, find = 1, len1 = 0, len2 = 0;
            if (num < 0) { _num = ~num; find = 0; }
            for (int i = 0; i < 32; i++)
            {
                if ((_num & 1) != find)
                {
                    result = Math.Max(result, len1 + len2 + 1);
                    len1 = len2; len2 = 0;
                }
                else
                {
                    len2++;
                }
                _num >>= 1;
            }
            result = Math.Max(result, len1 + len2 + 1);

            return result > 32 ? 32 : result;
        }
    }
}
