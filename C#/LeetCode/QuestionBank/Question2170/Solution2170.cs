using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2170
{
    public class Solution2170 : Interface2170
    {
        /// <summary>
        /// 哈希 + 分类讨论
        /// 最终数组的奇数位全部相同，偶数位全部相同，奇数位与偶数位不同
        /// 使用Hash预处理数组的奇数位与偶数位数字的频率然后分类讨论即可
        /// 
        /// 易错不算难，太恶心了，先不写了
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumOperations(int[] nums)
        {
            if (nums.Length == 1) return 0;
            if (nums.Length == 2) return nums[0] != nums[1] ? 0 : 1;

            int len = nums.Length;
            Dictionary<int, int>[] freqs = [new Dictionary<int, int>(), new Dictionary<int, int>()];
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (freqs[i & 1].TryGetValue(num, out int cnt)) freqs[i & 1][num] = ++cnt; else freqs[i & 1].Add(num, 1);
            }
            int[] cnts = [(len + 1) >> 1, len >> 1];

            int result = len, cnt01, cnt02, cnt11, cnt12;
            HashSet<int> key01 = [], key02 = [], key11 = [], key12 = [];
            switch ((freqs[0].Count, freqs[1].Count))
            {
                case (1, 1):
                    if (nums[0] != nums[1]) result = 0; else result = Math.Min(cnts[0], cnts[1]);
                    break;
                case (1, _):
                    cnt11 = cnt12 = 0; key11.Clear(); key12.Clear();
                    foreach (var kv in freqs[1])
                    {
                        if (kv.Value > cnt11) { cnt12 = cnt11; key12.Clear(); key12.UnionWith(key11); cnt11 = kv.Value; key11.Clear(); key11.Add(kv.Key); }
                        else if (kv.Value == cnt11) key11.Add(kv.Key);
                        else if (kv.Value > cnt12) { cnt12 = kv.Value; key12.Clear(); key12.Add(kv.Key); }
                        else if (kv.Value == cnt12) key12.Add(kv.Key);
                    }
                    // result = cnts[1] - cnt11 + ()
                    break;
                case (_, 1):

                    break;
                case (_, _):
                    break;
            }

            return result;
        }
    }
}
