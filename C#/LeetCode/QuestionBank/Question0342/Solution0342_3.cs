﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0342
{
    public class Solution0342_3 : Interface0342
    {
        public bool IsPowerOfFour(int n)
        {
            return n > 0 && (n & (n - 1)) == 0 && n % 3 == 1;
        }
    }
}
