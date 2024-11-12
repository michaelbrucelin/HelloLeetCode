using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1114
{
    public class Solution1114_2
    {
    }

    public class Foo_2 : Interface1114
    {
        public Foo_2()
        {
            flags = new bool[3];
        }

        private bool[] flags;

        public void First(Action printFirst)
        {
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();
            flags[0] = true;
        }

        public void Second(Action printSecond)
        {
            while (!flags[0]) ;
            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
            flags[1] = true;
        }

        public void Third(Action printThird)
        {
            while (!flags[1]) ;
            // printThird() outputs "third". Do not change or remove this line.
            printThird();
            flags[2] = true;
        }
    }
}
