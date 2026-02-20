using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0761
{
    public class Solution0761_err : Interface0761
    {
        /// <summary>
        /// 贪心？
        /// 先贪心写一下试试
        ///     从左向右找两组特殊字串，如果第二组更大，就交换
        ///     两组连续的特殊字串交界处一定是01
        /// 这样交换一定会使字符串变大，但是没证明出来这样操作会变为最大，先写出来跑跑试试
        /// 
        /// 逻辑错误，参考测试用例08
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string MakeLargestSpecial(string s)
        {
            int len = s.Length;
            char[] chars = s.ToCharArray(), buffer = new char[len];
            int start = 0, p1, p2, lcnt0, lcnt1, p3, p4, rcnt0, rcnt1, p; bool flag;
            while (true)
            {
                p3 = start + 1; while (p3 < len && !(chars[p3 - 1] == '0' && chars[p3] == '1')) p3++;
                if (p3 == len - 1) break;
                p2 = p3 - 1;
                lcnt0 = lcnt1 = 0; p1 = p2;
                while (p1 >= 0)
                {
                    if (chars[p1] == '1') { lcnt1++; } else { lcnt0++; lcnt1 = 0; }
                    if (p2 - p1 + 1 == (lcnt0 << 1)) break;
                    p1--;
                }
                rcnt0 = rcnt1 = 0; p4 = p3; flag = true;
                while (p4 < len)
                {
                    if (chars[p4] == '1') { if (flag) rcnt1++; } else { rcnt0++; flag = false; }
                    if (p4 - p3 + 1 == (rcnt0 << 1)) break;
                    p4++;
                }
                if (p4 == len) break;
                // 交换
                if (lcnt1 < rcnt1 || (lcnt1 == rcnt1 && (p2 - p1 < p4 - p3)))
                {
                    for (int i = p1; i <= p4; i++) buffer[i] = chars[i];
                    p = p1;
                    for (int i = p3; i <= p4; i++) chars[p++] = buffer[i];
                    for (int i = p1; i <= p2; i++) chars[p++] = buffer[i];
                    start = 0;
                }
                else
                {
                    start = p3;
                }
            }

            return new string(chars);
        }
    }
}
