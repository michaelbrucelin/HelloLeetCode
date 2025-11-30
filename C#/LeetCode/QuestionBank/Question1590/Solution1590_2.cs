using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1590
{
    public class Solution1590_2 : Interface1590
    {
        /// <summary>
        /// 前缀模 + hash + 双指针
        /// 1. 计算前缀和数组
        /// 2. 将前缀和改为前缀模，即前缀和的每一项对p取模
        /// 3. 按照取模结果分组
        /// 4. 假定整个数组和对p取余为m，那么前缀模数组第一项取余x，第二项取余(x+m)%p即是一个解
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public int MinSubarray(int[] nums, int p)
        {
            int len = nums.Length, pmod = 0;
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>() { { 0, [0] } };
            for (int i = 0; i < len; i++)
            {
                pmod = (pmod + nums[i]) % p;
                if (map.TryGetValue(pmod, out List<int> list)) list.Add(i + 1); else map.Add(pmod, [i + 1]);
            }
            if (pmod == 0) return 0;

            int result = len, mod2, p1, p2; List<int> list1;
            foreach (int mod1 in map.Keys)
            {
                mod2 = (mod1 + pmod) % p;
                if (map.TryGetValue(mod2, out List<int> list2))
                {
                    list1 = map[mod1];
                    p1 = p2 = 0;
                    while (p1 < list1.Count && p2 < list2.Count)
                    {
                        while (p2 < list2.Count && list2[p2] < list1[p1]) p2++;
                        if (p2 < list2.Count) result = Math.Min(result, list2[p2] - list1[p1]);
                        if (result == 1) return 1;
                        p1++;
                    }
                }
            }

            return result != len ? result : -1;
        }
    }
}
