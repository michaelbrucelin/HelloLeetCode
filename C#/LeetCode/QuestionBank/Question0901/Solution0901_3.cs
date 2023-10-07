using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0901
{
    public class Solution0901_3
    {
    }

    /// <summary>
    /// 单调栈
    /// </summary>
    public class StockSpanner_3 : Interface0901
    {
        public StockSpanner_3()
        {
            _price = new Stack<int>();
            _price.Push(int.MaxValue);  // 哨兵
            _count = new Stack<int>();
        }

        private Stack<int> _price;
        private Stack<int> _count;

        public int Next(int price)
        {
            int result = 1;
            while (price >= _price.Peek())
            {
                _price.Pop(); result += _count.Pop();
            }
            _price.Push(price);
            _count.Push(result);

            return result;
        }
    }
}
