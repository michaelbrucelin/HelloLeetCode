using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3020
{
    public class Solution3020 : Interface3020
    {
        /// <summary>
        /// 哈希表 + 枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumLength(int[] nums)
        {
            Dictionary<long, int> freq = new Dictionary<long, int>();
            foreach (int num in nums) if (freq.TryGetValue(num, out int cnt)) freq[num] = ++cnt; else freq.Add(num, 1);
            Dictionary<int, int> memory = new Dictionary<int, int>();

            int result = 1, _result, x;
            if (freq.TryGetValue(1, out int _cnt)) { result = _cnt + (_cnt & 1) - 1; memory.Add(1, result); }
            foreach (int num in nums) if (!memory.ContainsKey(num))
                {
                    _result = 0;
                    x = num;
                    while (freq[x] > 1 && freq.ContainsKey(x = x * x)) _result += 2;
                    _result += 1;
                    memory.Add(num, _result);
                    result = Math.Max(result, _result);
                }

            return result;
        }

        /// <summary>
        /// 逻辑同MaximumLength()，稍加优化
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumLength2(int[] nums)
        {
            Dictionary<long, int> freq = new Dictionary<long, int>();
            int cnt;
            foreach (int num in nums) if (freq.TryGetValue(num, out cnt)) freq[num] = ++cnt; else freq.Add(num, 1);
            Dictionary<int, int> memory = new Dictionary<int, int>();

            int result = 1, _result, x;
            if (freq.TryGetValue(1, out cnt)) { result = cnt + (cnt & 1) - 1; memory.Add(1, result); }
            foreach (int num in nums) if (!memory.ContainsKey(num))
                {
                    _result = 0;
                    x = num;
                    while (freq[x] > 1 && freq.ContainsKey(x = x * x))
                    {
                        _result += 2;
                        if (memory.TryGetValue(x, out cnt))
                        {
                            _result += cnt; goto DONE;
                        }
                    }
                    _result += 1;
                DONE:;
                    memory.Add(num, _result);
                    result = Math.Max(result, _result);
                }

            return result;
        }
    }
}
