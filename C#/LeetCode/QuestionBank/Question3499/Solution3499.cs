using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3499
{
    public class Solution3499 : Interface3499
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxActiveSectionsAfterTrade(string s)
        {
            int cnt1 = 0, d = 1, _d, _cnt = 0;
            List<int> cnts = [];                // 记录连续的1的数量，0的数量，第一个值一定是1的数量
            foreach (char c in s)
            {
                cnt1 += _d = c - '0';
                if (_d == d)
                {
                    _cnt++;
                }
                else
                {
                    cnts.Add(_cnt); _cnt = 1; d = 1 - d;
                }
            }
            cnts.Add(_cnt);

            int cnt = cnts.Count, cnt0 = 0;
            for (int i = 3; i < cnt; i += 2) cnt0 = Math.Max(cnt0, cnts[i - 2] + cnts[i]);
            return cnt1 + cnt0;
        }

        /// <summary>
        /// 逻辑同MaxActiveSectionsAfterTrade()，压缩一下缓存，省点内存
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxActiveSectionsAfterTrade2(string s)
        {
            int cnt1 = 0, cnt0 = 0, idx = 0, d = 1, _d, _cnt = 0;
            int[] cnts = new int[4];                               // 记录连续的1的数量，0的数量，第一个值一定是1的数量
            foreach (char c in s)
            {
                cnt1 += _d = c - '0';
                if (_d == d)
                {
                    _cnt++;
                }
                else
                {
                    cnts[idx++] = _cnt; _cnt = 1; d = 1 - d;
                    if (idx == 4)
                    {
                        cnt0 = Math.Max(cnt0, cnts[1] + cnts[3]);
                        cnts[1] = cnts[3];
                        idx = 2;
                    }
                }
            }
            cnts[idx++] = _cnt;
            if (idx == 4) cnt0 = Math.Max(cnt0, cnts[1] + cnts[3]);

            return cnt1 + cnt0;
        }
    }
}
