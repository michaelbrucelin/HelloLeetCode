using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2048
{
    public class Utils2048
    {
        public void Dial()
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= 1224444; i++)
                if (IsBeautifulNumber(i)) result.Add(i);

            Utils.Dump(result);
        }

        private bool IsBeautifulNumber(int n)
        {
            if (n <= 0) return false;

            int r; int[] freq = new int[10];
            while (n > 0)
            {
                if ((r = n % 10) == 0 || r > 6) return false;
                freq[r]++; n /= 10;
            }

            for (int i = 1; i < 7; i++) if (freq[i] != 0 && freq[i] != i) return false;

            return true;
        }
    }
}
