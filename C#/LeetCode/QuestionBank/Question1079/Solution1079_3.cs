using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1079
{
    public class Solution1079_3 : Interface1079
    {
        /// <summary>
        /// 二进制枚举 + 数学
        /// 1. 使用二进制枚举，枚举出不同的选择方式
        /// 2. 数学计算该选择的全排列的数量
        ///     先对选择的元素排序，记忆化检查，防止重复计算
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

        private int Permutation(char[] chars)
        {
            int len = chars.Length;
            int[] freq = new int[26]; for (int i = 0; i < len; i++) freq[chars[i] - 'A']++;

            int result = 1;
            while (len > 1) result *= len--;
            for (int i = 0, _len; i < 26; i++)
            {
                _len = freq[i];
                while (_len > 1) result /= _len--;
            }

            return result;
        }

        private static readonly int[] factorial = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040 };

        /// <summary>
        /// 既然长度最大为7，所以可以打表
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        private int Permutation2(char[] chars)
        {
            int len = chars.Length;
            int[] freq = new int[26]; for (int i = 0; i < len; i++) freq[chars[i] - 'A']++;

            int result = factorial[len];
            for (int i = 0; i < 26; i++) result /= factorial[freq[i]];

            return result;
        }
    }
}
