using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3007
{
    public class Solution3007 : Interface3007
    {
        /// <summary>
        /// 找规律 + 二分查找
        /// 参考Dial_1|2|3|4_1024.txt，找到规律后就变成易错题了，已经没什么难度了
        /// 以x = 3为例
        /// 二进制宽度  价值和  解释
        /// 1           0       显然是0个
        /// 2           0       显然是0个
        /// 3           4       2^(3-1)个
        /// 4           8       宽度为3的2倍
        /// 5           16      宽度为4的2倍
        /// 6           64      宽度为5的2倍 + 2^(6-1)
        /// 7           128     宽度为6的2倍
        /// 8           256     宽度为7的2倍
        /// 9           768     宽度为8的2倍 + 2^(9-1)
        /// 10          1536    宽度为9的2倍
        /// </summary>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public long FindMaximumNumber(long k, int x)
        {
            List<long> dstb = new List<long>();
            for (int i = 0; i < x; i++) dstb.Add(0);
            dstb.Add(1 << (x - 1));
            for (int i = x + 1; dstb[i - 1] <= k; i++)
                dstb.Add((dstb[i - 1] << 1) + (i % x == 0 ? (1L << (i - 1)) : 0));

            long result = 0, plus = 0; int find;
            while (k >= 0)
            {
                find = BinarySearch(k, plus);
                if (find == 0)
                {
                    if (plus <= k) result++;
                    break;
                }
                else
                {
                    result += 1L << find;
                    k -= dstb[find] + plus * (1L << find);
                    if ((find + 1) % x == 0) plus++;
                }
            }

            return result - 1;

            int BinarySearch(long target, long plus)
            {
                int result = 0, left = 1, right = dstb.Count - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (dstb[mid] + plus * (1L << mid) <= target)
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
}
