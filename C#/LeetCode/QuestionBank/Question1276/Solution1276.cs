using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1276
{
    public class Solution1276 : Interface1276
    {
        /// <summary>
        /// 数学
        /// 二元一次方程组，鸡兔同笼
        /// 巨无霸 = (tomatoSlices - cheeseSlices * 2)/2
        /// 小皇堡 = cheeseSlices - 巨无霸
        /// </summary>
        /// <param name="tomatoSlices"></param>
        /// <param name="cheeseSlices"></param>
        /// <returns></returns>
        public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices)
        {
            if ((tomatoSlices & 1) == 1) return new int[] { };

            int x = (tomatoSlices - (cheeseSlices << 1)) >> 1;
            int y = cheeseSlices - x;
            if (x < 0 || y < 0) return new int[] { };

            return new int[] { x, y };
        }
    }
}
