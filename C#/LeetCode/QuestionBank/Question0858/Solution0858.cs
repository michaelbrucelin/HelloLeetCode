using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0858
{
    public class Solution0858 : Interface0858
    {
        /// <summary>
        /// 模拟
        /// 无论怎样反射，横向行进的距离与纵向行进的距离始终保持p:q
        /// 记录左右反射的次数(ud)与上下反射的次数(lr)即可，
        ///     ud是奇数，结果在下面，偶数在上边
        ///     lr是奇数，结果在左面，偶数在右边
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public int MirrorReflection(int p, int q)
        {
            int[][] result = [[1, 2], [0, -1]];
            int ud = 0, lr;
            while ((++ud) * p % q != 0) ;
            lr = ud * p / q;

            return result[(ud - 1) & 1][(lr - 1) & 1];
        }
    }
}
