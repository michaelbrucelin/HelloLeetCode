using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1996
{
    public class Solution1996 : Interface1996
    {
        /// <summary>
        /// 预处理
        /// 1. 按照properties[i][0] asc, properties[i][1] desc排序
        ///    按照properties[i][0]分组，记录下每一组最大的properties[i][1]：[[key1,max1], [key2,max2], [key3,max3] ... ...]
        /// 2. 逆序处理[[key1,max1], [key2,max2], [key3,max3] ... ...]，处理成
        ///    [[key1,MAX1], [key2,MAX2], [key3,MAX3] ... ...]
        ///    其中MAXi = MAX(max_i+1, max_i+2, ...)
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public int NumberOfWeakCharacters(int[][] properties)
        {
            Array.Sort(properties, (x, y) => x[0] != y[0] ? x[0] - y[0] : y[1] - x[1]);
            List<int[]> info = [[properties[0][0], properties[0][1]]];
            int len = properties.Length;
            for (int i = 1; i < len; i++) if (properties[i][0] > properties[i - 1][0]) info.Add([properties[i][0], properties[i][1]]);
            if (info.Count == 1) return 0;
            for (int i = info.Count - 2; i > 0; i--) info[i][1] = Math.Max(info[i][1], info[i + 1][1]);

            int result = 0, cnt = info.Count;
            for (int i = 0, j = 1; i < len; i++)
            {
                if (properties[i][0] == info[j][0]) { if (++j == cnt) break; }
                if (properties[i][1] < info[j][1]) result++;                    // 这里可以使用二分法加速，这里就不做了
            }

            return result;
        }

        /// <summary>
        /// 核心逻辑同NumberOfWeakCharacters()，略加优化
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public int NumberOfWeakCharacters2(int[][] properties)
        {
            Array.Sort(properties, (x, y) => x[0] != y[0] ? x[0] - y[0] : y[1] - x[1]);
            List<int[]> info = [[properties[0][0], properties[0][1], 0]];                // 记录索引，方便跳跃
            int len = properties.Length;
            for (int i = 1; i < len; i++) if (properties[i][0] > properties[i - 1][0]) info.Add([properties[i][0], properties[i][1], i]);
            if (info.Count == 1) return 0;
            for (int i = info.Count - 2; i > 0; i--) info[i][1] = Math.Max(info[i][1], info[i + 1][1]);

            int result = 0, cnt = info.Count;
            for (int i = 0, j = 1; i < len; i++)
            {
                if (properties[i][0] == info[j][0]) { if (++j == cnt) break; }
                if (properties[i][1] < info[j][1])                                       // 这里可以使用二分法加速，这里就不做了
                {
                    result += info[j][2] - i;
                    i = info[j][2] - 1;
                }
            }

            return result;
        }
    }
}
