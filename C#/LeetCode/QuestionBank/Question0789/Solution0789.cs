using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0789
{
    public class Solution0789 : Interface0789
    {
        /// <summary>
        /// 脑筋急转弯
        /// 第一反应是BFS，但是如果人已知往原理目的地的方向跑，鬼又追不上，显然会TLE，所以有了下面的结论及证明
        /// 首先，target就是可行区域的右下角，不存在绕道区域外的可行路径，下面用反证法证明
        ///     假设存在一条绕到区域外的可行路径，假定区域内有鬼，显然鬼可以使用比可行路径更少（你在左上角，最远）的步骤到达终点等你，失败
        ///                                       那么只能是区域外有鬼，那么你就有区域内的可行路径了
        /// 有了这个证明才想到，这是个脑际急转弯，鬼如果比你离目的地远，你一定可以逃脱，否则，也不用BFS，鬼直接去目的地等你就可以了
        /// </summary>
        /// <param name="ghosts"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool EscapeGhosts(int[][] ghosts, int[] target)
        {
            int dist = Math.Abs(target[0]) + Math.Abs(target[1]);
            foreach (int[] ghost in ghosts)
            {
                if (Math.Abs(ghost[0] - target[0]) + Math.Abs(ghost[1] - target[1]) <= dist) return false;
            }

            return true;
        }
    }
}
