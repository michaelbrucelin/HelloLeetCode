using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1130
{
    public class Solution1130_2 : Interface1130
    {
        /// <summary>
        /// 分治
        /// 与Solution1130逻辑一样，做了两点优化
        ///     1. 添加了记忆化搜索
        ///     2. 预处理了任意子数组的最大值
        /// 上边两种优化都采用“梯形数组”的形式做缓存，这样有两点好处
        ///     1. 相对于使用字典，省去了hash的时间
        ///     2. 相对于使用二维数组，省去了一半的内存空间（尽管对于这道题没有太大的意义）
        /// 所谓“梯形数组”，就是数组的数组，每个1维数组长度不一样，其中max[i][j]表示arr[j..(i+1)]的最大值
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MctFromLeafValues(int[] arr)
        {
            int len = arr.Length;
            int[][] max = new int[len][], cache = new int[len][];
            for (int i = 0; i < len; i++)
            {
                max[i] = new int[i + 1]; cache[i] = new int[i + 1];
                max[i][i] = arr[i];
                for (int j = i - 1; j >= 0; j--) max[i][j] = Math.Max(max[i][j + 1], arr[j]);
            }

            return DivideAndConquer(arr, 0, arr.Length - 1, max, cache);
        }

        private int DivideAndConquer(int[] arr, int left, int right, int[][] max, int[][] cache)
        {
            if (left >= right) return 0;

            int result = int.MaxValue;
            for (int i = left; i < right; i++)  // [left, i] [i+1, right]
            {
                if (cache[i][left] == 0) cache[i][left] = DivideAndConquer(arr, left, i, max, cache);
                if (cache[right][i + 1] == 0) cache[right][i + 1] = DivideAndConquer(arr, i + 1, right, max, cache);
                result = Math.Min(result, max[i][left] * max[right][i + 1] + cache[i][left] + cache[right][i + 1]);
            }

            return result;
        }
    }
}
