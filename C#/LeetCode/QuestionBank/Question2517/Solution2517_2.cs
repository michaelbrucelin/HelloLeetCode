using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LeetCode.QuestionBank.Question2517
{
    public class Solution2517_2 : Interface2517
    {
        /// <summary>
        /// 排序 + 二分查找
        /// 与Solution2517逻辑一样，但是将依次验证N, N-1, N-2 ... 1，改为二分法验证
        /// </summary>
        /// <param name="price"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumTastiness(int[] price, int k)
        {
            Array.Sort(price);
            int max_r = (int)Math.Floor((double)(price[^1] - price[0]) / (k - 1));
            int result = 0, low = 1, high = max_r, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (IsTastiness(price, k, mid))
                {
                    result = mid; low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result;
        }

        private bool IsTastiness(int[] price, int k, int r)
        {
            int next = 0, cnt = 1;
            while (true)
            {
                next = BinarySearch(price, next + 1, price[next] + r);
                if (next == -1) break;                                 // 剪枝，找不到合适的值
                if (++cnt == k) return true;                           // 找到结果
                if ((price[^1] - price[next]) / (k - cnt) < r) break;  // 剪枝，余下的不够分的
            }

            return false;
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
