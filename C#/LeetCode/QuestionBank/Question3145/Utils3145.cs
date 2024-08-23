using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3145
{
    public class Utils3145
    {
        public void Dial(int n)
        {
            int cnts = 0, cnt, pows = 0, pow, _pow;
            string _base2, _sp1, _sp2, _sp3, _sp4, _sp5, _sp6;
            for (int i = 1, _i; i <= n; i++)
            {
                cnt = pow = _pow = 0;
                _i = i;
                while (_i > 0)
                {
                    if ((_i & 1) == 1) { cnt++; pow += _pow; }
                    _i >>= 1; _pow++;
                }
                cnts += cnt;
                pows += pow;
                _base2 = Convert.ToString(i, 2);
                _sp1 = new string(' ', 5 - i.ToString().Length);
                _sp2 = new string(' ', 11 - _base2.Length);
                _sp3 = new string(' ', 3 - cnt.ToString().Length);
                _sp4 = new string(' ', 3 - pow.ToString().Length);
                _sp5 = new string(' ', 3 - _base2.Length.ToString().Length);
                _sp6 = new string(' ', 5 - cnts.ToString().Length);
                Console.WriteLine($"{i}{_sp1}{_sp2}{_base2}: {cnt}{_sp3}{pow}{_sp4}{_base2.Length}{_sp5}{cnts}{_sp6}{pows}");
            }
        }
    }
}
