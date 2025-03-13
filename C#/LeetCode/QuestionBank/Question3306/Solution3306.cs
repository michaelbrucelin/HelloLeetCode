using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3306
{
    public class Solution3306 : Interface3306
    {
        /// <summary>
        /// 类前缀和 + 二分
        /// 逻辑同Solution3306
        /// </summary>
        /// <param name="word"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountOfSubstrings(string word, int k)
        {
            long result = 0;
            int len = word.Length;
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            int[,] pres = new int[len + 1, 6];  // 类前缀和
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 6; j++) pres[i + 1, j] = pres[i, j];
                switch (word[i])
                {
                    case 'a': pres[i + 1, 0]++; break;
                    case 'e': pres[i + 1, 1]++; break;
                    case 'i': pres[i + 1, 2]++; break;
                    case 'o': pres[i + 1, 3]++; break;
                    case 'u': pres[i + 1, 4]++; break;
                    default: pres[i + 1, 5]++; break;
                }
            }
            int[] sufs = new int[len];  // 预处理每个字母后面有几个连续的元音字母
            for (int i = len - 2; i >= 0; i--) sufs[i] = vowels.Contains(word[i + 1]) ? sufs[i + 1] + 1 : 0;

            int border = len - k - 4;   // 至少需要k+5个字符
            for (int l = 0, r; l < len; l++)
            {
                if ((r = binary_search(l)) == len) continue;
                result += sufs[r] + 1;
            }

            return result;

            int binary_search(int idx)
            {
                int result = len, l = idx, r = len - 1, mid = -1;
                while (l <= r)  // 二分查找第一个满足条件的子字符串的右端点
                {
                    mid = l + ((r - l) >> 1);
                    switch (pres[mid + 1, 5] - pres[idx, 5] - k)
                    {
                        case < 0:
                            {
                                l = mid + 1; break;
                            }
                        case > 0:
                            {
                                if (check(idx, mid)) r = mid - 1; else goto ENDWHILE;
                                break;
                            }
                        default:
                            {
                                if (check(idx, mid))
                                {
                                    result = mid; r = mid - 1;
                                }
                                else
                                {
                                    l = mid + 1;
                                }
                                break;
                            }
                    }
                }
            ENDWHILE:;

                return result;
            }

            bool check(int l, int r)
            {
                r++;
                return pres[r, 0] - pres[l, 0] >= 1
                    && pres[r, 1] - pres[l, 1] >= 1
                    && pres[r, 2] - pres[l, 2] >= 1
                    && pres[r, 3] - pres[l, 3] >= 1
                    && pres[r, 4] - pres[l, 4] >= 1;
                // && pres[r, 5] - pres[l, 5] == k;
            }
        }
    }
}
