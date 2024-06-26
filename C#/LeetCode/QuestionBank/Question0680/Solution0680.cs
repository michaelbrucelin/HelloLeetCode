﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0680
{
    public class Solution0680 : Interface0680
    {
        /// <summary>
        /// 双指针
        /// 1. 使用两个指针(ptr_l, ptr_r)指向字符串的前后两端
        /// 2. 两个指针向中间靠拢，如果两个指针指向的字符不同，二者必须舍弃一个
        ///     由于只能删除一个字符，所以只需要将两种可能都验证一次就可以了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidPalindrome(string s)
        {
            int pl = -1, pr = s.Length;
            while (++pl < --pr) if (s[pl] != s[pr]) break;
            if (pl >= pr) return true;

            return ValidPalindrome(s, pl + 1, pr) || ValidPalindrome(s, pl, pr - 1);
        }

        private bool ValidPalindrome(string s, int left, int right)
        {
            while (left < right) if (s[left++] != s[right--]) return false;

            return true;
        }
    }
}
