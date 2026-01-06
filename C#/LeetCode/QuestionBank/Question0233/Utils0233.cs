using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0233
{
    public class Utils0233
    {
        public void Dial(int n)
        {
            List<int> list = [0];
            for (int i = 1, cnt; i <= n; i++)
            {
                cnt = Count1(i);
                list.Add(list[i - 1] + cnt);
            }

            for (int i = 0; i <= n; i++) Console.WriteLine($"{i}\t{list[i]}");
        }

        private int Count1(int x)
        {
            int cnt = 0;
            while (x > 0)
            {
                if (x % 10 == 1) cnt++;
                x /= 10;
            }
            return cnt;
        }
    }
}
