using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1963
{
    public class Solution1963 : Interface1963
    {
        /// <summary>
        /// 贪心
        /// 本质上与Solution_err逻辑一样，Solution_err中有没想清楚的地方
        /// 首先，对于一个平衡的字符串，每一个 ] 怎样找到对应的 [ ，显然，可以用栈的思想，每一个 ] 找到栈顶的 [ 即可
        ///     上面的结论是充分必要的
        /// 所以，对于任意的前缀字串中，[ 的数量一定大于等于 ] 的数量
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinSwaps(string s)
        {
            int result = 0, cnt_l = 0, cnt_r = 0, border = s.Length >> 1;
            foreach (char c in s)
            {
                if (c == '[')
                {
                    cnt_l++;
                }
                else
                {
                    if (cnt_r < cnt_l) cnt_r++; else { cnt_l++; result++; }
                }
                if (cnt_l >= border) break;
            }

            return result;
        }
    }
}
