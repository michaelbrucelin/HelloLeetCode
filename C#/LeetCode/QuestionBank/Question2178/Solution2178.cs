using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2178
{
    public class Solution2178 : Interface2178
    {
        /// <summary>
        /// 贪心 + 数学
        /// 1. 如果finalSum是奇数，无解
        /// 2. 如果存在整数n，使2+4+6+8+...+2n=n(n+1) = finalSum，那么2,4,6,8,...,2n就是解
        /// 3. 如果不存在条件2的n，那么必存在整数n使 2+4+6+8+...+2n=n(n+1) < finalSum < 2+4+6+8+...+2n+(2n+2)=(n+1)(n+2)
        ///     那么此时只需要将 2n 增大，使其序列和等于finalSum即可
        /// 2+4+6+8+...+2n=n(n+1) = finalSum
        /// n = Sqrt(finalSum + 1/4) - 1/2
        /// </summary>
        /// <param name="finalSum"></param>
        /// <returns></returns>
        public IList<long> MaximumEvenSplit(long finalSum)
        {
            if ((finalSum & 1) != 0) return new List<long>();

            long n = (long)Math.Floor(Math.Sqrt(finalSum + 0.25) - 0.5);
            List<long> result = new List<long>();
            for (long i = 1; i < n; i++) result.Add(i << 1);
            if (n * (n + 1) == finalSum)
                result.Add(n << 1);
            else
                result.Add(finalSum - n * (n - 1));

            return result;
        }
    }
}
