using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1560
{
    public class Solution1560_2 : Interface1560
    {
        /// <summary>
        /// 数学
        /// 当终点在起点前面时，就是新的一圈，中间的那些圈，没有意义，
        ///     只考虑第一圈与最后一圈即可，因为只有这两圈可能不是完整的圈，这样才会影响结果
        /// 有差分数组的意思
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rounds"></param>
        /// <returns></returns>
        public IList<int> MostVisited(int n, int[] rounds)
        {
            List<int> result = new List<int>();
            int circles = 1;
            for (int i = 1; i < rounds.Length; i++) if (rounds[i] < rounds[i - 1]) circles++;
            if (circles == 1)  // 只有1圈
            {
                for (int i = rounds[0]; i <= rounds[^1]; i++) result.Add(i);
            }
            else               // 大于等于2圈，只考虑第1圈与最后1圈
            {
                if (rounds[0] <= rounds[^1])
                {
                    for (int i = rounds[0]; i <= rounds[^1]; i++) result.Add(i);
                }
                else
                {
                    for (int i = 1; i <= rounds[^1]; i++) result.Add(i);
                    for (int i = rounds[0]; i <= n; i++) result.Add(i);
                }
            }

            return result;
        }

        /// <summary>
        /// 与MostVisited()逻辑一样，只是不需要判断跑了几圈，直接分起点和终点的位置即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="rounds"></param>
        /// <returns></returns>
        public IList<int> MostVisited2(int n, int[] rounds)
        {
            List<int> result = new List<int>();
            if (rounds[0] <= rounds[^1])
            {
                for (int i = rounds[0]; i <= rounds[^1]; i++) result.Add(i);
            }
            else
            {
                for (int i = 1; i <= rounds[^1]; i++) result.Add(i);
                for (int i = rounds[0]; i <= n; i++) result.Add(i);
            }

            return result;
        }
    }
}
