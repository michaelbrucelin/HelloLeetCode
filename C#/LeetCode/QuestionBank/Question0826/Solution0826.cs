using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0826
{
    public class Solution0826 : Interface0826
    {
        /// <summary>
        /// 排序 + 二分
        /// 1. difficulty升序排序，profit根据profit同时排序
        /// 2. 排序后的profit[i]更新为max(profit[0..i])
        /// 3. 二分找出难度小于等于worker[i]的最大difficulty[j]对应的profit[i]
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="profit"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            int len = difficulty.Length;
            int[] index = new int[len];
            for (int i = 0; i < len; i++) index[i] = i;
            Array.Sort(index, (i, j) => difficulty[i] - difficulty[j]);
            for (int i = 1; i < len; i++) profit[index[i]] = Math.Max(profit[index[i]], profit[index[i - 1]]);

            int result = 0, left, right, mid, find;
            for (int i = 0, _worker; i < worker.Length; i++)
            {
                _worker = worker[i]; left = 0; right = len - 1; find = -1;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (difficulty[index[mid]] <= _worker)
                    {
                        find = mid; left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                if (find > -1) result += profit[index[find]];
            }

            return result;
        }
    }
}
