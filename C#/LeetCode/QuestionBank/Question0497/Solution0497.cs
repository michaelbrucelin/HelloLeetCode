using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0497
{
    public class Solution0497
    {
    }

    /// <summary>
    /// 两层随机
    /// 题目限定矩形没有重叠，所以可以先随机矩形（注意权重），然后随机矩形内的点
    /// </summary>
    public class Solution : Interface0497
    {
        public Solution(int[][] rects)
        {
            random = new Random();
            this.rects = rects;
            n = rects.Length;
            weights = new int[n];
            weights[0] = (rects[0][2] - rects[0][0] + 1) * (rects[0][3] - rects[0][1] + 1);
            for (int i = 1; i < n; i++) weights[i] = weights[i - 1] + (rects[i][2] - rects[i][0] + 1) * (rects[i][3] - rects[i][1] + 1);
        }

        private Random random;
        private int[][] rects;
        private int n;
        private int[] weights;

        public int[] Pick()
        {
            return PickPoint(PickRect());
        }

        private int PickRect()
        {
            int weight = random.Next(weights[n - 1]);
            int id = -1, lo = 0, hi = n - 1, mid;
            while (lo <= hi)
            {
                mid = lo + ((hi - lo) >> 1);
                if (weight < weights[mid]) { id = mid; hi = mid - 1; } else lo = mid + 1;
            }
            return id;
        }

        private int[] PickPoint(int id)
        {
            int rcnt = rects[id][3] - rects[id][1] + 1, ccnt = rects[id][2] - rects[id][0] + 1;
            int rnd = random.Next(rcnt * ccnt);
            return [rects[id][0] + rnd % ccnt, rects[id][1] + rnd / ccnt];
        }
    }
}
