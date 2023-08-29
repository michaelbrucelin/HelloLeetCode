using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0823
{
    public class Solution0823 : Interface0823
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// 排序 + 字典 + DP
        /// 1. arr升序排序，并创建等长的数组，记录arr中相同位置元素为根节点的树的数量
        /// 2. 从前向后遍历arr，所以arr[i]为根的树的子节点必是arr[j]且j<i
        /// 例如：arr = { 2, 4, 8, 16 }
        ///     2:  1个   // 2为根节点
        ///     4:  2个   // 4为根节点
        ///     8:  5个   // 8为根节点 + 左2右4 + 左4右2
        ///     16: 15个  // ... ...
        /// 时间复杂度：O(n^2)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int NumFactoredBinaryTrees(int[] arr)
        {
            int len = arr.Length;
            Array.Sort(arr);
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < len; i++) dic.Add(arr[i], i);
            long[] dp = new long[len];
            for (int i = 0, sqrt; i < len; i++)
            {
                dp[i] = 1;  // arr[i]为根节点，且没有子节点的树
                sqrt = (int)Math.Floor(Math.Sqrt(arr[i]));
                for (int j = 0; arr[j] <= sqrt; j++)
                {
                    var t = Math.DivRem(arr[i], arr[j]);
                    if (t.Remainder == 0 && dic.ContainsKey(t.Quotient))
                    {
                        if (t.Quotient != arr[j])
                            dp[i] = (dp[i] + ((dp[j] * dp[dic[t.Quotient]]) << 1)) % MOD;
                        else  // (t.Quotient == arr[j])
                            dp[i] = (dp[i] + dp[j] * dp[j]) % MOD;
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < len; i++) result = (result + (int)dp[i]) % MOD;

            return result;
        }
    }
}
