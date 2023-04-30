using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1234
{
    public class Solution1234 : Interface1234
    {
        /// <summary>
        /// 分析 + 前缀和
        /// 假设s的长度为4n，即Q W E R每一种字母的数量为n
        /// 如果Q W E R的数量不平衡，必然有的字母（1-3种）数量大于n，只要将这部分字母给替换掉即可
        ///     假设有三个字母数量大于n，分别是n+k1, n+k2, n+k3个，那么只要找到一个最短的字串，其中含有k1个X1，k2个X2，k3个X3即可
        ///     有两个或一个字母大于n同理
        /// 如何快速找出符合前面要求的字串
        ///     预处理4种字符的前缀和即可
        /// 小技巧：使用位运算 (char >> 1) & 3 ，将 Q R E W 分别映射为 0 1 2 3
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int BalancedString(string s)
        {
            int len = s.Length;
            int[,] cnt_pre = new int[4, len + 1];
            for (int i = 0; i < len; i++) for (int j = 0, id = (s[i] >> 1) & 3; j < 4; j++)
                {
                    cnt_pre[j, i + 1] = j != id ? cnt_pre[j, i] : cnt_pre[j, i] + 1;
                }

            int[] cnt_tgt = new int[4]; int n = len >> 2;  // 题目保证s的长度是4的倍数
            for (int i = 0; i < 4; i++) cnt_tgt[i] = cnt_pre[i, len] - n;

            int width = 0;
            for (int i = 0; i < 4; i++) if (cnt_tgt[i] > 0) width += cnt_tgt[i];
            if (width == 0) return 0;
            for (; width < len; width++) for (int i = width; i <= len; i++)
                {
                    bool flag = true;
                    for (int j = 0; j < 4; j++)
                    {
                        if (cnt_tgt[j] > 0 && cnt_pre[j, i] - cnt_pre[j, i - width] < cnt_tgt[j])
                        {
                            flag = false; break;
                        }
                    }
                    if (flag) return width;
                }

            return -1;
        }

        /// <summary>
        /// 与BalancedString()相同，只是把Q W E R与数字的映射改为了更通用的Hash表
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int BalancedString2(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>() { { 'Q', 0 }, { 'W', 1 }, { 'E', 2 }, { 'R', 3 } };
            int len = s.Length;
            int[,] cnt_pre = new int[4, len + 1];
            for (int i = 0; i < len; i++) for (int j = 0, id = map[s[i]]; j < 4; j++)
                {
                    cnt_pre[j, i + 1] = j != id ? cnt_pre[j, i] : cnt_pre[j, i] + 1;
                }

            int[] cnt_tgt = new int[4]; int n = len >> 2;  // 题目保证s的长度是4的倍数
            for (int i = 0; i < 4; i++) cnt_tgt[i] = cnt_pre[i, len] - n;

            int width = 0;
            for (int i = 0; i < 4; i++) if (cnt_tgt[i] > 0) width += cnt_tgt[i];
            if (width == 0) return 0;
            for (; width < len; width++) for (int i = width; i <= len; i++)
                {
                    bool flag = true;
                    for (int j = 0; j < 4; j++)
                    {
                        if (cnt_tgt[j] > 0 && cnt_pre[j, i] - cnt_pre[j, i - width] < cnt_tgt[j])
                        {
                            flag = false; break;
                        }
                    }
                    if (flag) return width;
                }

            return -1;
        }
    }
}
