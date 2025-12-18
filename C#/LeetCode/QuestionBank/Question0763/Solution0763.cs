using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0763
{
    public class Solution0763 : Interface0763
    {
        /// <summary>
        /// 贪心
        /// 记录每个字母最后出现的位置即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<int> PartitionLabels(string s)
        {
            int[] rpos = new int[26];
            Array.Fill(rpos, -1);
            int len = s.Length, cnt = 0;
            for (int i = len - 1; i >= 0 && cnt < 26; i--) if (rpos[s[i] - 'a'] == -1)
                {
                    rpos[s[i] - 'a'] = i; cnt++;
                }

            IList<int> result = new List<int>();
            for (int i = 0, j, k; i < len;)
            {
                for (j = i, k = rpos[s[i] - 'a']; j < k; j++) k = Math.Max(k, rpos[s[j] - 'a']);
                result.Add(j - i + 1);
                i = j + 1;
            }

            return result;
        }
    }
}
