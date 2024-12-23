using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0855
{
    /// <summary>
    /// 这里用一个bool数组来模拟座位情况，提交后内存溢出了
    /// </summary>
    public class ExamRoom : Interface0855
    {
        public ExamRoom(int n)
        {
            seats = new bool[n];
            len = n;
        }

        private bool[] seats;
        private int len;

        public void Leave(int p)
        {
            seats[p] = false;
        }

        public int Seat()
        {
            int result = -1, distance = -1, left = 0, right;
            while (left < len)
            {
                while (left < len && seats[left]) left++;              // 空位的左端
                right = left;
                while (right + 1 < len && !seats[right + 1]) right++;  // 空位的右端

                if (left == len) break;
                int _distance;
                if (left == 0)
                {
                    distance = right - left; result = 0;
                }
                else if (right == len - 1)
                {
                    if ((_distance = right - left) > distance)
                    {
                        distance = _distance; result = len - 1;
                    }
                }
                else
                {
                    if ((_distance = (right - left) >> 1) > distance)
                    {
                        distance = _distance; result = (left + right) >> 1;
                    }
                }

                left = right + 1;
            }

            if (result != -1)
            {
                seats[result] = true;
                return result;
            }
            throw new Exception("there is no seat.");
        }
    }
}
