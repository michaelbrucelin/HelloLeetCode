using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0836
{
    public class Solution0836 : Interface0836
    {
        /// <summary>
        /// 分析
        /// 与数轴上的两个范围求交集一个道理
        /// 如果两个矩形相交，相交的还是矩形
        ///     左下顶点是两个矩形左下顶点向右上取的结果
        ///     右上顶点是两个矩形右上顶点向左下取的结果
        /// 画画图一目了然，是不是能扩展到更高维的空间
        /// </summary>
        /// <param name="rec1"></param>
        /// <param name="rec2"></param>
        /// <returns></returns>
        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            int ld_x = Math.Max(rec1[0], rec2[0]), ld_y = Math.Max(rec1[1], rec2[1]);
            int ru_x = Math.Min(rec1[2], rec2[2]), ru_y = Math.Min(rec1[3], rec2[3]);

            return ld_x < ru_x && ld_y < ru_y;
        }
    }
}
