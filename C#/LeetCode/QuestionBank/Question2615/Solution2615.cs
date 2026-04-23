using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2615
{
    public class Solution2615 : Interface2615
    {
        /// <summary>
        /// 哈希 + 前缀和
        /// 1. 预处理出相同值的全部id，例如：num的全部索引: [I1, I2, ... I{k-1}, Ik, I{k+1}, ... In]
        /// 2. 计算nums[Ik]时：[I1, I2, ... I{k-1}, Ik, I{k+1}, ... In]
        ///                    [Ik, Ik, ... Ik,     Ik, Ik,     ... Ik]
        ///        k之前的下减上，k之后的上减下，下面好办，上面的前缀和即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long[] Distance(int[] nums)
        {
            if (nums.Length == 1) return [0];

            int len = nums.Length;
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < len; i++) { map.TryAdd(nums[i], []); map[nums[i]].Add(i); }

            long[] result = new long[len];
            long lsum, rsum; int cnt, id;
            foreach (List<int> ids in map.Values)
            {
                if (ids.Count == 1) { result[ids[0]] = 0; continue; }
                lsum = rsum = 0; cnt = ids.Count;
                for (int i = 0; i < cnt; i++) rsum += ids[i];
                result[ids[0]] = rsum - ids[0] * cnt;
                for (int i = 1; i < cnt; i++)
                {
                    id = ids[i];
                    lsum += ids[i - 1]; rsum -= ids[i - 1];
                    result[id] = 1L * id * i - lsum + rsum - 1L * id * (cnt - i);
                }
            }

            return result;
        }
    }
}
