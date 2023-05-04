using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2106
{
    public class Solution2106_4 : Interface2106
    {
        /// <summary>
        /// 枚举折返点 + 前缀和
        /// 1. 枚举折返点，解释见Solution2106_4.md
        /// 2. 折返点前与折返点后最远能走多远，前缀和可以解决
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="startPos"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxTotalFruits(int[][] fruits, int startPos, int k)
        {
            int result = 0, len = fruits.Length, startId = BinarySearch(fruits, startPos);
            if (startId == -1)
            {
                if (fruits[0][0] - startPos <= k)
                {
                    result = fruits[0][1]; k -= fruits[0][0] - startPos;
                    for (int i = 1; i < len && fruits[i][0] - fruits[i - 1][0] <= k; i++)
                    {
                        result += fruits[i][1]; k -= fruits[i][0] - fruits[i - 1][0];
                    }
                }
            }
            else if (startId == fruits.Length - 1)
            {
                if (startPos - fruits[len - 1][0] <= k)
                {
                    result = fruits[len - 1][1]; k -= startPos - fruits[len - 1][0];
                    for (int i = len - 2; i >= 0 && fruits[i + 1][0] - fruits[i][0] <= k; i--)
                    {
                        result += fruits[i][1]; k -= fruits[i + 1][0] - fruits[i][0];
                    }
                }
            }
            else
            {
                // 从startId开始向前的“前缀和”
                List<(int step, int cnt)> prev = new List<(int step, int cnt)>() { (startPos - fruits[startId][0], fruits[startId][1]) };
                for (int i = startId - 1, j = 0; i >= 0; i--, j++)
                {
                    // prev.Add((fruits[i + 1][0] - fruits[i][0] + prev[j].step, fruits[i][1] + prev[j].cnt));
                    prev.Add((startPos - fruits[i][0], fruits[i][1] + prev[j].cnt));
                    if (prev[j + 1].step >= k) break;
                }
                // 从startId开始向后的“前缀和”
                List<(int step, int cnt)> post = new List<(int step, int cnt)>() { (fruits[startId + 1][0] - startPos, fruits[startId + 1][1]) };
                for (int i = startId + 2, j = 0; i < len; i++, j++)
                {
                    // post.Add((fruits[i][0] - fruits[i - 1][0] + post[j].step, fruits[i][1] + post[j].cnt));
                    post.Add((fruits[i][0] - startPos, fruits[i][1] + post[j].cnt));
                    if (post[j + 1].step >= k) break;
                }
                // 向左枚举折返点
                for (int i = 0; i < prev.Count && prev[i].step <= k; i++)
                {
                    int _result = prev[i].cnt + BinarySearch2(post, k - (prev[i].step << 1));
                    result = Math.Max(result, _result);
                }
                // 向右枚举折返点
                for (int i = 0; i < post.Count && post[i].step <= k; i++)
                {
                    int _result = post[i].cnt + BinarySearch2(prev, k - (post[i].step << 1));
                    result = Math.Max(result, _result);
                }
            }

            return result;
        }

        /// <summary>
        /// 找出第一个小于等于startPos的position的id
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="startPos"></param>
        /// <returns></returns>
        private int BinarySearch(int[][] fruits, int startPos)
        {
            int result = -1, low = 0, high = fruits.Length - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (fruits[mid][0] < startPos)
                {
                    result = mid; low = mid + 1;
                }
                else if (fruits[mid][0] > startPos)
                {
                    high = mid - 1;
                }
                else  // if (fruits[mid][0] == startPos)
                {
                    result = mid; break;
                }
            }

            return result;
        }

        private int BinarySearch2(List<(int step, int cnt)> pre, int k)
        {
            int result = 0, low = 0, high = pre.Count - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (pre[mid].step <= k)
                {
                    result = pre[mid].cnt; low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result;
        }
    }
}
