using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2269
{
    public class Solution2269 : Interface2269
    {
        public int DivisorSubstrings(int num, int k)
        {
            List<int> list = new List<int>();
            int _num = num;
            while (_num > 0)
            {
                list.Add(_num % 10); _num /= 10;
            }

            int result = 0;
            for (int i = list.Count - 1; i >= k - 1; i--)
            {
                _num = 0;
                for (int j = 0; j < k; j++)
                {
                    _num = _num * 10 + list[i - j];
                }
                if (_num > 0 && num % _num == 0) result++;
            }

            return result;
        }

        /// <summary>
        /// 与DivisorSubstrings()一样，但是使用字符串来处理
        /// </summary>
        /// <param name="num"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int DivisorSubstrings2(int num, int k)
        {
            string str = num.ToString();
            int result = 0, len = str.Length;
            for (int i = 0, _num; i <= len - k; i++)
            {
                _num = int.Parse(str.Substring(i, k));
                if (_num > 0 && num % _num == 0) result++;
            }

            return result;
        }
    }
}
