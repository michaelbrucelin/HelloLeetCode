using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0164
{
    public class Solution0164 : Interface0164
    {
        /// <summary>
        /// 自定义排序
        /// s1与s2比较大小相当于比较 s1+s2 与 s2+s1 的大小
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string CrackPassword(int[] password)
        {
            int len = password.Length;
            string[] arr = new string[len];
            for (int i = 0; i < len; i++) arr[i] = password[i].ToString();

            Comparer<string> comparer = Comparer<string>.Create((s1, s2) => string.CompareOrdinal($"{s1}{s2}", $"{s2}{s1}"));
            Array.Sort(arr, comparer);

            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < len; i++) buffer.Append(arr[i]);

            return buffer.ToString();
        }
    }
}
