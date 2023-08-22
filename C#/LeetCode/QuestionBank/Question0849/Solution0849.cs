using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0849
{
    public class Solution0849 : Interface0849
    {
        /// <summary>
        /// 分析
        /// 就是在找数组中连续的0，注意两端连续的0与中间连续的0处理方式不一样
        /// </summary>
        /// <param name="seats"></param>
        /// <returns></returns>
        public int MaxDistToClosest(int[] seats)
        {
            int result, len = seats.Length, l = 0, r = len - 1;
            while (l <= r && seats[l] == 0) l++;
            while (r >= l && seats[r] == 0) r--;
            result = Math.Max(l, len - 1 - r);

            for (int i = l, width = 0; i <= r; i++) switch (seats[i])
                {
                    case 0: width++; break;
                    case 1:
                        result = Math.Max(result, (width + 1) >> 1); width = 0;
                        break;
                    default: break;
                }

            return result;
        }

        /// <summary>
        /// 与MaxDistToClosest()一样，只是将for循环改为了while循环再实现了一次
        /// 主要是二者的思想是不一样的
        ///     for有状态机的味道，机器的思想
        ///     while更接近与人的思路
        /// </summary>
        /// <param name="seats"></param>
        /// <returns></returns>
        public int MaxDistToClosest2(int[] seats)
        {
            int result, len = seats.Length, l = 0, r = len - 1;
            while (l <= r && seats[l] == 0) l++;
            while (r >= l && seats[r] == 0) r--;
            result = Math.Max(l, len - 1 - r);

            int pl = l - 1, pr;
            while (++pl <= r)
            {
                while (pl <= r && seats[pl] == 1) pl++; if (pl > r) break;
                pr = pl + 1;
                while (pr <= r && seats[pr] == 0) pr++; if (pr > r) break;
                result = Math.Max(result, (pr - pl + 1) >> 1);
            }

            return result;
        }
    }
}
