using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0093
{
    public class Solution0093 : Interface0093
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int LenLongestFibSubseq(int[] arr)
        {
            int result = 0, len = arr.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < len; i++) map.Add(arr[i], i);       // 题目限定arr无重复值
            bool[,] visited = new bool[len, len];
            int _result, p1, p2, p3;
            for (int i = 0; len - i > result; i++) for (int j = i + 1; len - j + 1 > result; j++) if (!visited[i, j])
                    {
                        _result = 2; p1 = i; p2 = j;
                        while (map.TryGetValue(arr[p1] + arr[p2], out p3))
                        {
                            _result++; p1 = p2; p2 = p3;
                        }
                        result = Math.Max(result, _result);
                    }

            return result > 2 ? result : 0;
        }
    }
}
