using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0807
{
    public class Solution0807_2 : Interface0807
    {
        /// <summary>
        /// 下一个更大的排列
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public string[] Permutation(string S)
        {
            if (S.Length == 1) return [S];
            if (S.Length == 2) return [S, $"{S[1]}{S[0]}"];

            int n = 1, len = S.Length;
            for (int i = 2; i <= len; i++) n *= i;
            string[] result = new string[n];

            char[] chars = S.ToCharArray();
            Array.Sort(chars);
            char temp;
            for (int idx = 0, i, j; idx < n; idx++)
            {
                result[idx] = new string(chars);
                for (i = len - 2; i >= 0 && chars[i] > chars[i + 1]; i--) ;
                if (i == -1) break;
                for (j = len - 1; j >= 0 && chars[j] <= chars[i]; j--) ;     // 数据量较小，直接遍历，不使用二分
                temp = chars[i]; chars[i] = chars[j]; chars[j] = temp;
                for (i = i + 1, j = len - 1; i < j; i++, j--)
                {
                    temp = chars[i]; chars[i] = chars[j]; chars[j] = temp;
                }
            }

            return result;
        }
    }
}
