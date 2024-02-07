using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1696
{
    public class Solution1696_2 : Interface1696
    {
        /// <summary>
        /// DP + 双端队列（单调队列）
        /// 逻辑同Solution1696，只是将优先级队列改为了单调队列
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxResult(int[] nums, int k)
        {
            int len = nums.Length;
            if (len <= 2 || k == 1) return nums.Sum();
            if (k >= len) return nums[0] + nums[^1] + nums.Skip(1).Take(len - 2).Where(i => i > 0).Sum();

            LinkedList<(int score, int idx)> list = new LinkedList<(int score, int idx)>();
            list.AddLast((nums[0], 0));
            for (int i = 1, score; i < k; i++)
            {
                score = nums[i] + list.First.Value.score;
                while (list.Count > 0 && list.Last.Value.score < score) list.RemoveLast();
                list.AddLast((score, i));
            }
            for (int i = k, score; i < len; i++)
            {
                while (list.First.Value.idx < i - k) list.RemoveFirst();
                score = nums[i] + list.First.Value.score;
                while (list.Count > 0 && list.Last.Value.score < score) list.RemoveLast();
                list.AddLast((score, i));
            }

            return list.Last.Value.score;
        }
    }
}
