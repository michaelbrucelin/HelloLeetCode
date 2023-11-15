using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1346
{
    public class Solution1346 : Interface1346
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CheckIfExist(int[] arr)
        {
            HashSet<int> set = new HashSet<int>();
            int len = arr.Length;
            for (int i = 0; i < len; i++) set.Add(arr[i] << 1);

            for (int i = 0; i < len; i++)
                if (arr[i] != 0 && set.Contains(arr[i])) return true;

            bool flag = false;
            for (int i = 0; i < len; i++) if (arr[i] == 0)
                {
                    if (flag) return true; else flag = true;
                }

            return false;
        }
    }
}
