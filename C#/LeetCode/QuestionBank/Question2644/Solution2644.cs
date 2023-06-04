using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2644
{
    public class Solution2644 : Interface2644
    {
        public int MaxDivScore(int[] nums, int[] divisors)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
                if (freq.ContainsKey(nums[i])) freq[nums[i]]++; else freq.Add(nums[i], 1);
            HashSet<int> set = new HashSet<int>(divisors);

            int cnt = 0, val = int.MaxValue, _cnt;
            foreach (int num in set)
            {
                _cnt = 0;
                foreach (var kv in freq) if (kv.Key % num == 0) _cnt += kv.Value;
                if (_cnt > cnt || (_cnt == cnt && num < val))
                {
                    cnt = _cnt; val = num;
                }
            }

            return val;
        }
    }
}
