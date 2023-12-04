using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1423
{
    public class Solution1423 : Interface1423
    {
        /// <summary>
        /// 滑动窗口
        /// 无论怎么选，都是从中间扣掉len-k个元素
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
                int sum = 0;
                for (int i = 0; i < len; i++) sum += cardPoints[i];
                if (k == len) return sum;

                int win = 0, wid = len - k;
                for (int i = 0; i < wid; i++) win += cardPoints[i];
                result = sum - win;
                for (int i = wid; i < len; i++)
                {
                    win += cardPoints[i] - cardPoints[i - wid];
                    result = Math.Max(result, sum - win);
                }
            }

            return result;
        }
    }
}
