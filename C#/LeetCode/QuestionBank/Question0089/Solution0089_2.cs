using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0089
{
    public class Solution0089_2 : Interface0089
    {
        private static List<int[]> cache = [[0, 1]];

        /// <summary>
        /// 逻辑同Solution0089，添加一层缓存
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> GrayCode(int n)
        {
            if (n - 1 < cache.Count) return cache[n - 1];

            while (n - 1 >= cache.Count)
            {
                int[] gray = cache[^1];
                int len = gray.Length;
                int[] newgray = new int[len << 1];
                Array.Copy(gray, newgray, len);
                for (int i = len - 1, j = len; i >= 0; i--, j++) newgray[j] = gray[i] + len;
                cache.Add(newgray);
            }

            return cache[^1];
        }
    }
}
