using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2427
{
    public class Utils2427
    {
        public void Dial(int n)
        {
            Console.Write("2,");
            for (int i = 3; i <= n; i++) if (IsPrime(i)) Console.Write($"{i},");
            Console.Write("\b");
        }

        private bool IsPrime(int x)
        {
            if ((x & 1) == 0) return false;
            int high = x / 3;
            for (int i = 3; i <= high; i++) if (x % i == 0) return false;

            return true;
        }
    }
}
