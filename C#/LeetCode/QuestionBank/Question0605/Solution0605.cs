using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0605
{
    public class Solution0605 : Interface0605
    {
        /// <summary>
        /// 贪心
        /// 找出连续的空位隔一棵种一棵，注意空位所在的位置不同计算方式也不同
        ///     整个，(N+1)/2，例如[0,0,0,0,0]
        ///     两端，N/2，    例如[0,0,0,1,1]或[1,1,0,0,0]
        ///     中间，(N-1)/2  例如[1,0,0,0,1]
        /// </summary>
        /// <param name="flowerbed"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0) return true;

            int left = 0, right = flowerbed.Length - 1;
            while (left <= right && flowerbed[left] == 0) left++;
            if (left > right)  // 整个数组全是0
            {
                n -= (left + 1) >> 1; if (n <= 0) return true;
            }
            else
            {
                n -= left >> 1; if (n <= 0) return true;
                while (right >= left && flowerbed[right] == 0) right--;
                n -= (flowerbed.Length - 1 - right) >> 1; if (n <= 0) return true;

                int _left = left, _right;
                while (_left <= right)
                {
                    while (_left <= right && flowerbed[_left] != 0) _left++;
                    if (_left > right) break;
                    _right = _left;
                    while (_right <= right && flowerbed[_right] == 0) _right++;
                    n -= (_right - _left - 1) >> 1; if (n <= 0) return true;
                    _left = _right + 1;
                }
            }

            return n <= 0;
        }
    }
}
