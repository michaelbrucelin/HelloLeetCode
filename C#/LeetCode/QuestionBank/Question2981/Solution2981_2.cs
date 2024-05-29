using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2981
{
    public class Solution2981_2 : Interface2981
    {
        /// <summary>
        /// 逻辑同Solution2981，只是不需要记录每一个字符的全部长度，只需要记录最长的3个长度即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaximumLength(string s)
        {
            int[,] lens = new int[26, 3];
            int pl = 0, pr, l, id, len = s.Length;
            while (pl < len)
            {
                pr = pl; id = s[pl] - 'a';
                while (pr + 1 < len && s[pr + 1] == s[pl]) pr++;
                l = pr - pl + 1;
                if (l > lens[id, 0])
                {
                    lens[id, 2] = lens[id, 1]; lens[id, 1] = lens[id, 0]; lens[id, 0] = l;
                }
                else if (l > lens[id, 1])
                {
                    lens[id, 2] = lens[id, 1]; lens[id, 1] = l;
                }
                else if (l > lens[id, 2])
                {
                    lens[id, 2] = l;
                }
                pl = pr + 1;
            }

            int result = 0;
            for (int i = 0; i < 26; i++)
            {
                result = Math.Max(result, lens[i, 2]);
                result = Math.Max(result, Math.Min(lens[i, 1], lens[i, 0] - 1));
                result = Math.Max(result, lens[i, 0] - 2);
            }

            return result != 0 ? result : -1;
        }
    }
}
