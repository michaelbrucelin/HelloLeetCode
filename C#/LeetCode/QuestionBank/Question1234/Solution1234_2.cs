using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1234
{
    public class Solution1234_2 : Interface1234
    {
        /// <summary>
        /// 与Solution1234逻辑一样，但是在查找的阶段使用二分法来加速查找
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

            int result = len, low = width, high = len, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                bool flag = false;
                for (int i = mid; i <= len; i++)
                {
                    flag = true;
                    for (int j = 0; j < 4; j++)
                    {
                        if (cnt_tgt[j] > 0 && cnt_pre[j, i] - cnt_pre[j, i - mid] < cnt_tgt[j])
                        {
                            flag = false; break;
                        }
                    }
                    if (flag) break;
                }

                if (flag)
                {
                    result = mid; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}
