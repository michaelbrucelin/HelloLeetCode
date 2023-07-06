using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1232
{
    public class Solution1232 : Interface1232
    {
        /// <summary>
        /// 精度问题及除数为0
        /// 用乘法，不要用除法
        /// (y2-y1)/(x2-x1) = (yn-y1)(xn-x1) <=> (y2-y1)(xn-x1) =(yn-y1)(x2-x1)
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length == 2) return true;

            int x0 = coordinates[0][0], y0 = coordinates[0][1];
            int _x = coordinates[1][0] - x0, _y = coordinates[1][1] - y0;
            for (int i = 2; i < coordinates.Length; i++)
            {
                if (_y * (coordinates[i][0] - x0) != _x * (coordinates[i][1] - y0)) return false;
            }

            return true;
        }
    }
}
