using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2572
{
    public class Solution2572 : Interface2572
    {
        /// <summary>
        /// 二进制枚举
        /// 1. 如果一个数字自身就包含平方因子，那么这个数字直接忽略就可以了
        /// 2. 自己一定不会包含相同的数字，所以统计每个数字的数量，然后只需要考虑不同的数字就可以了
        /// 3. 每个元素都小于等于30，所以最多只有19个不包含平方因子的数字，总方案数为 2^19 = 524288 种可能性
        ///        小于等于30的平方因子只有4, 9, 25，所以直接尝试除4，除9，除25即可
        /// 4. 小于30的质数有10个，所以将每个数字表示为这10个质数的因子的mask形式，这样乘积后是否有平方因子就变成了mask1&mask2 == 0的验证了
        /// 5. 1特殊处理
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SquareFreeSubsets(int[] nums)
        {
            // 预处理
            const int MOD = (int)1e9 + 7;
            int cnt1 = 1;
            int[] primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29];
            int[] map = new int[31];
            for (int i = 2, x; i < 31; i++) if ((i & 3) != 0 && i % 9 != 0 && i % 25 != 0)
                {
                    x = i;
                    for (int j = 0; j < 10 && x > 1; j++) if (x % primes[j] == 0)
                        {
                            map[i] |= 1 << j; x /= primes[j];
                        }
                }

            // 预处理原数组
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int x in nums)
            {
                if (x == 1) cnt1 = (cnt1 << 1) % MOD;
                else if (map[x] != 0)
                {
                    if (freq.TryGetValue(map[x], out int _cnt)) freq[map[x]] = ++_cnt; else freq.Add(map[x], 1);
                }
            }
            int id = 0, len = freq.Count;
            int[] keys = new int[len], cnts = new int[len];
            foreach (int key in freq.Keys) { keys[id] = key; cnts[id++] = freq[key]; }

            // 二进制枚举
            int result = cnt1 - 1, MASK = 1 << len, prod; long cnt;
            for (int i = 1, mask, offset; i < MASK; i++)
            {
                mask = i; offset = 0; prod = 0; cnt = 1;
                while (mask > 0)
                {
                    if ((mask & 1) != 0)
                    {
                        if ((prod & keys[offset]) != 0) goto CONTINUE;
                        prod |= keys[offset];
                        cnt = cnt * cnts[offset] % MOD;
                    }
                    mask >>= 1; offset++;
                }
                cnt = cnt * cnt1 % MOD;
                result = (int)((result + cnt) % MOD);
            CONTINUE:;
            }

            return result;
        }
    }
}
