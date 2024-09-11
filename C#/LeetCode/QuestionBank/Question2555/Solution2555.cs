using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2555
{
    public class Solution2555 : Interface2555
    {
        /// <summary>
        /// 优先级队列
        /// 1. (int start, int cnt)[] dstb，以start为起点，长度为k的线段的礼物数量，start \in [prizePositions[0], prizePositions[-1]]
        /// 2. 将dstb所有的值放入最大堆中，maxpq
        /// 3. 遍历dstb，对于dstb中的每个值，可以从maxpq中找出不相交最大值
        ///     如果相交，从maxpq中移除
        ///     如果不相交，更新结果，再放回到maxpq中
        /// </summary>
        /// <param name="prizePositions"></param>
        /// <param name="k"></param>
        public int MaximizeWin(int[] prizePositions, int k)
        {
            if ((k << 1) + 1 >= prizePositions[^1] - prizePositions[0]) return prizePositions.Length;

            // 重新整理prizePositions，将相同位置合并
            List<int[]> pp = new List<int[]>() { new int[] { prizePositions[0], 0 } };
            for (int i = 0; i < prizePositions.Length; i++)
            {
                if (pp[^1][0] == prizePositions[i]) pp[^1][1]++; else pp.Add([prizePositions[i], 1]);
            }

            // 预处理(int start, int cnt)[] dstb
            int cnt = 0, l, r, len = pp.Count;
            (int start, int cnt)[] dstb = new (int start, int cnt)[len];
            for (r = 0; r < len && pp[r][0] <= pp[0][0] + k; r++) cnt += pp[r][1];
            dstb[0] = (pp[0][0], cnt);
            for (l = 1; l < len; l++)
            {
                cnt -= pp[l - 1][1];
                while (r < len && pp[r][0] <= pp[l][0] + k) cnt += pp[r++][1];
                dstb[l] = (pp[l][0], cnt);
            }

            // 预处理maxpq
            PriorityQueue<(int start, int cnt), int> maxpq = new PriorityQueue<(int start, int cnt), int>();
            for (int i = 0; i < len; i++) maxpq.Enqueue(dstb[i], -dstb[i].cnt);

            // 计算结果
            int result = 0, _result;
            foreach (var item in dstb)
            {
                _result = item.cnt;
                while (maxpq.Count > 0 && maxpq.Peek().start <= item.start + k) maxpq.Dequeue();
                if (maxpq.Count > 0) _result += maxpq.Peek().cnt;
                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}
