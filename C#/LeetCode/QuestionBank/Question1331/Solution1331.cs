using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1331
{
    public class Solution1331 : Interface1331
    {
        /// <summary>
        /// 分析
        /// 去重复 --> 排序 --> 哈希
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] ArrayRankTransform(int[] arr)
        {
            HashSet<int> set = new HashSet<int>(arr);
            int[] _arr = set.ToArray();
            Array.Sort(_arr);
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < _arr.Length; i++) map.Add(_arr[i], i + 1);
            for (int i = 0; i < arr.Length; i++) arr[i] = map[arr[i]];

            return arr;
        }
    }
}
