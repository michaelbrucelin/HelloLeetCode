using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3443
{
    public class Solution3443 : Interface3443
    {
        /// <summary>
        /// 贪心，遍历
        /// 遍历，记录当前位置的距离，以及抵消（南北，东西）的次数，更改一次抵消，距离+2
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxDistance(string s, int k)
        {
            int result = 0, _result, len = s.Length;
            Dictionary<char, int> map = new() { { 'N', 0 }, { 'S', 1 }, { 'E', 2 }, { 'W', 3 } };
            int[] cnt = new int[4];
            for (int i = 0; i < len; i++)
            {
                cnt[map[s[i]]]++;
                _result = Math.Abs(cnt[0] - cnt[1]) + Math.Abs(cnt[2] - cnt[3]);
                _result += (Math.Min(Math.Min(cnt[0], cnt[1]) + Math.Min(cnt[2], cnt[3]), k) << 1);
                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}
