using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1963
{
    public class Solution1963_err : Interface1963
    {
        /// <summary>
        /// 贪心
        /// 1. 本质上就是让括号嵌套合法
        /// 2. 从左至右遍历s的每一个字符
        ///     如果是 [
        ///         如果 cnt_r > 0 ，cnt_r - 1，result + 1
        ///         如果 cnt_r = 0 ，cnt_l + 1
        ///     如果是 ]
        ///         如果 cnt_l > 0 ，cnt_l - 1
        ///         如果 cnt_l = 0 ，cnt_r + 1
        /// 证明，略
        /// 
        /// 这样能保证让字符串平衡，但是不能保证是最少的交换次数，参考 "][][" 和 "]]][[["
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinSwaps(string s)
        {
            int result = 0, cnt_l = 0, cnt_r = 0;
            foreach (char c in s)
            {
                if (c == '[')
                {
                    if (cnt_r > 0) { cnt_r--; result++; } else cnt_l++;
                }
                else
                {
                    if (cnt_l > 0) cnt_l--; else cnt_r++;
                }
            }

            return result;
        }
    }
}
