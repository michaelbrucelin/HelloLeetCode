using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2569
{
    public class Solution2569 : Interface2569
    {
        /// <summary>
        /// 暴力模拟
        /// 翻转即与1异或，逻辑没问题，显然提交会超时
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public long[] HandleQuery(int[] nums1, int[] nums2, int[][] queries)
        {
            List<long> result = new List<long>();
            long sum; int len = nums1.Length, j, r, p;
            long[] _nums2 = new long[len]; for (int i = 0; i < len; i++) _nums2[i] = nums2[i];
            for (int i = 0; i < queries.Length; i++)
            {
                switch (queries[i][0])
                {
                    case 1:
                        r = queries[i][2];
                        for (j = queries[i][1]; j <= r; j++) nums1[j] ^= 1;
                        break;
                    case 2:
                        p = queries[i][1];
                        for (j = 0; j < len; j++) _nums2[j] += nums1[j] * p;
                        break;
                    case 3:
                        sum = 0;
                        for (j = 0; j < len; j++) sum += _nums2[j];
                        result.Add(sum);
                        break;
                    default:
                        throw new Exception("logic error.");
                }
            }

            return result.ToArray();
        }
    }
}
