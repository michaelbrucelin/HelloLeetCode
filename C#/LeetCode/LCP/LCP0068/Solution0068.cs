using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0068
{
    public class Solution0068 : Interface0068
    {
        /// <summary>
        /// 双指针，滑动窗口
        /// </summary>
        /// <param name="flowers"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public int BeautifulBouquet(int[] flowers, int cnt)
        {
            int result = 0, p1 = 0, p2 = -1, key = -1, len = flowers.Length;
            Dictionary<int, int> freq = new Dictionary<int, int>();
            while (p1 < len)
            {
                while (++p2 < len)
                {
                    key = flowers[p2];
                    if (freq.TryGetValue(key, out int val)) freq[key] = ++val; else freq.Add(key, 1);
                    if (freq[key] > cnt) break;
                }

                if (p2 == len)
                {
                    long x = len - p1;
                    result += (int)((x * (x + 1)) >> 1);
                    break;
                }
                else
                {
                    while (flowers[p1] != key)
                    {
                        result += p2 - p1;
                        freq[flowers[p1]]--;
                        p1++;
                    }
                    result += p2 - p1;
                    freq[flowers[p1]]--;
                    p1++;
                }
            }

            return result;
        }
    }
}
