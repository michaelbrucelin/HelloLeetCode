using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1953
{
    public class Solution1953 : Interface1953
    {
        /// <summary>
        /// 构造 + 数学
        /// 例如 [5, 2, 1] 构造为
        /// 0 0 0 0 0
        /// 1 1 2
        /// 即最多的元素为第一行，然后依次填充下面的每一行，取值的时候，竖向取，即
        /// 0 1 0 1 0 2 0
        /// 再例如 [5 ,4, 3, 2, 1] 构造为
        /// 0 0 0 0 0
        /// 1 1 1 1 2
        /// 2 2 3 3 4
        /// 所以，除非第二行没满，否则一定可以取到全部的值（证明略）
        /// </summary>
        /// <param name="milestones"></param>
        /// <returns></returns>
        public long NumberOfWeeks(int[] milestones)
        {
            long total = 0; int max = -1, len = milestones.Length;
            for (int i = 0; i < len; i++)
            {
                total += milestones[i]; max = Math.Max(max, milestones[i]);
            }

            return max <= ((total + 1) >> 1) ? total : ((total - max) << 1) + 1;
        }
    }
}
