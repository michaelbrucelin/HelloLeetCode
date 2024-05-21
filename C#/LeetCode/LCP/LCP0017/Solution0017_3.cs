using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0017
{
    public class Solution0017_3 : Interface0017
    {
        /// <summary>
        /// 数学，脑筋急转弯
        /// 目标结果是x+y
        /// 出现一个"A"，有x+y=(2x+y)+y=2x+2y
        /// 出现一个"B"，有x+y=x+(2y+x)=2x+2y
        /// 所以每出现一个A/B，都使x+y的值翻倍
        /// 因此结果是2** len(s)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Calculate(string s)
        {
            return 1 << s.Length;
        }
    }
}
