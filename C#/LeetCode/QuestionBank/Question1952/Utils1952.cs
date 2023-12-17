using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1952
{
    public class Utils1952
    {
        public void Dial()
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= 10000; i++) if (IsThree(i)) result.Add(i);

            Utils.Dump(result);
        }

        private bool IsThree(int n)
        {
            if (n == 1) return false;
            int sqrt = (int)Math.Floor(Math.Sqrt(n));
            if (sqrt * sqrt != n) return false;

            for (int i = 2; i < sqrt; i++)
                if (n % i == 0) return false;

            return true;
        }
    }
}
