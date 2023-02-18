using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1237
{
    public class Solution1237 : Interface1237
    {
        /// <summary>
        /// 逐步二分
        /// 1. x遍历[1, 1000]，对于每个x，用二分法查找y，如果不存在解，那么就找到最小的ymax，使得f(x,ymin) > z
        /// 2. 下一轮x++，此时y只需在[1, ymax-1]中二分查找即可
        /// 3. 直至x=1000或ymax=1，x遍历结束
        /// </summary>
        /// <param name="customfunction"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
        {
            List<IList<int>> result = new List<IList<int>>();
            for (int x = 1, ymin = 1, ymax = 1000; x <= 1000 && ymax >= 1; x++, ymin = 1)
            {
                while (ymin <= ymax)
                {
                    int y = ymin + ((ymax - ymin) >> 1), _z = customfunction.f(x, y);
                    if (_z == z)
                    {
                        result.Add(new int[] { x, y }); ymax = y - 1;
                        break;
                    }
                    else if (_z > z)
                    {
                        ymax = y - 1;
                    }
                    else  // if (_z < z)
                    {
                        ymin = y + 1;
                    }
                }
            }

            return result;
        }
    }
}
