﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2299
{
    public class Solution2299 : Interface2299
    {
        public bool StrongPasswordCheckerII(string password)
        {
            if (password.Length < 8) return false;

            HashSet<char> specials = "!@#$%^&*()-+".ToHashSet();
            bool lower = false, upper = false, digit = false, special = false;
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                if (i > 0 && c == password[i - 1]) return false;

                if (char.IsLower(c)) lower = true;
                else if (char.IsUpper(c)) upper = true;
                else if (char.IsDigit(c)) digit = true;
                else if (specials.Contains(c)) special = true;
            }

            return lower && upper && digit && special;
        }

        /// <summary>
        /// 将上面的多个bool变量放到一个位图中
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool StrongPasswordCheckerII2(string password)
        {
            if (password.Length < 8) return false;

            HashSet<char> specials = "!@#$%^&*()-+".ToHashSet();
            int mask = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char c = password[i];
                if (i > 0 && c == password[i - 1]) return false;

                if (char.IsLower(c)) mask |= 1;
                else if (char.IsUpper(c)) mask |= 2;
                else if (char.IsDigit(c)) mask |= 4;
                else if (specials.Contains(c)) mask |= 8;
            }

            return mask == 15;
        }
    }
}
