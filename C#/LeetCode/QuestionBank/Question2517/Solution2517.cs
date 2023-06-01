using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2517
{
    public class Solution2517 : Interface2517
    {
        /// <summary>
        /// 排序 + 二分查找
        /// 1. 将price从大到小排序
        /// 2. 数学上可以得到理论上最大的结果是：N = Math.Floor((price.max - price.min)/(k - 1))
        /// 3. 依次验证N, N-1, N-2 ... 1，第一个验证通过的就是正确结果
        ///     验证N的话，第1个值（最小值）是一定要选的，
        ///                第2个值至少是price.min+N，二分法可以快速找到这个值
        ///                第3个值依次类推
        ///                注意每找到一个值，都检查一下剩余的值够不够分的，即 (price.max - N')/余下有几份，如果这个结果小于N，就剪枝去验证N-1
        /// 时间复杂度：
        /// 1. 排序需要nlogn
        /// 2. 验证需要...，不分析了
        /// 
        /// 逻辑没问题，提交会超时，参考测试用例04
        /// </summary>
        /// <param name="price"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumTastiness(int[] price, int k)
        {
            Array.Sort(price);
            int next, cnt, max_r = (int)Math.Floor((double)(price[^1] - price[0]) / (k - 1));
            for (int r = max_r; r > 0; r--)
            {
                next = 0; cnt = 1;
                while (true)
                {
                    next = BinarySearch(price, next + 1, price[next] + r);
                    if (next == -1) break;                                 // 剪枝，找不到合适的值
                    if (++cnt == k) return r;                              // 找到结果
                    if ((price[^1] - price[next]) / (k - cnt) < r) break;  // 剪枝，余下的不够分的
                }
            }

            return 0;
        }

        /// <summary>
        /// 从start开始找第一个大于等于target的索引
        /// </summary>
        /// <param name="price"></param>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearch(int[] price, int start, int target)
        {
            int result = -1, low = start, high = price.Length - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (price[mid] >= target)
                {
                    result = mid; high = mid - 1;
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
