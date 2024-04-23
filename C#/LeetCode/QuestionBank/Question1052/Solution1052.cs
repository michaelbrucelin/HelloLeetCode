using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace LeetCode.QuestionBank.Question1052
{
    public class Solution1052 : Interface1052
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="grumpy"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public int MaxSatisfied(int[] customers, int[] grumpy, int minutes)
        {
            if (minutes >= customers.Length) return customers.Sum();

            int[] cnt = new int[2];  // cnt[0] 满意的人数，cnt[1] 不满意的人数
            for (int i = 0; i < minutes; i++) cnt[grumpy[i]] += customers[i];
            int turn_cnt = cnt[1];
            for (int i = minutes; i < customers.Length; i++)
            {
                if (grumpy[i - minutes] != 0) cnt[1] -= customers[i - minutes];
                cnt[grumpy[i]] += customers[i];
                turn_cnt = Math.Max(turn_cnt, cnt[1]);
            }

            return cnt[0] + turn_cnt;
        }
    }
}
