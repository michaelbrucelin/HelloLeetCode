using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1079
{
    public class Solution1079_2 : Interface1079
    {
        /// <summary>
        /// 二进制枚举 + 枚举（字典序全排列 + 记忆化）
        /// 本质上依然是暴力枚举，这里先使用二进制枚举，枚举出选中的位置，然后对选中的元素做全排列
        /// 这里使用字典序算法计算全排列，这样有两点好处：
        ///     1. 自动忽略了重复的排列
        ///     2. 第一步需要将选中的元素排序，这样直接进行记忆化处理
        /// </summary>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public int NumTilePossibilities(string tiles)
        {
            int result = 0, border = 1 << tiles.Length;
            HashSet<string> visited = new HashSet<string>();
            for (int i = 1; i < border; i++)
            {
                List<char> chars = new List<char>();
                for (int j = 0, mask = i; mask > 0; j++)
                {
                    if ((mask & 1) != 0) chars.Add(tiles[j]);
                    mask >>= 1;
                }
                char[] _chars = chars.ToArray(); Array.Sort(_chars);
                string key = new string(_chars);
                if (!visited.Contains(key))
                {
                    result += Permutation(_chars);
                    visited.Add(key);
                }
            }

            return result;
        }

        /// <summary>
        /// 字典序算法统计全排列
        /// https://zh.wikipedia.org/wiki/%E5%85%A8%E6%8E%92%E5%88%97%E7%94%9F%E6%88%90%E7%AE%97%E6%B3%95
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        private int Permutation(char[] chars)
        {
            if (chars.Length <= 1) return 1;  // chars进来时已经升序排序

            int result = 1, len = chars.Length, i, j, low, high, mid;
            while (true)
            {
                i = len - 2; while (i >= 0 && chars[i] >= chars[i + 1]) i--;
                if (i == -1) break;
                result++;
                low = i + 1; high = len - 1; j = i;
                while (low <= high)
                {
                    mid = low + ((high - low) >> 1);
                    if (chars[mid] > chars[i])
                    {
                        j = mid; low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }

                char t = chars[i]; chars[i] = chars[j]; chars[j] = t;
                low = i; high = len;
                while (++low < --high)
                {
                    t = chars[low]; chars[low] = chars[high]; chars[high] = t;
                }
            }

            return result;
        }
    }
}
