using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2201
{
    public class Solution2201 : Interface2201
    {
        /// <summary>
        /// Hash
        /// 将dig放Hash中，枚举每个工件即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="artifacts"></param>
        /// <param name="dig"></param>
        /// <returns></returns>
        public int DigArtifacts(int n, int[][] artifacts, int[][] dig)
        {
            HashSet<(int, int)> set = [];
            foreach (int[] d in dig) set.Add((d[0], d[1]));

            int result = 0, r1, c1, r2, c2;
            foreach (int[] artifact in artifacts)
            {
                (r1, c1, r2, c2) = (artifact[0], artifact[1], artifact[2], artifact[3]);
                for (int i = 0; i <= r2 - r1; i++) for (int j = 0; j <= c2 - c1; j++)
                    {
                        if (!set.Contains((r1 + i, c1 + j))) goto CONTINUE;
                    }
                result++;
            CONTINUE:;
            }

            return result;
        }
    }
}
