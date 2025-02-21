using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2652
{
    public class Solution2652_2 : Interface2652
    {
        /// <summary>
        /// 三指针
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumOfMultiples(int n)
        {
            int result = 0;
            for (int i = 0, j = 0, k = 0, _i = 0, _j = 0, _k; i <= n || j <= n || k <= n;)
            {
                _i = i + 3; _j = j + 5; _k = k + 7;
                if (_i < _j && _i < _k)
                {
                    if (_i <= n) { result += _i; i = _i; } else break;
                }
                else if (_j < _k && _j < _i)
                {
                    if (_j <= n) { result += _j; j = _j; } else break;
                }
                else if (_k < _i && _k < _j)
                {
                    if (_k <= n) { result += _k; k = _k; } else break;
                }
                else if (_i == _j && _i < _k)
                {
                    if (_i <= n) { result += _i; i = j = _i; } else break;
                }
                else if (_j == _k && _j < _i)
                {
                    if (_j <= n) { result += _j; j = k = _j; } else break;
                }
                else if (_k == _i && _k < _j)
                {
                    if (_k <= n) { result += _k; k = i = _k; } else break;
                }
                else  // if (_i == _j && _j == _k)
                {
                    if (_i <= n) { result += _i; i = j = k = _i; } else break;
                }
            }

            return result;
        }

        /// <summary>
        /// 三次遍历 + 哈希
        /// 本质上与上面的三指针是一样的逻辑
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SumOfMultiples2(int n)
        {
            HashSet<int> set = new HashSet<int>();
            int result = 0;
            foreach (int j in new int[] { 3, 5, 7 }) for (int i = j; i <= n; i += j) if (!set.Contains(i))
                    {
                        result += i; set.Add(i);
                    }

            return result;
        }
    }
}
