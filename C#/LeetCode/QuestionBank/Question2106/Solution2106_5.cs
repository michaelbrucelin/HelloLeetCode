
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2106
{
    public class Solution2106_5 : Interface2106
    {
        /// <summary>
        /// 贪心，类前缀和
        /// 1. 最多折返一次，证明略
        /// 2. 预处理出从startPos起，向左向右的“前缀和”
        /// 3. 先左再折返，先右再折返，模拟这两种情形的折返位置即可
        /// </summary>
        /// <param name="fruits"></param>
        /// <param name="startPos"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxTotalFruits(int[][] fruits, int startPos, int k)
        {
            int result = 0, ptr, len = fruits.Length;
            if (startPos <= fruits[0][0])
            {
                ptr = 0;
                while (ptr < len && fruits[ptr][0] - startPos <= k) result += fruits[ptr++][1];
                return result;
            }
            if (startPos >= fruits[^1][0])
            {
                ptr = len - 1;
                while (ptr >= 0 && startPos - fruits[ptr][0] <= k) result += fruits[ptr--][1];
                return result;
            }

            // 类前缀和
            ptr = binarySearch(startPos);
            List<(int pos, int sum)> lsum = [], rsum = [];
            if (fruits[ptr][0] == startPos)
            {
                lsum.Add((fruits[ptr][0], fruits[ptr][1]));
                for (int i = ptr - 1; i >= 0 && startPos - fruits[i][0] <= k; i--) lsum.Add((fruits[i][0], lsum[^1].sum + fruits[i][1]));
                rsum.Add((fruits[ptr][0], fruits[ptr][1]));
                for (int i = ptr + 1; i < len && fruits[i][0] - startPos <= k; i++) rsum.Add((fruits[i][0], rsum[^1].sum + fruits[i][1]));
            }
            else
            {
                lsum.Add((fruits[ptr][0], fruits[ptr][1]));
                for (int i = ptr - 1; i >= 0 && startPos - fruits[i][0] <= k; i--) lsum.Add((fruits[i][0], lsum[^1].sum + fruits[i][1]));
                rsum.Add((fruits[ptr + 1][0], fruits[ptr + 1][1]));
                for (int i = ptr + 2; i < len && fruits[i][0] - startPos <= k; i++) rsum.Add((fruits[i][0], rsum[^1].sum + fruits[i][1]));
            }

            if (fruits[ptr][0] == startPos) result -= fruits[ptr][1];
            int _result, init, pl, pr, _k;
            // 先左再折返
            init = fruits[ptr][0] == startPos ? -fruits[ptr][1] : 0; pl = 0; pr = rsum.Count - 1;
            while (pl < lsum.Count && startPos - lsum[pl].pos <= k)
            {
                _result = lsum[pl].sum + init;
                if (pr >= 0 && (_k = k - (startPos - lsum[pl].pos) * 2) >= 0)
                {
                    while (pr >= 0 && rsum[pr].pos - startPos > _k) pr--;
                    if (pr >= 0) _result += rsum[pr].sum;
                }
                else pr = -1;
                result = Math.Max(result, _result);
                pl++;
            }
            // 先右再折返
            init = fruits[ptr][0] == startPos ? -fruits[ptr][1] : 0; pl = lsum.Count - 1; pr = 0;
            while (pr < rsum.Count && rsum[pr].pos - startPos <= k)
            {
                _result = rsum[pr].sum + init;
                if (pl >= 0 && (_k = k - (rsum[pr].pos - startPos) * 2) >= 0)
                {
                    while (pl >= 0 && startPos - lsum[pl].pos > _k) pl--;
                    if (pl >= 0) _result += lsum[pl].sum;
                }
                else pl = -1;
                result = Math.Max(result, _result);
                pr++;
            }

            return result;

            int binarySearch(int target)
            {
                int result = -1, left = 0, right = len - 1, mid;
                while (left <= right)
                {
                    mid = left + ((right - left) >> 1);
                    if (fruits[mid][0] <= target)
                    {
                        result = mid; left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                return result;
            }
        }
    }
}
