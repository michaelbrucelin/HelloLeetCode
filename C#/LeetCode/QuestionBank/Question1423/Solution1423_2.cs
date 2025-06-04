using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1423
{
    public class Solution1423_2 : Interface1423
    {
        /// <summary>
        /// 前缀和
        /// 无论怎么选，都是从前面选择n个元素，从后面选择k-n个元素
        /// 本质上与Solution1423逻辑相同
        /// </summary>
        /// <param name="cardPoints"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxScore(int[] cardPoints, int k)
        {
            int result, len = cardPoints.Length;
            if (k == 1)
            {
                result = Math.Max(cardPoints[0], cardPoints[len - 1]);
            }
            else
            {
                int[] pre = new int[len + 1];
                for (int i = 0; i < len; i++) pre[i + 1] = pre[i] + cardPoints[i];
                if (k == len) return pre[len];

                result = 0;
                for (int i = 0; i <= k; i++)
                {
                    result = Math.Max(result, pre[i] + pre[len] - pre[len - k + i]);
                }
            }

            return result;
        }
    }
}
