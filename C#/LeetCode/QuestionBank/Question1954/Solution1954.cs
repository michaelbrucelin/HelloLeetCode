using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1954
{
    public class Solution1954 : Interface1954
    {
        /// <summary>
        /// 二分法
        /// 如果边长为2x，一个象限的种树数量为：x(x+1)^2，四个象限总种树数量为：4x(x+1)^2-2x(x+1) = 2x(x+1)(2x+1)
        /// </summary>
        /// <param name="neededApples"></param>
        /// <returns></returns>
        public long MinimumPerimeter(long neededApples)
        {
            long result = -1, _result, low = 1, high = 100000, mid;  // 根据上面的推导，high = 100000足够了
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                _result = (mid * (mid + 1) << 1) * ((mid << 1) + 1);
                if (_result >= neededApples)
                {
                    result = mid << 3; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}
