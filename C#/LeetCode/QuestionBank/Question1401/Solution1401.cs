using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1401
{
    public class Solution1401 : Interface1401
    {
        /// <summary>
        /// 分析
        /// 具体见Solution1401.md
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="xCenter"></param>
        /// <param name="yCenter"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2)
        {
            if (xCenter - radius > x2 || xCenter + radius < x1 || yCenter - radius > y2 || yCenter + radius < y1) return false;        // 外切矩形无交集
            int rr = radius * radius;
            if (xCenter < x1 && yCenter > y2 && (x1 - xCenter) * (x1 - xCenter) + (y2 - yCenter) * (y2 - yCenter) > rr) return false;  // 左上
            if (xCenter > x2 && yCenter > y2 && (x2 - xCenter) * (x2 - xCenter) + (y2 - yCenter) * (y2 - yCenter) > rr) return false;  // 右上
            if (xCenter > x2 && yCenter < y1 && (x2 - xCenter) * (x2 - xCenter) + (y1 - yCenter) * (y1 - yCenter) > rr) return false;  // 右下
            if (xCenter < x1 && yCenter < y1 && (x1 - xCenter) * (x1 - xCenter) + (y1 - yCenter) * (y1 - yCenter) > rr) return false;  // 左下

            return true;
        }
    }
}
