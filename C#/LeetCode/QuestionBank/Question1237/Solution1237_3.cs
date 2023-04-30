using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1237
{
    public class Solution1237_3 : Interface1237
    {
        /// <summary>
        /// 双指针
        /// 没有自己的解法（Solution1237）快，这里写着玩
        /// </summary>
        /// <param name="customfunction"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
        {
            List<IList<int>> result = new List<IList<int>>();
            int x = 0, y = 1000;
            while (++x <= 1000 && y >= 1)
            {
                while (y >= 1 && customfunction.f(x, y) > z) y--;
                if (y >= 1 && customfunction.f(x, y) == z)
                {
                    result.Add(new int[] { x, y });
                    y--;
                }
            }

            return result;
        }
    }
}
