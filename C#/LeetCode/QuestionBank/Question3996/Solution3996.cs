using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3996
{
    public class Solution3996 : Interface3996
    {
        /// <summary>
        /// 脑筋急转弯
        /// 1. 每走一步必然换颜色
        /// 2. 每个位置都必然可到达
        ///     证明，可以到达相邻位置与斜角位置，所以所有位置都可到达
        /// 所以偶数次到达target即start与target同颜色
        /// </summary>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool CanReach(int[] start, int[] target)
        {
            return (Math.Abs(target[0] - start[0] + target[1] - start[1]) & 1) == 0;
        }
    }
}
