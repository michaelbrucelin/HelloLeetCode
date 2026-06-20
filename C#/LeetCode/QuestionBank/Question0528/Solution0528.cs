using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0528
{
    public class Solution0528
    {
    }

    /// <summary>
    /// 构造
    /// </summary>
    public class Solution : Interface0528
    {
        public Solution(int[] w)
        {
            random = new Random();
            length = w.Length; int sum = w[0];
            dist = new double[length];
            for (int i = 1; i < length; i++) sum += w[i];
            for (int i = 1; i < length; i++) dist[i] = dist[i - 1] + 1D * w[i - 1] / sum;
        }

        private Random random;
        private int length;
        private double[] dist;

        public int PickIndex()
        {
            double r = random.NextDouble();
            int result = -1, low = 0, high = length - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (r >= dist[mid])
                {
                    result = mid; low = mid + 1;
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
