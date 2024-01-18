using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2171
{
    public class Solution2171_2 : Interface2171
    {
        /// <summary>
        /// 本质上与Solution2171是一样的
        /// Solution2171中是"正向"计算结果：小于k的全部取走，大于k的取走部分保留k
        /// 而这里是"反向"计算结果，总数减去留下的，就是应该取走的
        /// </summary>
        /// <param name="beans"></param>
        /// <returns></returns>
        public long MinimumRemoval2(int[] beans)
        {
            if (beans.Length == 1) return 0;

            int len = beans.Length;
            Array.Sort(beans);
            long total = beans[0];
            List<int> next = new List<int>() { 0 };
            for (int i = 1; i < len; i++)
            {
                total += beans[i];
                if (beans[i] > beans[next[^1]]) next.Add(i);
            }

            long result = total;
            result = Math.Min(result, total - (long)beans[0] * len);  // 以第0项为基准
            for (int i = 1, j; i < next.Count; i++)                   // 以第j项为基准
            {
                j = next[i];
                result = Math.Min(result, total - (long)beans[j] * (len - j));
            }

            return result;
        }

        /// <summary>
        /// 本质上依然是Solution2171的思路，只不过更进一步，计算最小的结果，反过来就是计算保留最大的结果
        /// </summary>
        /// <param name="beans"></param>
        /// <returns></returns>
        public long MinimumRemoval(int[] beans)
        {
            if (beans.Length == 1) return 0;

            int len = beans.Length;
            Array.Sort(beans);
            long total = 0, keep = 0;
            for (int i = 0; i < len; i++)
            {
                total += beans[i];
                keep = Math.Max(keep, (long)beans[i] * (len - i));
            }

            return total - keep;
        }
    }
}
