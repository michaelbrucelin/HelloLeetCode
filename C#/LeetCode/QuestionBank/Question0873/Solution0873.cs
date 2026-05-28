using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0873
{
    public class Solution0873 : Interface0873
    {
        /// <summary>
        /// 枚举 + 剪枝
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int LenLongestFibSubseq(int[] arr)
        {
            int len = arr.Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < len; i++) map.Add(arr[i], i);
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            int result = 0, _result;
            for (int i = 0, j, p1, p2, p3; len - i > result; i++) for (j = i + 1; j < len && len - j + 1 > result; j++)
                {
                    if (!visited.Contains((i, j)) && map.ContainsKey(arr[i] + arr[j]))
                    {
                        _result = 3;
                        visited.Add((i, j)); visited.Add((j, map[arr[i] + arr[j]]));
                        p1 = j; p2 = map[arr[i] + arr[j]];
                        // while (!visited.Contains((p1, p2)) && map.ContainsKey(arr[p1] + arr[p2]))
                        while (map.TryGetValue(arr[p1] + arr[p2], out p3))
                        {
                            _result++;
                            visited.Add((p2, p3));
                            if (len - p3 + 1 + _result <= result) break;
                            p1 = p2; p2 = p3;
                        }
                        result = Math.Max(result, _result);
                    }
                }

            return result;
        }
    }
}
