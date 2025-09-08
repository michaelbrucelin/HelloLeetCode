using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3495
{
    public class Solution3495 : Interface3495
    {
        /// <summary>
        /// 数学，贪心，类前缀和
        /// 对于区间[a,b]，通过右移操作，可以将其转为 以4为底的对数+1（即log_4^x + 1） 数组
        /// [a, b] = [1, b] - [1, a]
        /// 显然，这个对数是这个数组的一部分，[3个1, 12个2, 48个3, 192个4, ...]，每一组都是3*4^i
        /// 显然，中间的区域一定有偶数个相同的值，所以内部配对即可，因为这样操作没有“浪费”
        ///       两边的区域如果都是偶数，内部配对，如果有奇数，剩下的单独处理即可（证明？）
        /// </summary>
        /// <param name="queries"></param>
        /// <returns></returns>
        public long MinOperations(int[][] queries)
        {
            throw new NotImplementedException();
        }
    }
}
