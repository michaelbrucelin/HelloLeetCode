using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1566
{
    public class Solution1566 : Interface1566
    {
        /// <summary>
        /// 暴力查找
        /// 本质上就是查找字符串
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsPattern(int[] arr, int m, int k)
        {
            int len = arr.Length;
            if (m * k > len) return false;

            bool flag;
            int start = 0; while (start <= len - m * k)  // start为模式第一次出现的起点
            {
                int i; for (i = 0; i < m; i++)
                {
                    flag = true;
                    for (int j = 1; j < k; j++)
                    {
                        if (arr[start + j * m + i] != arr[start + i]) { flag = false; break; }
                    }
                    if (!flag) break;
                }
                if (i == m) return true;
                start += i + 1;
            }

            return false;
        }

        /// <summary>
        /// 暴力查找 + 前缀和
        /// 这里前缀和相当于hash验证
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsPattern2(int[] arr, int m, int k)
        {
            int len = arr.Length;
            if (m * k > len) return false;

            int[] pre = new int[len + 1];
            for (int i = 0; i < len; i++) pre[i + 1] = pre[i] + arr[i];

            bool flag;
            int start = 0, add; while (start <= len - m * k)  // start为模式第一次出现的起点
            {
                add = pre[start + m] - pre[start];
                flag = true; for (int j = 1; j < k; j++)
                {
                    if (pre[start + m * j + m] - pre[start + m * j] != add) { flag = false; break; }
                }

                if (!flag) start++;
                else
                {
                    int i; for (i = 0; i < m; i++)
                    {
                        flag = true;
                        for (int j = 1; j < k; j++)
                        {
                            if (arr[start + j * m + i] != arr[start + i]) { flag = false; break; }
                        }
                        if (!flag) break;
                    }
                    if (i == m) return true;
                    start += i + 1;
                }
            }

            return false;
        }
    }
}
