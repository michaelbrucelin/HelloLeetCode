using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2614
{
    public class Utils2614
    {
        /// <summary>
        /// 本意是想将题目范围内的质数全部打印出来，然后打表，但是计算素数这块是在是太慢了，不弄了
        /// </summary>
        public void Dial()
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= int.MaxValue; i++)
                if (IsPrime(i)) list.Add(i);

            Utils.Dump(list);
        }

        private bool IsPrime(int num)
        {
            if (num == 1) return false;

            int sqrt = (int)Math.Sqrt(num);
            for (int i = 2; i <= sqrt; i++) if (num % i == 0) return false;

            return true;
        }
    }
}
