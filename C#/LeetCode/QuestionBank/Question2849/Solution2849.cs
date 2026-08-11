using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2849
{
    public class Solution2849 : Interface2849
    {
        /// <summary>
        /// 分类讨论易错题
        /// 
        /// 竟然一次就通过了。。。
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        /// <param name="fx"></param>
        /// <param name="fy"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsReachableAtTime(int sx, int sy, int fx, int fy, int t)
        {
            if (sx == fx && sy == fy) return t != 1;

            int dx = Math.Abs(fx - sx), dy = Math.Abs(fy - sy);
            int min = Math.Max(dx, dy);  // max = dx + dy;

            return t >= min;
        }
    }
}
