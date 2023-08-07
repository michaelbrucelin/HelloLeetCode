using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1869
{
    public class Solution1869 : Interface1869
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CheckZeroOnes(string s)
        {
            int[] cnt = new int[2], _cnt = new int[2];
            int id; char last = '\0', curr;
            for (int i = 0; i < s.Length; i++)
            {
                curr = s[i];
                if (curr != last)
                {
                    id = 1 - (curr - '0');
                    cnt[id] = Math.Max(cnt[id], _cnt[id]);
                    _cnt[id] = 0; _cnt[1 - id] = 1;
                }
                else
                {
                    _cnt[curr - '0']++;
                }

                last = curr;
            }
            id = last - '0';
            cnt[id] = Math.Max(cnt[id], _cnt[id]);

            return cnt[1] > cnt[0];
        }
    }
}
