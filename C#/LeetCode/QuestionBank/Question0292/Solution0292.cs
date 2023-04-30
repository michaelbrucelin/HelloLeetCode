using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0292
{
    public class Solution0292 : Interface0292
    {
        /// <summary>
        /// 数学
        /// 1. 有1-3块石头，赢，全部拿走即可
        /// 2. 有 4 块石头，输，无论怎么拿，剩余1-3块，对方赢
        /// 3. 有5-7块石头，赢，拿1-3块保证剩余4块，对方输
        /// 4. 有 8 块石头，输，无论怎么拿，剩余5-7块，对方赢
        /// ... ...
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanWinNim(int n)
        {
            return n % 4 != 0;
        }

        public bool CanWinNim2(int n)
        {
            return (n & 3) != 0;
        }

        /// <summary>
        /// 递归
        /// 
        /// 写着玩的，提交会报栈溢出
        /// Stack overflow.
        /// Repeat 3124647 times:
        /// --------------------------------
        /// At Solution.CanWinNim(Int32)
        /// --------------------------------
        /// At __Driver__.Main(System.String[])
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanWinNim3(int n)
        {
            if (n <= 4) return n != 4;
            if (CanWinNim3(n - 1) || CanWinNim3(n - 2) || CanWinNim3(n - 3)) return true;
            return false;
        }
    }
}
