﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0901
{
    public class Solution0901_2
    {
    }

    /// <summary>
    /// 单调栈
    /// </summary>
    public class StockSpanner_2 : Interface0901
    {
        public StockSpanner_2()
        {
            stack = new Stack<(int price, int weight)>();
        }

        private Stack<(int price, int weight)> stack;

        public int Next(int price)
        {
            if (stack.Count == 0) { stack.Push((price, 1)); return 1; }

            int result = 1;
            while (stack.Count > 0 && price >= stack.Peek().price) { result += stack.Pop().weight; }
            stack.Push((price, result));

            return result;
        }
    }
}
