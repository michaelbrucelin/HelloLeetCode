using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3138
{
    public class Solution3138 : Interface3138
    {
        /// <summary>
        /// 暴力尝试 + 前缀和
        /// 将s分成长度相等的n段后，如果每一段的每个字母出现的频次相同即可
        /// 所以从长度为1的字串开始尝试，可以使用前缀和优化计算每个字串中字母出现的频次
        /// 
        /// 如果有单调性，可以使用二分法，但是这里没有单调性，例如：s = "abbaab"，3是不可以的，但是2是可以的
        /// 如果题目测试的结果通常都很小，前缀和会拖慢速度
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinAnagramLength(string s)
        {
            int len = s.Length;
            int[,] pre = new int[len + 1, 26];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 26; j++) pre[i + 1, j] = pre[i, j];
                pre[i + 1, s[i] - 'a']++;
            }

            for (int span = 1, times; span < len; span++) if (len % span == 0)
                {
                    times = len / span;
                    for (int time = 1, pl = 0, pr = 0; time < times; time++)
                    {
                        pl = span * time; pr = pl + span;
                        for (int i = 0; i < 26; i++)
                        {
                            if (pre[pr, i] - pre[pl, i] != pre[span, i]) goto CONTINUE;
                        }
                    }
                    return span;
                CONTINUE:;
                }

            return len;
        }
    }
}
