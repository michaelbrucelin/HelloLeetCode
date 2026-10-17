using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3781
{
    public class Solution3781_err : Interface3781
    {
        /// <summary>
        /// topk
        /// 
        /// 题目理解的不对，nums = [1,8,8,4,6,2]; s = "110100"; 结果是17，不是20
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public long MaximumScore(int[] nums, string s)
        {
            int k = 0, border = -1, len = nums.Length;
            for (int i = 0; i < len; i++) if (s[i] == '1') { k++; border = i + 1; }

            long result = 0;
            if (k == border)
            {
                for (int i = 0; i < border; i++) result += nums[i];
            }
            else
            {
                PriorityQueue<int, int> minpq = new PriorityQueue<int, int>();
                for (int i = 0; i < border; i++)
                {
                    minpq.Enqueue(nums[i], nums[i]);
                    if (minpq.Count > k) minpq.Dequeue();
                }
                foreach (var x in minpq.UnorderedItems) result += x.Element;
            }

            return result;
        }
    }
}
