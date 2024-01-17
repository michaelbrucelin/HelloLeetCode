using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2729
{
    public class Utils2729
    {
        public void Dial()
        {
            List<int> buffer = new List<int>();
            for (int i = 100; i < 1000; i++)
                if (IsFascinating(i)) buffer.Add(i);

            Utils.Dump(buffer);  // [ 192, 219, 273, 327 ]
        }

        private bool IsFascinating(int n)
        {
            int mask = 0;
            for (int i = 1, _n = n, _d; i <= 3; _n = n * ++i) while (_n > 0)
                {
                    if ((_d = _n % 10) == 0) return false;
                    if (((mask >> (_d - 1)) & 1) == 1) return false;
                    mask |= 1 << (_d - 1);
                    _n /= 10;
                }

            return true;
        }
    }
}
