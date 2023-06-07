using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2611
{
    public class Solution2611_2 : Interface2611
    {
        /// <summary>
        /// topk
        /// 与Solution2611思路一样，不过将Solution2611中的排序改为了topk
        /// 这里的topk借助最大堆来实现
        /// </summary>
        /// <param name="reward1"></param>
        /// <param name="reward2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MiceAndCheese(int[] reward1, int[] reward2, int k)
        {
            int len = reward1.Length;
            if (k == len) return reward1.Sum();

            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            for (int i = 0; i < len; i++)
            {
                maxpq.Enqueue(reward1[i] - reward2[i], reward1[i] - reward2[i]);
                if (maxpq.Count > k) maxpq.Dequeue();
            }

            int result = reward2.Sum();
            while (maxpq.Count > 0) result += maxpq.Dequeue();

            return result;
        }

        /// <summary>
        /// 与MiceAndCheese()一样，这里的topk使用快速排序的方式实现
        /// </summary>
        /// <param name="reward1"></param>
        /// <param name="reward2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MiceAndCheese2(int[] reward1, int[] reward2, int k)
        {
            int len = reward1.Length;
            if (k == len) return reward1.Sum();

            int[] reward = new int[len];
            for (int i = 0; i < len; i++) reward[i] = reward1[i] - reward2[i];
            int[] topk = TopK(reward, k);

            return reward2.Sum() + topk.Sum();
        }

        private int[] TopK(int[] nums, int k)
        {
            throw new NotImplementedException();
        }
    }
}
