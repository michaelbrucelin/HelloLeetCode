using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1442
{
    public class Solution1442_2 : Interface1442
    {
        /// <summary>
        /// 预处理
        /// 预处理以arr[i]为结尾的子数组异或值的可能性以及以arr[i]为开头的子数组异或值的可能性
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int CountTriplets(int[] arr)
        {
            int len = arr.Length;
            Dictionary<int, int>[][] maps = new Dictionary<int, int>[2][];
            for (int i = 0; i < 2; i++)
            {
                maps[i] = new Dictionary<int, int>[len];
                for (int j = 0; j < len; j++) maps[i][j] = new Dictionary<int, int>();
            }

            for (int i = 0, xor = 0; i < len - 1; i++, xor = 0) for (int j = i; j >= 0; j--)
                {
                    xor ^= arr[j];
                    if (maps[0][i].ContainsKey(xor)) maps[0][i][xor]++; else maps[0][i].Add(xor, 1);
                }
            for (int i = len - 1, xor = 0; i > 0; i--, xor = 0) for (int j = i; j < len; j++)
                {
                    xor ^= arr[j];
                    if (maps[1][i].ContainsKey(xor)) maps[1][i][xor]++; else maps[1][i].Add(xor, 1);
                }

            int result = 0;
            Dictionary<int, int> less, more;           // 小驱动大
            for (int i = 0, j = 1; j < len; i++, j++)
            {
                if (maps[0][i].Count <= maps[1][j].Count) { less = maps[0][i]; more = maps[1][j]; } else { less = maps[1][j]; more = maps[0][i]; }
                foreach (int val in less.Keys) if (more.ContainsKey(val)) result += less[val] * more[val];
            }

            return result;
        }
    }
}
