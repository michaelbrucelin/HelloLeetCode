using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3208
{
    public class Solution3208 : Interface3208
    {
        /// <summary>
        /// 滑动窗口，双指针
        /// 1. 如果整个数组中相邻元素都不同，那么结果就是数组的长度
        /// 2. 如果数组中有相邻相同的元素，那么从这个位置向后找相邻元素不同的段，每一段中有 pr-pl-k+2 个结果
        /// 3. 注意这里是环形数组
        /// 本质上，找到相邻的元素，那么以这个位置为起点，就不再是环形数组了
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumberOfAlternatingGroups(int[] colors, int k)
        {
            int result = 0, lcnt = 0, pl = 0, pr = 0, len = colors.Length;
            if (colors[0] != colors[^1])
            {
                while (++pl < len && colors[pl] != colors[pl - 1]) ;
                if (pl == len) return len;
                lcnt = pr = pl;
            }

            while (pr < len)
            {
                while (pr + 1 < len && colors[pr + 1] != colors[pr]) pr++;
                if (pr < len - 1)
                {
                    result += Math.Max(0, pr - pl - k + 2);
                    pl = ++pr;
                }
                else
                {
                    result += Math.Max(0, len - pl + lcnt - k + 1);
                    pr = len;
                }
            }

            return result;
        }
    }
}
