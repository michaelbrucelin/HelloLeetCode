﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2710
{
    public class Solution2710 : Interface2710
    {
        public string RemoveTrailingZeros(string num)
        {
            int ptr = num.Length - 1;
            while (num[ptr] == '0') ptr--;

            return num.Substring(0, ptr + 1);
        }
    }
}
