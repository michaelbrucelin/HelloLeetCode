using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0157
{
    public class Solution0157 : Interface0157
    {
        /// <summary>
        /// 下一个更大的排列
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public string[] GoodsOrder(string goods)
        {
            char[] buffer = [.. goods];
            Array.Sort(buffer);
            List<string> result = [new string(buffer)];
            int len = buffer.Length, i, j, lo, hi, mid;
            while (true)
            {
                for (i = len - 1; i > 0 && buffer[i - 1] >= buffer[i]; i--) ;
                if (i == 0) break;
                j = lo = i; hi = len - 1;
                while (lo <= hi)
                {
                    mid = lo + ((hi - lo) >> 1);
                    if (buffer[mid] > buffer[i - 1]) { j = mid; lo = mid + 1; } else { hi = mid - 1; }
                }
                (buffer[i - 1], buffer[j]) = (buffer[j], buffer[i - 1]);
                for (int l = i, r = len - 1; l < r; l++, r--) (buffer[l], buffer[r]) = (buffer[r], buffer[l]);
                result.Add(new string(buffer));
            }

            return [.. result];
        }

        /// <summary>
        /// 下一个更小的排列
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public string[] GoodsOrder2(string goods)
        {
            char[] buffer = [.. goods];
            Array.Sort(buffer, (x, y) => y - x);
            List<string> result = [new string(buffer)];
            int len = buffer.Length, i, j, lo, hi, mid;
            while (true)
            {
                for (i = len - 1; i > 0 && buffer[i - 1] <= buffer[i]; i--) ;
                if (i == 0) break;
                j = lo = i; hi = len - 1;
                while (lo <= hi)
                {
                    mid = lo + ((hi - lo) >> 1);
                    if (buffer[mid] < buffer[i - 1]) { j = mid; lo = mid + 1; } else { hi = mid - 1; }
                }
                (buffer[i - 1], buffer[j]) = (buffer[j], buffer[i - 1]);
                for (int l = i, r = len - 1; l < r; l++, r--) (buffer[l], buffer[r]) = (buffer[r], buffer[l]);
                result.Add(new string(buffer));
            }

            return [.. result];
        }
    }
}
