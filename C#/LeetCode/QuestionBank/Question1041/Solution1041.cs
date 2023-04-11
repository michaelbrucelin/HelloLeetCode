using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1041
{
    public class Solution1041 : Interface1041
    {
        private static readonly (int x, int y)[] dir = new (int x, int y)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };

        /// <summary>
        /// 分析
        /// 具体分析见Solution1041.md
        /// 
        /// 1. 先一轮移动，根据移动后状态（位置与方向）判断
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public bool IsRobotBounded(string instructions)
        {
            int x = 0, y = 0, d = 0;
            for (int i = 0; i < instructions.Length; i++)
            {
                switch (instructions[i])
                {
                    case 'L':
                        d = (d + 3) & 3;  // d = (d-1+4)%4
                        break;
                    case 'R':
                        d = (d + 1) & 3;  // d = (d+1)%4
                        break;
                    default:              // case 'G'
                        x += dir[d].x; y += dir[d].y;
                        break;
                }
            }

            return (x == 0 && y == 0) || d != 0;
        }

        /// <summary>
        /// 与IsRobotBounded()一样，最多移动4轮，验证每一轮移动后是否回到了原点
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public bool IsRobotBounded2(string instructions)
        {
            int x = 0, y = 0, d = 0;
            for (int time = 0; time < 4; time++)
            {
                for (int i = 0; i < instructions.Length; i++)
                {
                    switch (instructions[i])
                    {
                        case 'L':
                            d = (d + 3) & 3;  // d = (d-1+4)%4
                            break;
                        case 'R':
                            d = (d + 1) & 3;  // d = (d+1)%4
                            break;
                        default:              // case 'G'
                            x += dir[d].x; y += dir[d].y;
                            break;
                    }
                }
                if (x == 0 && y == 0) return true;
            }

            return false;
        }

        /// <summary>
        /// 与IsRobotBounded()一样，直接移动4轮，验证移动后是否回到了原点
        /// </summary>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public bool IsRobotBounded3(string instructions)
        {
            int x = 0, y = 0, d = 0;
            for (int time = 0; time < 4; time++) for (int i = 0; i < instructions.Length; i++)
                {
                    switch (instructions[i])
                    {
                        case 'L':
                            d = (d + 3) & 3;  // d = (d-1+4)%4
                            break;
                        case 'R':
                            d = (d + 1) & 3;  // d = (d+1)%4
                            break;
                        default:              // case 'G'
                            x += dir[d].x; y += dir[d].y;
                            break;
                    }
                }

            return x == 0 && y == 0;
        }
    }
}
