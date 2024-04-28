using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0075
{
    public class Solution0075 : Interface0075
    {
        /// <summary>
        /// 自定义排序
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            int[] order = new int[1001];
            Array.Fill(order, 1001);
            for (int i = 0; i < arr2.Length; i++) order[arr2[i]] = i;
            Comparer<int> comparer = Comparer<int>.Create((i, j) => (order[i] - order[j]) switch { > 0 => 1, < 0 => -1, _ => (i - j) switch { > 0 => 1, < 0 => -1, _ => 0 } });
            Array.Sort(arr1, comparer);

            return arr1;
        }
    }
}
