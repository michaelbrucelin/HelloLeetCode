using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2555
{
    public class Solution2555_2 : Interface2555
    {
        /// <summary>
        /// 逻辑同Solution2555，将Solution2555中第二个线段的大顶堆改为了dp，提前预处理出子数组单一线段的最大值
        /// </summary>
        /// <param name="prizePositions"></param>
        /// <param name="k"></param>
        /// <returns></returns>
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

            // 预处理maxpq -> dp[]
            (int start, int max)[] dp = new (int start, int max)[len];
            dp[len - 1] = dstb[len - 1];
            for (int i = len - 2; i >= 0; i--)
                dp[i] = dp[i + 1].max > dstb[i].cnt ? dp[i + 1] : dstb[i];

            // 计算结果
            int result = 0, _result;
            for (int i = 0, j = 1; i < len; i++)
            {
                _result = dstb[i].cnt;
                while (j < len && dp[j].start <= dstb[i].start + k) j++;
                if (j < len) _result += dp[j].max;
                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}
