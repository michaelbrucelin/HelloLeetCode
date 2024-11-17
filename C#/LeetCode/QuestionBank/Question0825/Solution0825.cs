using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0825
{
    public class Solution0825 : Interface0825
    {
        /// <summary>
        /// 排序 + 双指针
        /// 只要同时满足下面两个条件即可
        ///     1. x > 14
        ///     2. y \in (x/2+7, x]
        /// 1. 由于年龄的范围为[1, 120]，直接计数排序
        /// 2. 有x个年龄相同的人，互相会有x(x-1)次请求，所以只考虑年龄不同的人的请求数量
        /// </summary>
        /// <param name="ages"></param>
        /// <returns></returns>
        public int NumFriendRequests(int[] ages)
        {
            int result = 0;
            int[] freq = new int[121];
            foreach (int age in ages) freq[age]++;
            List<int> _ages = new List<int>();
            for (int i = 1; i < 121; i++) if (freq[i] > 0)
                {
                    _ages.Add(i);
                    if (i > 14) result += freq[i] * (freq[i] - 1);
                }
            ages = null;  // wait GC

            int px = 0, py = 0, cnt = _ages.Count;
            while (++px < cnt)
            {
                while (_ages[py] <= _ages[px] / 2 + 7 && py < px) py++;
                for (int i = py; i < px; i++) result += freq[_ages[px]] * freq[_ages[i]];  // 这里可以优化为前缀和·参考官解
            }

            return result;
        }
    }
}
