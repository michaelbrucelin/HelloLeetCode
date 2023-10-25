using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2698
{
    public class Utils2698
    {
        public void Dial()
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 1, sum = 0; i <= 1000; i++) if (IsPunishment(i))
                {
                    sum += i * i; map.Add(i, sum);
                }

            Utils.Dump(map);
        }

        private bool IsPunishment(int num)
        {
            int pow = num * num;
            List<int> digits = new List<int>();
            while (pow > 0) { digits.Add(pow % 10); pow /= 10; }

            return IsPunishment(num, digits, 0, 0);
        }

        private bool IsPunishment(int num, List<int> digits, int curr, int pos)
        {
            for (int len = 1, _num; pos + len - 1 < digits.Count; len++)
            {
                _num = 0;
                for (int i = 0; i < len; i++)
                {
                    _num += digits[pos + i] * (int)Math.Pow(10, i);
                }
                if (curr + _num == num && pos + len == digits.Count) return true;
                if (curr + _num <= num)
                {
                    if (IsPunishment(num, digits, curr + _num, pos + len)) return true;
                }
            }

            return false;
        }
    }
}
