using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0492
{
    public class Solution0492 : Interface0492
    {
        /// <summary>
        /// 分析
        /// 1. 如果area的平方根是整数，平方根就是解，否则
        /// 2. 如果area是偶数，从Floor(平方根)，依次减1，去验证
        ///              奇数，从Floor(平方根)与Floor(平方根)-1中的奇数开始，依次减2，去验证
        /// 注意，要从平方根向1验证，而不是从平方根向area验证，因为这样验证的次数更少
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public int[] ConstructRectangle(int area)
        {
            int sqrt = (int)Math.Sqrt(area);
            if (sqrt * sqrt == area) return new int[] { sqrt, sqrt };

            int start = sqrt, step = 1;
            if ((area & 1) != 0)
            {
                if ((start & 1) != 1) start--;
                step = 2;
            }

            for (int i = start; i > 1; i -= step)
            {
                if (area / i * i == area) return new int[] { area / i, i };
            }


            return new int[] { area, 1 };
        }
    }
}
