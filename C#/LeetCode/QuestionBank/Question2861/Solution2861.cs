using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2861
{
    public class Solution2861 : Interface2861
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <param name="budget"></param>
        /// <param name="composition"></param>
        /// <param name="stock"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MaxNumberOfAlloys(int n, int k, int budget, IList<IList<int>> composition, IList<int> stock, IList<int> cost)
        {
            int result = 0, left = 0, right = int.MaxValue, mid;
            bool flag; long _cost;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1); flag = false;
                for (int i = 0; i < k; i++)
                {
                    _cost = 0;
                    for (int j = 0; j < n; j++)
                    {
                        _cost += Math.Max((long)composition[i][j] * mid - stock[j], 0) * cost[j];
                        if (_cost > budget) goto CONTINUE;
                    }
                    flag = true; break;
                    CONTINUE:;
                }

                if (flag)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
