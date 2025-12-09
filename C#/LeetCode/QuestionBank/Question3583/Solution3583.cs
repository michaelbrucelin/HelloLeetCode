using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3583
{
    public class Solution3583 : Interface3583
    {
        /// <summary>
        /// 二分
        /// 将每个值的id放入列表中，枚举中间的值即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SpecialTriplets(int[] nums)
        {
            int len = nums.Length;
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < len; i++) if (map.TryGetValue(nums[i], out var _list)) _list.Add(i); else map.Add(nums[i], [i]);

            long result = 0; int cnt, id;
            const int MOD = (int)1e9 + 7;
            if (map.TryGetValue(0, out var list0))
            {
                cnt = list0.Count;
                for (int i = 1; i < cnt; i++) result = (result + 1L * i * (cnt - i - 1)) % MOD;
                map.Remove(0);
            }

            foreach (int key in map.Keys) if (map.TryGetValue(key << 1, out var list))
                {
                    foreach (int target in map[key])
                    {
                        cnt = list.Count; id = 0;
                        id = binarysearch(list, id, cnt - 1, target);
                        if (id == cnt) break;
                        result = (result + 1L * id * (cnt - id)) % MOD;
                    }
                }

            return (int)result;

            int binarysearch(List<int> list, int left, int right, int target)
            {
                int result = list.Count, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (list[mid] > target)
                    {
                        result = mid; right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                return result;
            }
        }
    }
}
