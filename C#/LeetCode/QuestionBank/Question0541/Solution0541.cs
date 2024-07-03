using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0541
{
    public class Solution0541 : Interface0541
    {
        public string ReverseStr(string s, int k)
        {
            char[] arr = s.ToCharArray();

            int p = 0;
            for (; p + k + k < arr.Length; p = p + k + k)
                ReverseSubStr(arr, p, p + k - 1);
            ReverseSubStr(arr, p, Math.Min(p + k - 1, arr.Length - 1));

            return new string(arr);
        }

        private void ReverseSubStr(char[] arr, int left, int right)
        {
            if (left >= right) return;

            for (; left < right; left++, right--)
                Swap(arr, left, right);
        }

        private void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public string ReverseStr2(string s, int k)
        {
            char[] chars = s.ToCharArray();
            int ptr, len = s.Length; bool flag = true;
            for (ptr = 0; ptr + k - 1 < len; ptr += k, flag = !flag)
            {
                if (flag)
                {
                    for (int l = ptr, r = ptr + k - 1; l < r; l++, r--)
                    {
                        (chars[l], chars[r]) = (chars[r], chars[l]);
                    }
                }
            }
            if (flag)
            {
                for (int l = ptr, r = len - 1; l < r; l++, r--)
                {
                    (chars[l], chars[r]) = (chars[r], chars[l]);
                }
            }

            return new string(chars);
        }
    }
}
