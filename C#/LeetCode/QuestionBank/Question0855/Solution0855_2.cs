using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0855
{
    /// <summary>
    /// 思路与Solution0855一样，不过这里不使用bool数字记录每一个座位的轻快，而是使用一个元组表记录每一组没有人做的位置
    /// </summary>
    public class ExamRoom_2 : Interface0855
    {
        public ExamRoom_2(int n)
        {
            seats = new HashSet<(int left, int right)>() { (0, n - 1) };
            len = n;
        }

        private HashSet<(int left, int right)> seats;
        private int len;

        public void Leave(int p)
        {
            (int left, int right) range = (p, p), range_left = (-1, -1), range_right = (-1, -1);
            bool find_left = false, find_right = false;
            foreach (var _range in seats)
            {
                if (_range.right == p - 1)
                {
                    range = (_range.left, range.right); find_left = true; range_left = _range;
                    if (find_left && find_right) break;
                }
                else if (_range.left == p + 1)
                {
                    range = (range.left, _range.right); find_right = true; range_right = _range;
                    if (find_left && find_right) break;
                }
            }

            if (find_left) seats.Remove(range_left);
            if (find_right) seats.Remove(range_right);
            seats.Add(range);
        }

        public int Seat()
        {
            if (seats.Count == 0) throw new Exception("there is no seat.");

            int result = len, distance = -1;
            (int left, int right) range = (-1, -1);
            foreach (var _range in seats)
            {
                int _result, _distance;
                if (_range.left == 0)
                {
                    _result = 0; _distance = _range.right;
                }
                else if (_range.right == len - 1)
                {
                    _result = len - 1; _distance = _range.right - _range.left;
                }
                else
                {
                    _result = (_range.left + _range.right) >> 1; _distance = (_range.right - _range.left) >> 1;
                }

                if ((_distance > distance) || (_distance == distance && _result < result))
                {
                    result = _result; distance = _distance; range = _range;
                }
            }

            if (range.left == result && range.right != result)
            {
                seats.Add((range.left + 1, range.right));
            }
            else if (range.left != result && range.right == result)
            {
                seats.Add((range.left, range.right - 1));
            }
            else if (range.left != result && range.right != result)
            {
                seats.Add((range.left, result - 1)); seats.Add((result + 1, range.right));
            }
            seats.Remove(range);

            return result;
        }
    }
}
