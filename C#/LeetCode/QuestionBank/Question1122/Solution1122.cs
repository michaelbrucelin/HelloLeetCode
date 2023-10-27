using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1122
{
    public class Solution1122 : Interface1122
    {
        /// <summary>
        /// 自定义排序规则
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < arr2.Length; i++) map.Add(arr2[i], i);
            Comparer<int> comparer = Comparer<int>.Create((i, j) =>
            {
                if (map.ContainsKey(i) && map.ContainsKey(j)) return map[i] - map[j];
                else if (map.ContainsKey(i)) return -1;
                else if (map.ContainsKey(j)) return 1;
                else return i - j;
            });
            Array.Sort(arr1, comparer);

            return arr1;
        }
    }
}
