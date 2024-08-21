using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCode.QuestionBank.Question3007
{
    public class Utils3007
    {
        public void Dial(int k, int x)
        {
            int cnt = 0;
            string _base2;
            for (int i = 0, _i, _cnt, _sp1, _sp2; i < k; i++)
            {
                _i = i; _cnt = 0;
                while (_i > 0)
                {
                    _cnt += (_i >> (x - 1)) & 1;
                    _i >>= x;
                }
                cnt += _cnt;
                _base2 = Convert.ToString(i, 2);
                _sp1 = i.ToString().Length;
                _sp2 = _base2.Length;
                // Console.WriteLine($"{i}{new string(' ', 16 - _sp1 - _sp2)}{_base2}: {_cnt} {_sp2} {cnt}");
                Console.WriteLine($"{i}{new string(' ', 18 - _sp1 - _sp2)}{_base2}: {_cnt} {_sp2} {cnt}");
            }
        }
    }
}
